using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;

    public float plusSpeed;
    public float minusSpeed;
    private float cycleSpeed;
    private float t = 1;

    private bool newDay;

    public int dayCounter = 1;
    public int monthCounter = 1;
    public int yearCounter = 1;


    [Range(0, 1)]
    public float sunIntensity = 1;

    // Start is called before the first frame update
    void Start()
    {
        t = 1;
    }

    public void Update()
    {
        if (sunIntensity == 0)
        {
            cycleSpeed = plusSpeed;
        }

        if (sunIntensity == 1)
        {
            newDay = true;
            cycleSpeed = minusSpeed;
        }

        IntencityCycle();

        LifetimeCounter();
    }

    public void LifetimeCounter()
    {
        // Day
        if (sunIntensity == 0 && newDay)
        {
            dayCounter += 1;
            newDay = false;
            Debug.Log(dayCounter);
        }

        // Month
        if (dayCounter == 31)
        {
            monthCounter += 1;
            dayCounter = 1;
        }

        // Year
        if (monthCounter == 13)
        {
            yearCounter += 1;
            monthCounter = 1;
        }
    }

    public void IntencityCycle()
    {
        sunIntensity = Mathf.Lerp(0, 1, t);
        t += Time.deltaTime / cycleSpeed;
        sunLight.intensity = sunIntensity;
    }
}
