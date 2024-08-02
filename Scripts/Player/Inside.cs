using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inside : MonoBehaviour
{
    public Renderer roofRenderer;

    public Color startColor;
    public Color fadeColor;

    public float fadeSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Roof")
        {
            roofRenderer = other.gameObject.GetComponent<Renderer>();

            startColor = roofRenderer.material.color;
            fadeColor = roofRenderer.material.color;

            fadeColor.a = 0f;

            roofRenderer.material.color = Color.Lerp(startColor, fadeColor, fadeSpeed * Time.deltaTime);

            Debug.Log(startColor.a);

        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Roof")
        {

           // roofRenderer.material.color = fadeColor;
            StartCoroutine("Show");
        }
    }

    IEnumerator Show()
    {
        while (roofRenderer.material.color.a <= 1f)
        {
            fadeColor.a = 1f;
            roofRenderer.material.color = Color.Lerp(startColor, fadeColor, fadeSpeed * Time.deltaTime);

            Debug.Log(startColor.a);

            yield return null;
        }
    }
}
