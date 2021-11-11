using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    alpha m_alpha;

    // Start is called before the first frame update
    void Start()
    {
        m_alpha = GetComponent<alpha>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(Time.timeScale==0)
            {
                m_alpha.Alpha_Change(true);
                Time.timeScale = 1;
            }
            else
            {
                m_alpha.Alpha_Change(false);
                Time.timeScale = 0;
            }
        }
    }


}
