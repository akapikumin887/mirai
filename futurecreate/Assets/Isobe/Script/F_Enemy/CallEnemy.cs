using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    [SerializeField] float WarningDistance;
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject GAMEMASTER;
    private GameObject Player;
    private bool flag=true;
    
    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        Player = GAMEMASTER.GetComponent<GameMng>().GetPlayer(); 
        enemy_list = GAMEMASTER.GetComponent<GameMng>().GetEnemy();//実際にはここでEnemyManagerからEnemyのリストを取得
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        Debug.Log(distance);

        if (distance<WarningDistance)//プレイヤーが範囲内に入ったら
        {
            if (flag)
            {
                foreach (var item in enemy_list)
                {
                    item.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PEPPER); //Enemyのステートを変更
                    item.GetComponent<Enemy>().SetDestination(this.transform.position);//Enemyを呼ぶ(目的地設定)
                }
                flag = false;
            }
        }
        else
        {
            flag= true;
        }
    }
}
