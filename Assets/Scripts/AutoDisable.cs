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
        yield return new WaitForSeconds(lifetime);
        LaserManager.instance.UnPoolLaser(gameObject);
    }
}
