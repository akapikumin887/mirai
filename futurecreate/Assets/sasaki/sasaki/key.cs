using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class key : MonoBehaviour
{
    [SerializeField] private int _KeyNum;
    GameMng _Script;

    void Start()
    {
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        //�ڐG���Ă���I�u�W�F�N�g�̃^�O��"Player"�̂Ƃ�
        if(Input.GetKey(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                _Script._Keys[_KeyNum] = true;
                ////�I�u�W�F�N�g�̐F��ԂɕύX����
                //GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
