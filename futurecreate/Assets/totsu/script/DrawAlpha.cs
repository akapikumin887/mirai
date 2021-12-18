using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAlpha : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //Material m = other.GetComponent<Material>();
        //Color c = m.color;
        //c.a += 1.0f;
        //m.color = c;

        //other.material = m.color;

        other.GetComponent<Renderer>().material.color = new Vector4(1,1,1,1);
    }
}
