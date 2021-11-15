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
        PEPPER,     // ペッパー
    }

    // 敵の状態変数
    private ENEMY_TYPE eType;

    public Transform[] points;
    private NavMeshAgent agent;
    // 次の目的地
    [SerializeField] int destPoint = 0;

    // GameManager変数
    GameObject GAMEMASTER;
    GameMng game_mng;

    // 追跡中目的地
    Vector3 Destination;

    void Start()
    {
        // GameManager取得
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // 追跡中目的地初期化
        Destination = this.transform.position;

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
                agent.speed = 1.5f;    // 移動速度1.5
                // 現目的地に近づいたら次の目的地を選択
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;

            case ENEMY_TYPE.VIGILANCE: // 警戒
                break;

            case ENEMY_TYPE.TRACKING: // 発見
                GetComponent<Renderer>().material.color = Color.black; //色を変える
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.speed = 2.0f;    // 移動速度2.0
                agent.SetDestination(Destination);
                break;

            case ENEMY_TYPE.PEPPER: // ペッパー
                GetComponent<Renderer>().material.color = Color.blue; //色を変える
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(Destination);
                break;
        }
    }

    // 現在の状態(ENEMY_TYPE)
    public ENEMY_TYPE GetEnemyType() // 取得
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type) // 変更
    {
        eType = type;
    }

    // agent
    public NavMeshAgent GetAgent() // ゲッター
    {
        return agent;
    }
    public void SetAgent(NavMeshAgent agentType) // セッター
    {
        agent = agentType;
    }

    // Destination
    public void SetDestination(Vector3 destination) // セッター
    {
        Destination = destination;
    }
}