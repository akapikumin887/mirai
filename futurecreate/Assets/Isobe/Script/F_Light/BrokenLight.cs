using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLight : MonoBehaviour
{
    private float alltime;
    // Start is called before the first frame update
    void Start()
    {
        alltime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        alltime += Time.deltaTime;
        if (alltime > 0.14f)
        {
            this.GetComponent<Light>().intensity = Random.Range(0.0f, 4.5f);
            alltime = 0.0f;
        }

    }
}
