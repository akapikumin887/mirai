using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVisibility : MonoBehaviour
{

    NavMeshAgent Player_Nav;
    GameObject Player;

    // ENEMY_TYPE eNEMY_TYPE;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        Player_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        //ベクトルの宣言（せってい）
        Vector3 Enemy_forward_direction = this.transform.forward;//敵の正面ベクトルを取得
        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;     // プレイヤーの方向ベクトル

        //敵の視界の設定
        float dot = Vector3.Dot(Enemy_forward_direction, Player_direction);     //敵の前方ベクトルとプレイヤー方向とのベクトルの内積計算
        if (dot > 0.4f)     //内積
        {
            //Rayのせってい　壁かどうか判定するため
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, Player_direction, out hit, Mathf.Infinity))     //Rayにあたるものがあった時
            {
                if (hit.collider.tag == "wall")      //間に壁があるとき
                {
                    GetComponent<Renderer>().material.color = Color.blue;
                    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                    //GetComponent<NavMeshAgent>().isStopped = true;

                }
                if (hit.collider.tag == "Player")   //プレイヤーまで障害物がないとき
                {
                    GetComponent<Renderer>().material.color = Color.black;        //色を変える
                                                                                  //  GetComponent<NavMeshAgent>().isStopped = false;               //ナビゲーションを使う
                    Debug.Log("追っかけるよー");
                    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemyの行動パターンの変更　パトロールのパターンに変更

                    Player_Nav.SetDestination(Player.transform.position);       //ナビゲーションの目標座標 SetEnemyType(ENEMY_TYPE type)を呼び出す処理に変える
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.blue;
                this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                //GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            //GetComponent<NavMeshAgent>().isStopped = true;

        }

        //Debug.Log(Enemy_forward_direction);
        //------------------------------------------------------------------------------------------



        ////範囲に入ったらtrueを返す
        //public bool Enemy_hit()
        //{
        //    Vector3 Enemy_position = this.transform.position;
        //    Vector3 Player_position = Player.transform.position;

        //    Vector3 hit;
        //    hit.x = Enemy_position.x - Player_position.x;
        //    hit.y = Enemy_position.y - Player_position.y;
        //    hit.z = Enemy_position.z - Player_position.z;

        //    if (hit.x * hit.x + hit.y * hit.y < 50)
        //        return true;
        //    else
        //        return false;
        //}



    }
}
