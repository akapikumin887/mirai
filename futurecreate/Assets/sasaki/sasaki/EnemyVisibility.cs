using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVisibility : MonoBehaviour
{

    NavMeshAgent Player_Nav;
    GameObject Player;
    GameObject GAMEMASTER;
    GameMng game_mng;



    Vector3 Enemy_forward_direction;
    Vector3 Player_direction;
    bool visibility_hit = false;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // 目的地のオブジェクトを取得
        Player = game_mng.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------------------------------------------------------
        //ベクトルの宣言（せってい）
        Enemy_forward_direction = this.transform.forward;//敵の正面ベクトルを取得
        Player_direction = (Player.transform.position - this.transform.position).normalized;     // プレイヤーの方向ベクトル

        if (light_visibility(Enemy_forward_direction, Player_direction, 6.0f, 0.4f))
        {
            if (hit.collider.tag == "Player")   //プレイヤーまで障害物がないとき
            {
                this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemyの行動パターンの変更　パトロールのパターンに変更
                this.GetComponent<Enemy>().SetDestination(Player.transform.position);
                Debug.Log("見つかった");
                return;
            }
        }
        else
        {
            if (this.GetComponent<Enemy>().GetEnemyType() != Enemy.ENEMY_TYPE.PEPPER)
            {
                this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            }
        }

        {         ////敵の視界の設定
                  //float dot = Vector3.Dot(Enemy_forward_direction, Player_direction);     //敵の前方ベクトルとプレイヤー方向とのベクトルの内積計算
                  //if (dot > 0.4f)     //内積
                  //{
                  //    //Rayのせってい　壁かどうか判定するため
                  //    RaycastHit hit;

            //    if (Physics.Raycast(this.transform.position, Player_direction , out hit, 6.0f))     //Rayにあたるものがあった時  最後の引数が距離
            //    {
            //        if (hit.collider.tag == "Player")   //プレイヤーまで障害物がないとき
            //        {
            //            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemyの行動パターンの変更　パトロールのパターンに変更
            //            this.GetComponent<Enemy>().SetDestination(Player.transform.position);
            //            return;
            //        }
            //    }

            //}
            //if(this.GetComponent<Enemy>().GetEnemyType() != Enemy.ENEMY_TYPE.PEPPER)
            //{
            //    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            //}
        }

    }

    bool light_visibility(Vector3 vector3, Vector3 vector3_player, float kyori, float hanni)
    {
        //敵の視界の設定
        float dot = Vector3.Dot(vector3, vector3_player);     //敵の前方ベクトルとプレイヤー方向とのベクトルの内積計算
        if (dot > hanni)     //内積
        {
            if (Physics.Raycast(this.transform.position, vector3_player, out hit, kyori))     //Rayにあたるものがあった時  最後の引数が距離
            {
                visibility_hit = true;      //当たってる判定
            }
        }
        else
        {
            visibility_hit = false;
        }
        return visibility_hit;
    }
}
