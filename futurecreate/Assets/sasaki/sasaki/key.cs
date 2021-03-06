using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class key : MonoBehaviour
{
    [SerializeField] private int _KeyNum;
    [SerializeField] private GameObject notificationUI;
    [SerializeField] private GameObject keyUI;

    [SerializeField] private GameObject enemyPoints1;

    GameMng _Script;
    ItemUI _ItemUI;

    bool me;

    void Start()
    {
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _ItemUI = _Script._Pleyer.transform.GetChild(5).GetComponent<ItemUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (me)
        {
            //keyを押したらアイテム入手
            if (Input.GetKeyDown(KeyCode.Space) || Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                Destroy(this.gameObject);
                _Script._Keys[_KeyNum] = true;
                Notification nof = notificationUI.GetComponent<Notification>();

                _ItemUI._IsDraw = false;

                GameObject enemy = null;

                switch (_KeyNum)
                {
                    case 0:
                        nof.CallNotification("社員用のカードキーを入手した");

                        enemy = _Script.AddEnemyVisibility(new Vector3(50.0f, 0.5f, 41.0f));
                        AddEnemy(enemy, enemyPoints1);
                        break;

                    case 1:
                        nof.CallNotification("上司用のカードキーを入手した");

                        enemy = _Script.AddEnemyVisibility(new Vector3(-11.0f, 0.5f, 41.2f));
                        AddEnemy(enemy, enemyPoints1);
                        enemy = _Script.AddEnemyListen(new Vector3(50.0f, 0.5f, 101.5f));
                        AddEnemy(enemy, enemyPoints1);
                        break;
                    case 2:
                        nof.CallNotification("研究室のカードキーを入手した");

                        break;

                    case 3:
                        nof.CallNotification("所長のカードキー　を入手した");

                        break;
                }

                spritchange key = keyUI.GetComponent<spritchange>();
                key.GetCardKey();

            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //UIの表示
            _ItemUI._IsDraw = true;
            me = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
        me = false;
    }

    private void AddEnemy(GameObject enemy, GameObject point)
    {
        Enemy script = enemy.GetComponent<Enemy>();
        script.points.Add(_Script._Pleyer.transform);

        var objs = point.GetComponentsInChildren<Transform>();
        foreach (var obj in objs)
        {
            if (!(obj.transform.position == new Vector3(0.0f, 0.0f, 0.0f)))
                script.points.Add(obj);
        }

        script.eType = Enemy.ENEMY_TYPE.NULL;
        script.GotoNextPoint();
    }

}