using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingGround : MonoBehaviour
{
    public GameObject dugGround;
    public GameObject farmObject;

    public Material standardMat;
    public Material highlightMat;

    public Animator animator;

    public float placeHeight;

    public bool isMarked;
    public bool canDig;

    private void Update()
    {
        Dig();
    }

    void Dig()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDig)
        {
            Instantiate(dugGround, new Vector3(farmObject.transform.position.x, placeHeight, farmObject.transform.position.z), Quaternion.identity);
            animator.SetBool("isDigging", true);
        }

        else
        {
            animator.SetBool("isDigging", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FarmingGround" && !isMarked)
        {
            farmObject = other.gameObject;
            isMarked = true;
            farmObject.GetComponent<Renderer>().material = highlightMat;
            canDig = true;
        }

        if (other.gameObject.tag == "DugGround")
        {
            canDig = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FarmingGround" && isMarked)
        {
            farmObject.GetComponent<Renderer>().material = standardMat;
            farmObject = null;
            isMarked = false;
        }
    }
}
