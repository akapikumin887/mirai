using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class MenuController : MonoBehaviour
{
    private GameObject main;
    private Animator main_anim;
    private GameObject controller;
    private Animator controller_anim;
    private GameObject window;
    private Animator window_anim;
    private GameObject window2;
    private Animator window2_anim;
    private GameObject audio;
    private Animator audio_anim;

    bool flag=false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        main = this.transform.GetChild(0).GetChild(6).gameObject;
        main_anim = main.GetComponent<Animator>();

        controller = this.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        controller_anim = controller.GetComponent<Animator>();

        window = this.transform.GetChild(0).GetChild(3).gameObject;
        window_anim = window.GetComponent<Animator>();

        window2 = this.transform.GetChild(0).GetChild(4).gameObject;
        window2_anim = window2.GetComponent<Animator>();

        audio = this.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        audio_anim = audio.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Gamepad.current.startButton.isPressed)
        {
            main_anim.SetBool("Open", true);
        }
        if (SceneManager.GetActiveScene().name == "game"&&!flag)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            flag = true;
        }
    }

 

  

    
}
