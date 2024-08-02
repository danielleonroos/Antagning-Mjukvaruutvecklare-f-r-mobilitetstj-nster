using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTrigger : MonoBehaviour
{
    public string planet;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 12)
        {
            planet = collision.gameObject.name;
        }
    }
}
