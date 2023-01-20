using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MovmentController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float runningSpeed = 9f;
    [SerializeField] private Animator animator;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Camera fpsCamera;

    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraUpAndDownRotation=0f;
    private float currentCameraUpAndDownRotation = 0f;

    float mouseX;
    float mouseY;

    public float mouseSensitivity2 = 100f;

    public Transform player;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float _currentSpeed;
        if (Input.GetButton("Fire3"))
            _currentSpeed = runningSpeed;
        
        else
            _currentSpeed = speed;

        Vector3 _movementVelocity = GetMovmentVelocity(_currentSpeed);
        Move(_movementVelocity);

        Vector3 _rotationVector = GetRotation();
        //Apply Rotation
        //Rotate(_rotationVector);
        //Calculate Look up and down camera rotation
        //float _cameraUpDownRotation = Input.GetAxis("Mouse Y")*mouseSensitivity;
        //Apply Rotation to camera
        //RotateCamera(_cameraUpDownRotation);
        mouseX = Input.GetAxis("Mouse Y") * mouseSensitivity2 * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse X") * mouseSensitivity2 * Time.deltaTime;
        //Running
        
        

        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 58f);
        
        yRotation -= mouseY;

        fpsCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.transform.localRotation = Quaternion.Euler(0f, -yRotation, 0f);
        //player.Rotate(Vector3.up * mouseY);




    }
    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            animator.SetInteger("animationState", 1);
        }
        else
            animator.SetInteger("animationState", 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (fpsCamera!=null)
        {
            //currentCameraUpAndDownRotation -= cameraUpAndDownRotation;
            //fpsCamera.transform.localEulerAngles=new Vector3(currentCameraUpAndDownRotation,0,0);

        }
    }
    private void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }
    private void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }
    private Vector3 GetMovmentVelocity(float currentSpeed)
    {
        //Calculate movement velocity as 3d vector
        float _xMovment = Input.GetAxis("Horizontal");
        float _zMovment = Input.GetAxis("Vertical");
        float _yMovment = Input.GetAxis("Jump");
        Vector3 _movmentHorizontal = transform.right * _xMovment;
        Vector3 _movmentVertical = transform.forward * _zMovment;
        Vector3 _movmentJump=transform.up*_yMovment;
        //Final movement velocity
        return (_movmentHorizontal + _movmentVertical+ _movmentJump).normalized * currentSpeed;
    }
    private Vector3 GetRotation()
    {
        //Calculate rotation as a 3D Vector for mouse movment
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation, 0) * mouseSensitivity;
        return _rotationVector;
    }
    private void RotateCamera(float cameraUpAndDownRotation)
    {
        this.cameraUpAndDownRotation = cameraUpAndDownRotation;
    }
}
