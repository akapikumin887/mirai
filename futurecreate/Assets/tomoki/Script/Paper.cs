using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject notificationUI;

    private bool _IsLook;

    GameMng _Script;
    ItemUI _ItemUI;


    void Start()
    {
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _ItemUI = _Script._Pleyer.transform.GetChild(5).GetComponent<ItemUI>();
    }

    void Update()
    {
        if (_IsLook)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _IsLook = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_IsLook)
        {
            //UIの表示
            _ItemUI._IsDraw = true;

            //keyを押したらアイテム入手
            if (Input.GetKey(KeyCode.Space))
            {


                _IsLook = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
    }
}
