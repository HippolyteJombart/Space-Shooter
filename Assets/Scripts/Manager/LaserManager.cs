using System;
using UnityEngine;
using System.Collections.Generic;

public class LaserManager : MonoBehaviour
{
    public static LaserManager instance;
    
    //Instantiate Laser
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserSpawn;
    [SerializeField] private GameObject cloneLaserParent;
    private int laserNumber = 50;
    
    //Pooling System
    private Queue<GameObject> queue = new Queue<GameObject>();
    private GameObject currentLaser;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    
    private void Start()
    {
        for (int i = 0; i < laserNumber; i++)
        {
            currentLaser = Instantiate(laserPrefab, laserSpawn.transform.position, Quaternion.identity, cloneLaserParent.transform);
            queue.Enqueue(currentLaser);
            currentLaser.SetActive(false);
        }
    }

    public void PoolLaser()
    {
        if (queue.Count == 0)
        {
            return;
        }
        currentLaser = queue.Dequeue();
        currentLaser.transform.position = laserSpawn.transform.position;
        currentLaser.SetActive(true);
    }
    
    public void UnPoolLaser(GameObject laser)
    {
        queue.Enqueue(laser);
        laser.SetActive(false);
    }
}