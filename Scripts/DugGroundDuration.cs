using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DugGroundDuration : MonoBehaviour
{
    [SerializeField] private Color showColor;
    [SerializeField] private Color fadeColor;

    private Renderer renderer;

    public bool hide;

    public GameObject parent;
    public float duration = 1f;
    private float t = 0;

    // Start is called before the first frame update
    void Awake()
    {
        parent = transform.parent.gameObject;
        renderer = GetComponent<Renderer>();
        showColor = renderer.material.color;
        fadeColor = renderer.material.color;
        fadeColor.a = 0f;

        StartCoroutine("Duration");
    }

    // Update is called once per frame
    void Update()
    {
        if (hide)
        {
            Debug.Log("Hiding");
            renderer.material.color = Color.Lerp(showColor, fadeColor, t);
            t += Time.deltaTime / duration;
            if (renderer.material.color.a <= fadeColor.a)
            {
                hide = false;
                t = 0;
            }
        }
    }


    IEnumerator Duration()
    {
        yield return new WaitForSeconds(60);
        hide = true;
        yield return new WaitForSeconds(duration);
        Destroy(parent);
    }
}
