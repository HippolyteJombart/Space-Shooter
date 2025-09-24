using System;
using UnityEngine;

public class ShieldCollisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shield.SetActive(true);
            ShieldManager.instance.UnPoolShieldPowerUp(gameObject);
        }
        else if (collision.gameObject.CompareTag("Lasers"))
        {
            shield.SetActive(true);
            ShieldManager.instance.UnPoolShieldPowerUp(gameObject);
            LaserManager.instance.UnPoolLaser(collision.gameObject);
        }
    }
}