using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball") return;

        col.GetComponent<MeshRenderer>().enabled = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Ball") return;

        col.GetComponent<MeshRenderer>().enabled = false;
    }
}
