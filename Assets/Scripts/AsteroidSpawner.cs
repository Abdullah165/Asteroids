using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float spawnnRate = 2f;
    [SerializeField] float spawnnAmount = 1f;
    [SerializeField] Asteroid asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnnRate, spawnnRate);   
    }

    void Spawn()
    {
        float xPosition = 10f;
        Vector2 spawnPosition = new Vector2(xPosition, Random.Range(-4f,4f));

        for(int index = 0; index < spawnnAmount;index++)
        {
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            spawnPosition = -spawnPosition;
            if(xPosition > 0)
            {
                asteroid.SetTrajectory(Vector2.left);
                xPosition *= -1;
            }
            else
            {
                asteroid.SetTrajectory(Vector2.right);
                xPosition *= -1;
            }
        }

    }


}
