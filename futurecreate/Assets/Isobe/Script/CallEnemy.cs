using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject GAMEMASTER;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_list = GAMEMASTER.GetComponent<GameMng>().GetEnemy();//実際にはここでEnemyManagerからEnemyのリストを取得
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        Debug.Log(distance);
        if (distance<7.5f)//プレイヤーが範囲内に入ったら
        {
            //Enemyのステートを変更
            foreach (var item in enemy_list)
            {
                item.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);
            }
            //Enemyを呼ぶ(目的地設定)
            foreach (var item in enemy_list)
            {
                item.GetComponent<NavMeshAgent>().SetDestination(this.transform.position);
            }
        } 
    }
}
