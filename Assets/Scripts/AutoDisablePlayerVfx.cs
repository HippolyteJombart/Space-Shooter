using System;
using UnityEngine;
using System.Collections;

public class AutoDisablePlayerVfx : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }
    
    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(lifetime);
        PlayerVfxManager.instance.UnPoolVfx(gameObject);
    }
}
