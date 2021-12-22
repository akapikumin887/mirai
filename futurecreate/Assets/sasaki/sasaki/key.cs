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


            //keyを押したらアイテム入手
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this.gameObject);
                _Script._Keys[_KeyNum] = true;
                Notification nof = notificationUI.GetComponent<Notification>();

                switch (_KeyNum)
                {
                    case 0:
                        nof.CallNotification("社員用カードキーを入手した");
                        var keyChange = keyUI.GetComponent<spritchange>();
                        keyChange.GetCardKey();

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
