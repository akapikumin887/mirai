using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Select_Game : MonoBehaviour
{
    private GameObject A;
    private GameObject B;
    // Start is called before the first frame update
    void Start()
    {
        A = transform.GetChild(0).gameObject;
        B = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.wKey.wasPressedThisFrame||
           Keyboard.current.sKey.wasPressedThisFrame||
           Keyboard.current.upArrowKey.wasPressedThisFrame||
           Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            A.SetActive(!A.activeSelf);
            B.SetActive(!B.activeSelf);
        }
    }
}
