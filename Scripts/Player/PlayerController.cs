using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed;
    public float moveSpeed;
    public float sprintModifyer;
    public float rotationSpeed;

    public float jumpForce;


    public Animator animator;

    public bool onGround;

    public bool dancing = false;

    public Rigidbody rigidbody;

    float horizontal;
    float vertical;

    private Vector3 movement;


    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        JumpInput();

        if (Input.GetKeyDown(KeyCode.T))
        {
            dancing = !dancing;
        }

        if (dancing)
        {
            animator.SetBool("isDancing", true);
        }

        else if (!dancing)
        {
            animator.SetBool("isDancing", false);
        }
    }

    private void FixedUpdate()
    {
        MovePhysics();
        RotationPhysics();
    }

    private void MovementInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0, vertical).normalized;
        Animation();
    }

    private void JumpInput()
    {
        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(0, jumpForce, 0, ForceMode.Acceleration);
                Debug.Log("JUMPING");
            }
        }

    }

    private void Animation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("isWalking", true);
            dancing = false;
        }

       else if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("isWalking", true);
            dancing = false;
        }

        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void MovePhysics()
    {
        rigidbody.velocity = movement * moveSpeed;
    }

    private void RotationPhysics()
    {
        if (movement.x < -0.1)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, -90, 0)), rotationSpeed * Time.fixedDeltaTime);
        }
        if (movement.x > 0.1)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 90, 0)), rotationSpeed * Time.fixedDeltaTime);
        }
       if (movement.z < -0.1)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, -180, 0)), rotationSpeed * Time.fixedDeltaTime);
        }
      if (movement.z > 0.1)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, 0)), rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            onGround = false ;
        }
    }
}
