using UnityEngine;

public class MoveBack : MonoBehaviour
{
    void Update()
    {
        if (transform.localPosition.z <= -20f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 20f);
        }
    }
}