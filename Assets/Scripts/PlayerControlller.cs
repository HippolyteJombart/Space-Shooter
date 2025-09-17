using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    //Input
    float verticalInput;
    float horizontalInput;
    float horizontalTiltInput;

    //Movement
    [SerializeField] float speed;
    [SerializeField] float xLimitLeft;
    [SerializeField] float xLimitRight;
    [SerializeField] float zLimitDown;
    [SerializeField] float zLimitUp;
    [SerializeField] float tilt;
    [SerializeField] Rigidbody componentRigidbody;

    //Laser
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject laserSpawn;
    [SerializeField] float fireDelay;
    float lastShotTime;

    void Start()
    {
        lastShotTime = -fireDelay;
    }
    void Update()
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