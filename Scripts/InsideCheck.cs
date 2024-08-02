using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCheck : MonoBehaviour
{
    [SerializeField] private Color showColor;
    [SerializeField] private Color fadeColor;

    private Renderer roofRenderer;

    private bool hide = false;
    private bool show = false;


    [Range(0, 1)]
    public float transparentLevel = 0;

    public float duration = 0.5f;
    private float t = 0;

    private void Awake()
    {
        roofRenderer = GetComponent<Renderer>();
        showColor = roofRenderer.material.color;
        fadeColor = roofRenderer.material.color;
    }

    void Update()
    {
        fadeColor.a = transparentLevel;

        if (hide)
        {
            roofRenderer.material.color = Color.Lerp(showColor, fadeColor, t);
            t += Time.deltaTime / duration;
            if (roofRenderer.material.color.a <= fadeColor.a)
            {
                hide = false;
                t = 0;
            }
        }

        if (show)
        {
            roofRenderer.material.color = Color.Lerp(showColor, fadeColor, duration - t);
            t += Time.deltaTime / duration;
            if (roofRenderer.material.color.a >= showColor.a)
            {
                show = false;
                t = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hide = true;
            show = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hide = false;
            show = true;
        }
    }
}
