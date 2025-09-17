using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject asteroidVfx;
    [SerializeField] GameObject playerVfx;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(playerVfx, collision.transform.position, Quaternion.identity);
            GameManager.instance.LoseLife();
            AudioManager.instance.PlayerExplosionAudio();
        }
        else if (collision.gameObject.tag == "Lasers")
        {
            Instantiate(asteroidVfx, collision.transform.position, Quaternion.identity);
            GameManager.instance.AddPoint();
            AudioManager.instance.AsteroidsExplosionAudio();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Asteroids")
        {
            Instantiate(asteroidVfx, collision.transform.position, Quaternion.identity);
            AudioManager.instance.AsteroidsExplosionAudio();
        }
        else if (collision.gameObject.tag == "Shield")
        {
            Destroy(collision.gameObject);
            Instantiate(playerVfx, collision.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
