using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Vector3 direction;
    private void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }
}