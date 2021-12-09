using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_transition : MonoBehaviour
{
    [SerializeField] int num;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           scene_manager.FadeOut(num);
        }
    }
}
