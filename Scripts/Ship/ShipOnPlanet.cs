using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipOnPlanet : MonoBehaviour
{
    public bool shipIsOnPlanet;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            shipIsOnPlanet = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            shipIsOnPlanet = false;
        }
    }
}
