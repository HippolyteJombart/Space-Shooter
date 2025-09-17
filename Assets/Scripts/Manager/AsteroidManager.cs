using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject[] asteroids;
    [SerializeField] float delayAsteroid;
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }
    IEnumerator SpawnAsteroid()
    {
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-2.5f, 2.5f), 0, 12), Quaternion.identity);
        yield return new WaitForSeconds(delayAsteroid);
        StartCoroutine(SpawnAsteroid());
    }
}