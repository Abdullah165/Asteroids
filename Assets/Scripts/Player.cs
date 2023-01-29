using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float rotSpeed = 0.4f;
    float turnDirection;
    Rigidbody2D rigidbody2D;

    [SerializeField] GameObject gameOver;
    [SerializeField] float bulletSpeed = 500;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(transform.up * playerSpeed);
        }

        if (turnDirection != 0)
        {
            rigidbody2D.AddTorque(turnDirection * rotSpeed);
        }
    }

    void Shoot()
    {
        GameObject bullet = PoolManager.Instance.RequestBullet();
        bullet.transform.position = transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(this.transform.up * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            gameOver.SetActive(true);
        }
    }
}
