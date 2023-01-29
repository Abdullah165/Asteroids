using UnityEngine.UI;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;

    [SerializeField] float asteroidSpeed = 50f;


    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360);
    }

    public void SetTrajectory(Vector2 direction)
    {
        rigidbody2D.AddForce(direction * asteroidSpeed);
        Destroy(gameObject, 20f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<PlayerScore>().AddScore(this);
            Destroy(gameObject);
        }
         
    }
}
