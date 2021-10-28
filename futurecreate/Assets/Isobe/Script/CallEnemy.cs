using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject enemys;
    // Start is called before the first frame update
    void Start()
    {
        enemy_list = enemys.GetComponent<EnemyManager>().GetEnemy();//実際にはここでEnemyManagerからEnemyのリストを取得
       
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//プレイヤーが範囲内に入ったら
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
