using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private float rotationLimit = 2f;
    private void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-rotationLimit,rotationLimit), Random.Range(-rotationLimit, rotationLimit), Random.Range(-rotationLimit, rotationLimit));
    }
}