using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Light light;
    public void Start()
    {
        light = this.GetComponent<Light>();
    }
    public void SetFlashLight(bool flag)
    {
        light.enabled = flag;
    }
}
