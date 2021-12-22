using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class key : MonoBehaviour
{
    [SerializeField] private int _KeyNum;
    [SerializeField] private GameObject notificationUI;
    [SerializeField] private GameObject keyUI;
    [SerializeField] private GameObject findUI;

    [SerializeField] private GameObject enemyPoints;
    [SerializeField] private GameObject denger;
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


            //key����������A�C�e������
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this.gameObject);
                _Script._Keys[_KeyNum] = true;
                Notification nof = notificationUI.GetComponent<Notification>();

                switch (_KeyNum)
                {
                    case 0:
                        nof.CallNotification("�Ј��p�J�[�h�L�[����肵��");
                        var keyChange = keyUI.GetComponent<spritchange>();
                        keyChange.GetCardKey();

                        //�ŏ��̃J�M����肵����G�𐶐�����
                        var enemy = _Script.AddEnemyVisibility(new Vector3(50.0f, 0.5f, 41.0f));
                        var enemyScript = enemy.GetComponent<Enemy>();

                        var dengerScript = denger.GetComponent<Danger>();
                        dengerScript.AddPathList(enemyScript.playerPath);

                        enemyScript.points.Add(_Script._Pleyer.transform);

                        var objs = enemyPoints.GetComponentsInChildren<Transform>();
                        foreach (var obj in objs)
                            enemyScript.points.Add(obj);


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
