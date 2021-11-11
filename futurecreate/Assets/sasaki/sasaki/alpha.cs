using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alpha : MonoBehaviour
{
    bool Alpha_black = true;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(Alpha_black)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.0f);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.6f);
        }
    }

    public void Alpha_Change(bool b)
    {
        Alpha_black = b;
        Debug.Log("‚­‚»‚Á‚½‚ê");

    }
}
