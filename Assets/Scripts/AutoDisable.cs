using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] private float lifetime;
    
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }
    
    private IEnumerator Disable()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(lifetime);
        Debug.Log("2");
        LaserManager.instance.UnPoolLaser(gameObject);
    }
}
