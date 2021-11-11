using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(Time.timeScale==0)
            {
                GetComponent<alpha>().Alpha_Change(true);
                Time.timeScale = 1;
            }
            else
            {
                GetComponent<alpha>().Alpha_Change(false);
                Time.timeScale = 0;
            }
        }
    }


}
