using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    // 敵の状態
    public enum ENEMY_TYPE
    {
        PATROL,     // 巡回
        VIGILANCE,  // 警戒
        TRACKING,   // 追跡
    }

    public Transform[] points;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;
    private bool discover;  //発見

    // 敵の状態変数
    private ENEMY_TYPE eType;

    //プレイヤーの情報を宣言
    NavMeshAgent Player_Nav;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの情報を取得
        //プレイヤーのNavMeshAgentを取得
        Player_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        //enemymove = GetComponent<Enemymove>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_hit();

        switch (eType)
        {
            case ENEMY_TYPE.PATROL:
                //敵の範囲に入ったら
                if (discover)
                {
                    GetComponent<Renderer>().material.color = Color.black;        //色を変える
                    GetComponent<NavMeshAgent>().isStopped = false;
                    Player_Nav.SetDestination(Player.transform.position);
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.red;        //色を変える

                    // エージェントが現目標地点に近づいてきたら、
                    // 次の目標地点を選択します
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                        GotoNextPoint();
                }
                break;

            case ENEMY_TYPE.VIGILANCE:
                break;

            case ENEMY_TYPE.TRACKING:
                break;
        }
    }

    //敵の範囲
    public void Enemy_hit()
    {
        Vector3 Enemy_position = this.transform.position;
        Vector3 Player_position = Player.transform.position;

        Vector3 hit;
        hit.x = Enemy_position.x - Player_position.x;
        hit.y = Enemy_position.y - Player_position.y;
        hit.z = Enemy_position.z - Player_position.z;

        if (hit.x * hit.x + hit.z * hit.z < 25)
            discover = true;
        else
            discover = false;
    }

    public bool GetDiscover()
    {
        return discover;
    }

    // ENEMY_TYPE
    public ENEMY_TYPE GetEnemyType()
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type)
    {
        eType = type;
    }
}