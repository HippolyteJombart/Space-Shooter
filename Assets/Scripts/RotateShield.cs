using UnityEngine;
using System.Collections;

public class RotateShield : MonoBehaviour
{
    [SerializeField] public GameObject[] shieldSprites;
    private float delayRotation = 0.1f;

    private void Start()
    {
        StartCoroutine((RotationShield()));
    }
    private IEnumerator RotationShield()
    {
        int i = 0;
        while (true)
        {
            shieldSprites[(i - 1 + shieldSprites.Length) % shieldSprites.Length].SetActive(false);
            shieldSprites[i].SetActive(true);
            i++;
            i %= shieldSprites.Length;
            yield return new WaitForSeconds(delayRotation);
        }
    }
}
