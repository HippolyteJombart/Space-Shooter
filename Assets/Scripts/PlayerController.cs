using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Input
    private float verticalInput;
    private float horizontalInput;
    private float horizontalTiltInput;

    //Movement
    [SerializeField] public float speed;
    [SerializeField] private float xLimitLeft;
    [SerializeField] private float xLimitRight;
    [SerializeField] private float zLimitDown;
    [SerializeField] private float zLimitUp;
    [SerializeField] private float tilt;
    [SerializeField] private Rigidbody componentRigidbody;

    //Laser
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserSpawn;
    [SerializeField] public float fireDelay;
    private float lastShotTime;

    private void Start()
    {
        lastShotTime = -fireDelay;
    }
    private void Update()
    {
        //gestion du mouvement
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        horizontalTiltInput = Input.GetAxis("Horizontal Tilt");

        Vector3 direction = new Vector3(horizontalInput * Time.deltaTime, 0, verticalInput * Time.deltaTime);
        direction.Normalize();
        componentRigidbody.linearVelocity = direction * speed;
        componentRigidbody.rotation = Quaternion.Euler(0, 0, -horizontalTiltInput * tilt);

        //bordure de jeu
        float positionX = transform.position.x;
        float positionZ = transform.position.z;

        positionX = Mathf.Clamp(positionX, xLimitLeft, xLimitRight);
        positionZ = Mathf.Clamp(positionZ, zLimitDown, zLimitUp);
        Vector3 newPosition = new Vector3(positionX, 0, positionZ);
        transform.position = newPosition;

        //gestion du tir
        if (Input.GetKeyDown("space") && Time.time > lastShotTime + fireDelay && !GameManager.instance.inPause)
        {
            Instantiate(laserPrefab, laserSpawn.transform.position, Quaternion.identity);
            AudioManager.instance.ShootAudio();
            lastShotTime = Time.time;
        }
    }
}