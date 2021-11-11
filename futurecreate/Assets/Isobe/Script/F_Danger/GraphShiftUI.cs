using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphShiftUI : MonoBehaviour
{
    private UIPolygon uipol;
    private float time;
    private byte red;
   [SerializeField] float timelimit;
    // Start is called before the first frame update
    void Start()
    {
        uipol = this.GetComponent<UIPolygon>();
        //Color color=(0.5,0.5,0.5);
        
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    
        if (time>timelimit) {
            red+=5;
            if (red > 255) red = 0;
            uipol.color = new Color32(red, 179, 255, 255);
            for (int i = 0; i < uipol.Sides; i++)
            {
                if (i % 2 == 0)
                {
                    float random = Random.Range(0.4f, 0.5f);
                    uipol.SetDistance(random, i);
                }
                else
                {
                    float random = Random.Range(0.5f, 1.0f);
                    uipol.SetDistance(random, i);
                }
            }
            time = 0;
        }
    }
}
