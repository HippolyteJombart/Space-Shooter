using UnityEngine;
using System.Collections.Generic;

public class PlayerVfxManager : MonoBehaviour
{
    public static PlayerVfxManager instance;
    
    //Instantiate Vfx
    [SerializeField] private GameObject vfxPrefab;
    [SerializeField] private GameObject cloneVfxParent;
    private Vector3 vfxSpawn = new Vector3(0, 0, 0);
    private int vfxNumber = 5;
    
    //Pooling System
    private Queue<GameObject> queue = new Queue<GameObject>();
    private GameObject currentVfx;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    
    private void Start()
    {
        for (int i = 0; i < vfxNumber; i++)
        {
            currentVfx = Instantiate(vfxPrefab, vfxSpawn, Quaternion.identity, cloneVfxParent.transform);
            queue.Enqueue(currentVfx);
            currentVfx.SetActive(false);
        }
    }

    public void PoolVfx(GameObject asteroid)
    {
        if (queue.Count == 0)
        {
            return;
        }
        currentVfx = queue.Dequeue();
        currentVfx.transform.position = asteroid.transform.position;
        currentVfx.SetActive(true);
    }
    
    public void UnPoolVfx(GameObject vfx)
    {
        queue.Enqueue(vfx);
        vfx.SetActive(false);
    }
}
