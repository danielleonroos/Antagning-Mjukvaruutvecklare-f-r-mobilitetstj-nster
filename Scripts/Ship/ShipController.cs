using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public float thrustForce;

    public float rotationSpeed = 5;

    public float gravityForce;

    public bool thrusting;

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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Space")
        {
            rigidbody.useGravity = false;
        }

        else
        {
            rigidbody.useGravity = true;
        }

        MovementInput();
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

        movement = new Vector3(horizontal, gravityForce, vertical).normalized;

        if (movement.x > 0.01f || movement.y > 0.01f || movement.z > 0.01f || movement.x < -0.01f || movement.y < -0.01f || movement.z < -0.01f)
        {
            thrusting = true;
        }

        else
        {
            thrusting = false;
        }


    }

    private void MovePhysics()
    {
        rigidbody.AddForce (movement * thrustForce * Time.fixedDeltaTime, ForceMode.Impulse);
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
}
