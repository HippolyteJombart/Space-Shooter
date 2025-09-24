using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidCollisionDetection : MonoBehaviour
{
    //Shield and Power up
    [SerializeField] private int chanceOfPowerUp;
    private GameObject shield;
    private GameObject powerUp;
    
    private void OnCollisionEnter(Collision collision)
    {
        shield = GameObject.FindGameObjectWithTag("Shield");
        powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (shield != null)
            {
                return;
            }
            PlayerVfxManager.instance.PoolVfx(gameObject);
            GameManager.instance.LoseLife();
            AudioManager.instance.PlayerExplosionAudio();
        }
        else if (collision.gameObject.CompareTag("Lasers"))
        {
            AsteroidVfxManager.instance.PoolVfx(gameObject);
            GameManager.instance.AddPoint();
            AudioManager.instance.AsteroidsExplosionAudio();
            LaserManager.instance.UnPoolLaser(collision.gameObject);
            if (Random.Range(0, 100/chanceOfPowerUp) == 0 && shield == null && powerUp == null)
            {
                ShieldManager.instance.PoolShieldPowerUp(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Asteroids"))
        {
            AsteroidVfxManager.instance.PoolVfx(gameObject);
            AudioManager.instance.AsteroidsExplosionAudio();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            collision.gameObject.SetActive(false);
            PlayerVfxManager.instance.PoolVfx(gameObject);
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            return;
        }
        Destroy(gameObject);
    }
}