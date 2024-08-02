using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LeavePlanet : MonoBehaviour
{
    public string WarpToScene;
    public bool canEnter;

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;


        if(sceneName != "Space")
        {
            if (canEnter && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(WarpToScene);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            canEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            canEnter = false;
        }
    }
}
