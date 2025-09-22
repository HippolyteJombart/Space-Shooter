using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] public float delayAsteroid;
    private void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector3(Random.Range(-2.5f, 2.5f), 0, 12), Quaternion.identity);
            yield return new WaitForSeconds(delayAsteroid);
        }
    }
}