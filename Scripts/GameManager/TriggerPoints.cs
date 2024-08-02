using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour
{
    // Place on Player

    public string TriggerPoint;
    public string PlanetTriggerPoint;
    public PlanetTrigger pt;

    private void Update()
    {
       PlanetTriggerPoint = pt.planet;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EdoraExit")
        {
            TriggerPoint = "EdoraExit";
        }
    }

    void OnTriggerExit(Collider other)
    {
            TriggerPoint = null;
    }
}
