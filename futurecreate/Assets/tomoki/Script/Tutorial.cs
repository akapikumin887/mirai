using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    private GameObject Image1;
    private GameObject Image2;
    private int num;
    void Start()
    {
        Image1 = transform.GetChild(0).gameObject;
        Image2 = transform.GetChild(1).gameObject;
        num = 0;
    }

    void Update()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame ||
           Keyboard.current.aKey.wasPressedThisFrame ||
           Keyboard.current.rightArrowKey.wasPressedThisFrame ||
           Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            if (num == 0)
            {
                Image1.SetActive(false);
                Image2.SetActive(true);
            }
            else if (num == 1)
            {
                Image2.SetActive(false);
                scene_manager.FadeOut(2);
            }
            num++;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (num == 0)
            {
                Image1.SetActive(false);
                Image2.SetActive(true);
            }
            else if (num == 1)
            {
                Image2.SetActive(false);
                scene_manager.FadeOut(2);
            }
            num++;
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftStick.ReadValue().x != 0.0f)
            {
                if (num == 0)
                {
                    Image1.SetActive(false);
                    Image2.SetActive(true);
                }
                else if (num == 1)
                {
                    Image2.SetActive(false);
                    scene_manager.FadeOut(2);
                }
                num++;
            }

            if (Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                if (num == 0)
                {
                    Image1.SetActive(false);
                    Image2.SetActive(true);
                }
                else if (num == 1)
                {
                    Image2.SetActive(false);
                    scene_manager.FadeOut(2);
                }
                num++;
            }
        }
    }
}
