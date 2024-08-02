using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightLight : MonoBehaviour
{
    public DayNightCycle dnc;
    public Light nightLight;

    // Start is called before the first frame update
    void Start()
    {
        nightLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dnc.sunIntensity < 0.3f)
        {
            nightLight.intensity = 10;
        }

        if (dnc.sunIntensity > 0.3f)
        {
            nightLight.intensity = 0;
        }
    }
}
