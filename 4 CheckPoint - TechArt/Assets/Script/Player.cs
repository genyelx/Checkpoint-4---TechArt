using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("freelookcamera")]
    [SerializeField] private GameObject Camera;

    private Rigidbody rb;

    private float moveX;
    private float moveZ;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Camera camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 CamF = Camera.transform.forward;
        Vector3 CamR = Camera.transform.right;

        CamF.y = 0;
        CamR.y = 0;

        Vector3 Dir = CamF * moveZ + CamR * moveX;

        rb.linearVelocity = new Vector3(Dir.x * speed, rb.linearVelocity.y, Dir.z * speed);

        Quaternion finalRotation = new Quaternion(0, Camera.transform.rotation.y, 0, Camera.transform.rotation.w);
        transform.rotation = finalRotation;
    }
}
