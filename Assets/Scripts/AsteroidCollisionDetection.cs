using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidCollisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject asteroidVfx;
    [SerializeField] private GameObject playerVfx;
    [SerializeField] private GameObject powerUp;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(playerVfx, collision.transform.position, Quaternion.identity);
            GameManager.instance.LoseLife();
            AudioManager.instance.PlayerExplosionAudio();
        }
        else if (collision.gameObject.CompareTag("Lasers"))
        {
            Instantiate(asteroidVfx, collision.transform.position, Quaternion.identity);
            GameManager.instance.AddPoint();
            AudioManager.instance.AsteroidsExplosionAudio();
            Destroy(collision.gameObject);
            if (Random.Range(0, 10) == 0)
            {
                Instantiate(powerUp, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            }
        }
        else if (collision.gameObject.CompareTag("Asteroids"))
        {
            Instantiate(asteroidVfx, collision.transform.position, Quaternion.identity);
            AudioManager.instance.AsteroidsExplosionAudio();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(playerVfx, collision.transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            return;
        }
        Destroy(gameObject);
    }
}