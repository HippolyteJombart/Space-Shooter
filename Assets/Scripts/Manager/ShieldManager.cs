using System;
using UnityEngine;
using System.Collections.Generic;

public class ShieldManager : MonoBehaviour
{
    public static ShieldManager instance;
    
    [SerializeField] private GameObject shieldPowerUp;
    private bool isAvailable;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    
    private void Start()
    {
        isAvailable = true;
    }

    public void PoolShieldPowerUp(GameObject asteroid)
    {
        if (!isAvailable)
        {
            return;
        }
        shieldPowerUp.transform.position = asteroid.transform.position;
        shieldPowerUp.SetActive(true);
    }
    
    public void UnPoolShieldPowerUp(GameObject shield)
    {
        shield.SetActive(false);
    }
}