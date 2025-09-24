using System;
using UnityEngine;

public class ShieldCollisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject shield;

    private void Awake()
    {
        shield = GameObject.FindGameObjectWithTag("Shield");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shield.SetActive(true);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Lasers"))
        {
            shield.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}