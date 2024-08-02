using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Place on GameManager (Empty Object)

    public TriggerPoints tp;
    public PlanetTrigger ptp;

    public GameObject playerObject;
    public GameObject shipObject;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Edora();
    }

    private void Edora()
    {
        if (tp.PlanetTriggerPoint == "Edora")
        {
            playerObject.transform.position = GameObject.Find("EdoraSpawn").transform.position;
            shipObject.transform.position = GameObject.Find("EdoraShipSpawn").transform.position;
            Camera.main.transform.position = playerObject.transform.position;
        }

        else if (tp.TriggerPoint == "EdoraExit")
        {
            Debug.Log("Outside Edora");
            shipObject.transform.position = GameObject.Find("EdoraExitSpawn").transform.position;
        }
    }
}
