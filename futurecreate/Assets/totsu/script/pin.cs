using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    GameObject LisEnemy;
    private void Start()
    {
        LisEnemy = GameObject.Find("LisEnemy");
    }

    private void Update()
    {
        if(LisEnemy != null)
        {
            if (Vector3.Distance(transform.position, LisEnemy.transform.position) <= 3.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
