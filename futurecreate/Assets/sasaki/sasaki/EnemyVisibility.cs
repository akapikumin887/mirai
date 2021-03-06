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
    Enemy enemy;


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
        Player = game_mng._Pleyer;

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Enemy>().eType == Enemy.ENEMY_TYPE.NULL)
            return;

        //----------------------------------------------------------------------------------------
        //ベクトルの宣言（せってい）
        Enemy_forward_direction = transform.forward;//敵の正面ベクトルを取得
        //Enemy_forward_direction = new Vector3(Enemy_forward_direction.x * 100, Enemy_forward_direction.y, Enemy_forward_direction.z * 100);
        Player_direction = (Player.transform.position + new Vector3(0f, 0.5f, 0f) - this.transform.position).normalized;     // プレイヤーの方向ベクトル
                                                                                                                             //RaycastHit hit = new RaycastHit();

        Debug.DrawLine(transform.position, transform.position + Enemy_forward_direction * 100, Color.red);
        Debug.DrawLine(transform.position, transform.position + Player_direction * 100, Color.blue);

        //if (light_visibility(this.transform.position, Player.transform.position, Mathf.Infinity, 0.0f))
        //{

        //    if (hit.collider.tag == "wall")   //プレイヤーまで障害物がないとき
        //    {
        //        Debug.Log("かべがあったよ");
        //        return;
        //    }

        //}

        if (light_visibility(Enemy_forward_direction, Player_direction, 6.1f, 0.4f))
        {
            if (hit.collider == null)
                return;

            switch (enemy.eType)
            {
                case Enemy.ENEMY_TYPE.PATROL:
                    if (hit.collider.tag == "wall")
                        return;

                    //発見したら追跡開始
                    if (hit.collider.tag == "Player")
                        enemy.eType = Enemy.ENEMY_TYPE.TRACKING;

                    break;
                case Enemy.ENEMY_TYPE.TRACKING:
                    //見つけたプレイヤーの座標更新
                    Debug.Log("プレイヤーに当たったら");
                    if (hit.collider.tag == "Player")
                        enemy.destination = Player.transform.position;

                    //見失ったら追跡停止
                    if (Vector3.Distance(transform.position, enemy.destination) >= 0.2f)
                        enemy.eType = Enemy.ENEMY_TYPE.PATROL;

                    break;
            }
            //    if (hit.collider.tag == "wall")   //プレイヤーまで障害物がないとき
            //    {
            //        if (this.GetComponent<Enemy>().eType != Enemy.ENEMY_TYPE.PEPPER  || this.GetComponent<Enemy>().eType == Enemy.ENEMY_TYPE.TRACKING)
            //        {
            //            this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.PATROL;
            //            Debug.Log("壁を見つけたよ");
            //            return;
            //        }
            //    }
            //    else if (hit.collider.tag == "Player")
            //    {
            //        Debug.Log("視界に入ったよ");
            //        this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.TRACKING;
            //        this.GetComponent<Enemy>().destination = Player.transform.position;
            //    }
            //}
            //else
            //{
            //    if (this.GetComponent<Enemy>().eType != Enemy.ENEMY_TYPE.PEPPER)
            //    {
            //        //this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            //        this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.PATROL;
            //    }
            //}

            //{
            //    if (light_visibility(Enemy_forward_direction, Player_direction, 6.0f, 0.4f))
            //    {
            //        Debug.Log(hit.collider.tag);

            //        if (hit.collider.tag == "Player")   //プレイヤーまで障害物がないとき
            //        {
            //            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemyの行動パターンの変更　パトロールのパターンに変更
            //            this.GetComponent<Enemy>().SetDestination(Player.transform.position);
            //            Debug.Log("見つかった");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (this.GetComponent<Enemy>().GetEnemyType() != Enemy.ENEMY_TYPE.PEPPER)
            //        {
            //            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            //        }
            //    }
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
                Debug.Log("当たってる判定");
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
