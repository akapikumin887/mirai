using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Select_Game : MonoBehaviour
{
    private GameObject A;
    private GameObject B;
    [SerializeField] int game_scene;
    [SerializeField] int title_scene;
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
           Keyboard.current.downArrowKey.wasPressedThisFrame
           )
        {
            A.SetActive(!A.activeSelf);
            B.SetActive(!B.activeSelf);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (A.activeSelf)
            {
                scene_manager.FadeOut(game_scene);
            }
            else if (B.activeSelf)
            {
                scene_manager.FadeOut(title_scene);
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftStick.ReadValue().y == 0.0f)
            {
                A.SetActive(!A.activeSelf);
                B.SetActive(!B.activeSelf);
            }

            if (Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                if (A.activeSelf)
                {
                    scene_manager.FadeOut(game_scene);
                }
                else if (B.activeSelf)
                {
                    scene_manager.FadeOut(title_scene);
                }
            }
        }
    }
}
