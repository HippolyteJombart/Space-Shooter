using UnityEngine;

public class AutoMoveLaser : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Vector3 direction;
    [SerializeField] private Rigidbody laserRigidbody;
    
    private void Start()
    {
        laserRigidbody = GetComponent<Rigidbody>();
        laserRigidbody.linearVelocity = direction * speed;
    }

    private void OnEnable()
    {
        laserRigidbody.linearVelocity = direction * speed;
    }
}
