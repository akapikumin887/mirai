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

    // 目的地の格納場所(0はプレイヤーの場所)
    public Transform[] points;

    private NavMeshAgent agent;

    // 足跡プレハブ格納場所
    public GameObject footPrint_L;
    public GameObject footPrint_R;

    // 足跡生成フレーム管理
    private uint frame;
    // 足跡生成間隔
    public uint frameCount;
    // 左右管理(trueで右falseで左)
    private bool footPrint_RoL;
    // 足跡の生成場所-----------------------------------------------------------------------------------
    private Vector3 footPrintPotision;
    // 足跡の生成角度
    private Quaternion footPrintAngle;

    // 次の目的地
    [SerializeField] int destPoint = 1;
    // プレイヤーの位置
    [SerializeField] int playerPoint = 0;

    // GameManager変数
    GameObject GAMEMASTER;
    GameMng game_mng;

    // 追跡中の目的地
    Vector3 Destination;

    // プレイヤーへのパス
    NavMeshPath playerPath = null;

    void Start()
    {
        // GameManager取得
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // 追跡中の目的地初期化
        Destination = this.transform.position;

        agent = GetComponent<NavMeshAgent>();

        // autoBrakingを無効にすると目的地に近づいても速度が落ちない
        agent.autoBraking = false;

        // 足跡生成フレーム初期化
        frame = 0;
        // 右足跡から生成
        footPrint_RoL = true;
        // 足跡生成場所初期化-------------------------------------------------------------------------
        footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
        // 足跡生成角度初期化
        footPrintAngle = Quaternion.Euler(this.transform.localEulerAngles.x + 90.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 90.0f);

        // プレイヤーへのパス初期化
        playerPath = new NavMeshPath();

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
        // 必要ならば出発地点(1)に戻る
        destPoint = (destPoint + 1) % (points.Length);
        if (destPoint == 0)
            destPoint = 1;
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
                // 現目的地に近づいたら次の目的地を選択
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                    SetEnemyType(ENEMY_TYPE.PATROL);
                }
                break;
        }

        frame++;

        // 足跡生成--------------------------------------------------------------------------------
        if (frame > frameCount)//Δtime追加する
        {
            if (footPrint_RoL)
            {
                // 右足跡
                footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - 0.2f);
                Instantiate(footPrint_R, footPrintPotision, footPrintAngle);
                footPrint_RoL = false;
            }
            else
            {
                // 左足跡
                footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z + 0.2f);
                Instantiate(footPrint_L, footPrintPotision, footPrintAngle);
                footPrint_RoL = true;
            }
            frame = 0;
        }

        // プレイヤーへのパス計算
        NavMesh.CalculatePath(transform.position, points[playerPoint].position, NavMesh.AllAreas, playerPath);
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

    // プレイヤーの情報(points[playerPoint])
    public Transform GetPlayerPoint()
    {
        return points[playerPoint];
    }

    // プレイヤーへのパス取得(playerPath)
    public NavMeshPath GetToPlayerPath()
    {
        return playerPath;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            game_mng.SetGameOver(true);
        }
    }
}