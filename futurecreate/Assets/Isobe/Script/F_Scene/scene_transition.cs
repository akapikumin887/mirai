using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scene_transition : MonoBehaviour
{
    [SerializeField] int num;

   
    void Start()
    {
      
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Gamepad.current.buttonEast.wasPressedThisFrame)
        {
           scene_manager.FadeOut(num);
        }
    }

    public void SceneGame()
    {
        scene_manager.FadeOut(num);
    }
}
