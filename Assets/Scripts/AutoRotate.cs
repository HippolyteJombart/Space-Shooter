using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private Vector3 rotation;
    private void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
}