using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterExit : MonoBehaviour
{

    // Player
    public GameObject player;
    public PlayerController playerController;

    // Ship
    public Transform ship;
    public ShipController shipController;
    public Transform enterExitObj;

    public GameObject fuelHUD;

    // Bools
    public bool inVehicle = false;
    public bool inCollider = false;
    public bool canExit;

    // Misc
    public Vector3 offset;
    public GameObject notAllowed;

    void Start()
    {
        inVehicle = false;
        shipController.rigidbody.isKinematic = true;
        fuelHUD.SetActive(false);
        playerController.GetComponent<PlayerController>();
        shipController.GetComponent<ShipController>();
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inCollider)
                {
                    if (!inVehicle)
                    {
                        Enter();
                    }

                    else
                    {
                        if (canExit)
                        {
                            if (inVehicle)
                            {
                                Exit();
                            }
                        }
                    }
                }
            }
      

        else if (sceneName == "Space" && inVehicle)
        {
            shipController.enabled = true;
        }

        if (inVehicle)
        {
            player.transform.position = enterExitObj.position;
            playerController.onGround = false;
        }
    }

    private void Enter()
    {
        ActivateVehicle();

        DeactivatePlayer();
    }

    public void Exit()
    {
        ActivatePlayer();

        DeactivateVehicle();
    }

    public void ActivateVehicle()
    {
        inVehicle = true;
        fuelHUD.SetActive(true);
        shipController.enabled = true;
        shipController.rigidbody.isKinematic = false;
    }

    public void DeactivatePlayer()
    {
        player.SetActive(false);
        playerController.enabled = false;
    }

    public void ActivatePlayer()
    {
        player.SetActive(true);
        playerController.enabled = true;
    }

    public void DeactivateVehicle()
    {
        inVehicle = false;
        fuelHUD.SetActive(false);
        shipController.enabled = false;
        shipController.rigidbody.velocity = new Vector2(0, 0);
        shipController.rigidbody.isKinematic = true;
    }



    // ONTRIGGER

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inCollider = true;
        }

        if (other.gameObject.layer == 20 && inVehicle)
        {
            canExit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inCollider = false;
        }
    }
}
