using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clockget : MonoBehaviour
{
    [SerializeField] private int _clockNum;
    [SerializeField] private GameObject notificationUI;
    [SerializeField] private GameObject clockUI;
    [SerializeField] private GameObject findUI;
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
        if (other.CompareTag("Player"))
        {
            //UI�̕\��


            //clock����������A�C�e������
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                //_Script._clocks[_clockNum] = true;
                Notification nof = notificationUI.GetComponent<Notification>();

                switch (_clockNum)
                {
                    case 0:
                        nof.CallNotification("�Ј��p�J�[�h�L�[����肵��");
                        var clockChange = clockUI.GetComponent<spritchange>();
                        //clockChange.GetCardclock();

                        //�ŏ��̃J�M����肵����G�𐶐�����
                        _Script.AddEnemyVisibility(new Vector3(50.0f, 0.5f, 41.0f));
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }

                ////�I�u�W�F�N�g�̐F��ԂɕύX����
                //GetComponent<Renderer>().material.color = Color.red;
            }

        }
    }
}
