using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alpha : MonoBehaviour
{
    bool Alpha_black = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Alpha_black)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.6f);
        }
        else
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.0f);
        }
    }

    public void Alpha_Change(bool b)
    {
        Alpha_black = b;
    }
}
