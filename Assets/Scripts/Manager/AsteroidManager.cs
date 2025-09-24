using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private float delayAsteroid;
    [SerializeField] private GameObject cloneAsteroidParent;
    private float asteroidSpawnXLimit = 4f;
    private int asteroidSpawnY = 0;
    private int asteroidSpawnZ = 12;
    
    private void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-asteroidSpawnXLimit, asteroidSpawnXLimit), asteroidSpawnY, asteroidSpawnZ), Quaternion.identity, cloneAsteroidParent.transform);
            yield return new WaitForSeconds(delayAsteroid);
        }
    }
}