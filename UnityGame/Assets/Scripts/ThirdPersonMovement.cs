using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Reference: Brackeys
    public CharacterController controller;
    public Transform camera;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Animator animator;

    public float gravity = -9.81f;
    public float JumpHight = 50f;
    bool isGrounded;
    float jumpdist = 0f;

    public Transform groundCheck;
    public float groundDistance = 1.5f;
    public LayerMask groundMask;



    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpdist = Mathf.Sqrt(JumpHight * -3.0f * gravity);
        }

        if (isGrounded &&  jumpdist< 0)
        {
            jumpdist = -2f;
        }

        jumpdist += gravity * Time.deltaTime;
        Vector3 directionUp = new Vector3(0f, jumpdist, 0f);

        controller.Move(directionUp * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

        animator.SetFloat("FWDBWD", vertical);
        animator.SetFloat("Sideway", horizontal);
        animator.SetFloat("speed", direction.magnitude);
    }
}
