using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    private GameMng _GameManagerScript;

    private GameObject _DoorRight;
    private GameObject _DoorLeft;

    private bool _IsOpen = false;

    void Start()
    {
        _DoorRight = transform.GetChild(0).gameObject;
        _DoorLeft  = transform.GetChild(1).gameObject;

        var mng = GameObject.FindGameObjectWithTag("Manager");
        if (mng != null)
            _GameManagerScript = mng.GetComponent<GameMng>();
    }

    void Update()
    {
        if (_IsOpen)
        {
            //ŠJ‚¯‘±‚¯‚é

        }
        else
        {
            //•Â‚ß‘±‚¯‚é

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _IsOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _IsOpen = false;
    }
}
