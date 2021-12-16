using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public enum RotateStyle
    {
        Normal = 0,
        Trigo,
    }
    public RotateStyle rotStyle;

    [SerializeField] float rotSpd = 360.0f;
    [SerializeField] float rotSpdAct = 30.0f;
    

    // Update is called once per frame
    void Update()
    {
        if(rotStyle == RotateStyle.Trigo)
        {
            SetRotSpdTorigo();
        }
        Rot();
    }

    //rotSpd•ª‰ñ‚·/s
    private void Rot()
    {
        transform.Rotate(0f, 0f, rotSpd * Time.deltaTime);
    }

    private void SetRotSpdTorigo()
    {
        rotSpd = Mathf.Cos(Time.deltaTime * rotSpdAct);
       
    }
}
