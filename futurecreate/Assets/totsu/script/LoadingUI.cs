using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public enum RotateStyle
    {
        Normal = 0,
        Trigo,
        Irregular
    }
    public RotateStyle rotStyle = RotateStyle.Normal;

    [SerializeField] float rotSpd = 360.0f;
    [SerializeField] float rotSpdAct = 30.0f;

    float rotSpdInit;
    [SerializeField] float timeAct = 30.0f;
    private float time;

    private void Start()
    {
        rotSpdInit = rotSpd;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotStyle == RotateStyle.Normal)
        {
            Rot();
        }
        else if (rotStyle == RotateStyle.Trigo)
        {
            RotTrigo();
        }
        else if (rotStyle == RotateStyle.Irregular)
        {
            RotTrigo();
        }
    }

    //rotSpd•ª‰ñ‚·/s
    private void Rot()
    {
        transform.Rotate(0f, 0f, rotSpd * Time.deltaTime);
    }

    private void RotTrigo()
    {
        time += Time.deltaTime * timeAct;
        rotSpd = Mathf.Cos(time) * rotSpdAct + rotSpdInit;
        //transform.Rotate(0f, 0f, rotSpd * Time.deltaTime);
        transform.Rotate(0f, 0f, rotSpd * Time.deltaTime);
    }

    private void RotIrregular()
    {
        time += Time.deltaTime;
        rotSpd = Mathf.Cos(time) /** rotSpdAct*/;
        //transform.Rotate(0f, 0f, rotSpd * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotSpd));
    }

    public void SetRotSpd(float spd)
    {
        rotSpd = spd;
    }
}
