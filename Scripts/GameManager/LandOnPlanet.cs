using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandOnPlanet : MonoBehaviour
{
    public string WarpToScene;
    public bool canEnter;

    public GameObject planet;

    // Questionbox
    public Text questionText;
    public GameObject planetQWindow;
    public bool boxIsActive;
    public ShipController shipController;

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        planet = this.gameObject;

        if (canEnter)
        {
            questionText.text = "Want to land on " + planet + "?";
            planetQWindow.SetActive(true);
            boxIsActive = true;
            boxIsActive = true;
        }

        else
        {
            planetQWindow.SetActive(false);
            boxIsActive = false;
            boxIsActive = false;
        }
    }

    public void YesBox()
    {
        planetQWindow.SetActive(false);
        shipController.enabled = false;
        SceneManager.LoadScene(WarpToScene);
    }

    public void NoBox()
    {
        canEnter = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 11)
        {
            canEnter = true;
            shipController = collision.GetComponentInParent<ShipController>();
            WarpToScene = this.gameObject.name;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 11)
        {
            canEnter = false;
        }
    }
}
