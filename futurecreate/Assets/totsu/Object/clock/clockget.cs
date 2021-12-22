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
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //UIの表示


            //clockを押したらアイテム入手
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                //_Script._clocks[_clockNum] = true;
                Notification nof = notificationUI.GetComponent<Notification>();

                switch (_clockNum)
                {
                    case 0:
                        nof.CallNotification("社員用カードキーを入手した");
                        var clockChange = clockUI.GetComponent<spritchange>();
                        //clockChange.GetCardclock();

                        //最初のカギを入手したら敵を生成する
                        _Script.AddEnemyVisibility(new Vector3(50.0f, 0.5f, 41.0f));
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }

                ////オブジェクトの色を赤に変更する
                //GetComponent<Renderer>().material.color = Color.red;
            }

        }
    }
}
