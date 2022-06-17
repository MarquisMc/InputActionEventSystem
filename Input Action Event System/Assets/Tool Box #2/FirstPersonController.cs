using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;

    Rigidbody rb;

    Transform cameraT;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    [Header("movement")]
    float speed;
    public float walkSpeed;
    public float runSpeed;

    [Header("Jump")]
    public float jumpForce;
    public float jumpRayDist;
    public LayerMask groundedMask;
    public Transform jumpRayPosition;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cameraT = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        TurnOffCursor();

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;

        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);

        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        Vector3 targetMoveAmount = moveDir * speed;

        // smooth out the movement
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);

        // added jump to update because I am calling it once
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        checkingGround();
    }

    private void FixedUpdate()
    {
        // making the player move on its own local access and not the world access using transform.TransformDirection and passing in moveAmount
        rb.MovePosition(transform.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

    }

    void TurnOffCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void checkingGround()
    {
        isGrounded = false;

        Ray ray = new Ray(jumpRayPosition.position, -transform.up);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, jumpRayDist, groundedMask))
        {
            isGrounded = true;
        }
    }

}
