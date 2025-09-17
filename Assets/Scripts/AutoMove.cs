using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }
}