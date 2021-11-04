using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 敵の状態
    public enum ENEMY_TYPE
    {
        PATROL,     // 巡回
        VIGILANCE,  // 警戒
        TRACKING,   // 追跡
    }

    // 敵の状態変数
    private ENEMY_TYPE eType;

    public Transform[] points;
    private NavMeshAgent agent;
    // 次の目的地
    [SerializeField] int destPoint = 0;

    //プレイヤーの情報を宣言
    GameObject Player;

    GameObject GAMEMASTER;
    GameMng game_mng;

    void Start()
    {
        GAMEMASTER = GameObject.Find("GameMng");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // 目的地のオブジェクトを取得
        Player = game_mng.GetPlayer();

        agent = GetComponent<NavMeshAgent>();

        // autoBrakingを無効にすると目的地に近づいても速度が落ちない
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返す
        if (points.Length == 0)
            return;

        // 現在設定された目的地に行くように設定
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目的地に設定し
        // 必要ならば出発地点に戻る
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        switch (eType)
        {
            case ENEMY_TYPE.PATROL: // 巡回
                GetComponent<Renderer>().material.color = Color.red; //色を変える
                // 現目的地に近づいたら次の目的地を選択
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;

            case ENEMY_TYPE.VIGILANCE: // 警戒
                break;

            case ENEMY_TYPE.TRACKING: // 発見
                GetComponent<Renderer>().material.color = Color.black; //色を変える
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(Player.transform.position);
                break;
        }
    }

    // ENEMY_TYPE
    public ENEMY_TYPE GetEnemyType() // ゲッター
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type) // セッター
    {
        eType = type;
    }

    // agent
    public NavMeshAgent GetAgent() // ゲッター
    {
        return agent;
    }
}