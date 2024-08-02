using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStats : MonoBehaviour
{
    public float maxFuel;

    public float fuel;

    public Image fuelBar;

    public GameObject thurstParticles;

    public ShipController shipController;

    // Start is called before the first frame update
    void Start()
    {
        maxFuel = 1000f;
        fuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel < 0.1f)
        {
            shipController.thrustForce = 0;
            shipController.rigidbody.velocity = new Vector2(0, 0);
            thurstParticles.SetActive(false);
        }

        if (fuel > 0.1f)
        {
            shipController.thrustForce = 1000;

            if (shipController.thrusting)
            {
                fuel -= 0.1f;
                thurstParticles.SetActive(true);
            }

            if (!shipController.thrusting)
            {
                thurstParticles.SetActive(false);
            }
        }

        fuelBar.fillAmount = fuel / maxFuel;
    }
}
