using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    [SerializeField] private float lifetime;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}