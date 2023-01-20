using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MovmentController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _movementVelocity= GetMovmentVelocity();
        Move(_movementVelocity);

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

    }
    private void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    private Vector3 GetMovmentVelocity()
    {
        //Calculate movement velocity as 3d vector
        float _xMovment = Input.GetAxis("Horizontal");
        float _zMovment = Input.GetAxis("Vertical");
        float _yMovment = Input.GetAxis("Jump");
        Vector3 _movmentHorizontal = transform.right * _xMovment;
        Vector3 _movmentVertical = transform.forward * _zMovment;
        Vector3 _movmentJump=transform.up*_yMovment;
        //Final movement velocity
        return (_movmentHorizontal + _movmentVertical+ _movmentJump).normalized * speed;
    }
}
