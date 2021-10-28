using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallEnemy : MonoBehaviour
{
    List<Enemy> enemy_list = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        enemy_list = enemy_list;//実際にはここでEnemyManagerからEnemyのリストを取得
        enemy_list.Add(this.GetComponent<Enemy>());
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//プレイヤーが範囲内に入ったら
        {
            //Enemyのステートを変更
            foreach (var item in enemy_list)
            {
                item.SetEnemyType((Enemy.ENEMY_TYPE)2);
            }
            //Enemyを呼ぶ(目的地設定)
            foreach (var item in enemy_list)
            {
                //item
            }
        } 
    }
}
