using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject asteroidVfx;
    [SerializeField] private GameObject playerVfx;
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
        }
        else if (collision.gameObject.CompareTag("Asteroids"))
        {
            Instantiate(asteroidVfx, collision.transform.position, Quaternion.identity);
            AudioManager.instance.AsteroidsExplosionAudio();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            Instantiate(playerVfx, collision.transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
