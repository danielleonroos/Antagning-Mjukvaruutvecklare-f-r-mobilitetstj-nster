using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUI : MonoBehaviour
{
    public GameObject notAllowed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            notAllowed.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            notAllowed.SetActive(false);
        }
    }
}
