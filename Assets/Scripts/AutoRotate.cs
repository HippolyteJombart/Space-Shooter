using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    Vector3 rotation;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
}