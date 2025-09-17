using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    [SerializeField] float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}