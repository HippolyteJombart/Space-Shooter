using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float limitPositionZ;
    [SerializeField] private float backPositionZ;
    private void Update()
    {
        if (transform.localPosition.z <= limitPositionZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, backPositionZ);
        }
    }
}