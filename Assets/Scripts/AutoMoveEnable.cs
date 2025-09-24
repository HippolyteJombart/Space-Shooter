using UnityEngine;

public class AutoMoveEnable : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Vector3 direction;
    [SerializeField] private Rigidbody objectRigidbody; 
    
    private void OnEnable()
    {
        if (objectRigidbody == null)
        {
            objectRigidbody = GetComponent<Rigidbody>();
        }
        objectRigidbody.linearVelocity = direction * speed;
    }
}