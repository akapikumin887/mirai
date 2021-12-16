using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*=========================================================

    インスペクター

    Points:ルートに沿ったPointを入れる
         ただし、パスを取得するため0にはプレイヤーを入れる

    FootPrint_L,R:左右の足跡のプレハブを入れる

    frameCount:足跡の生成間隔を設定(秒)

=========================================================*/

public class Enemy : MonoBehaviour
{
    // NavMesh
    private NavMeshAgent agent;

    // GameManager変数
    private GameObject gameMaster;
    private GameMng gameManager;

    /*-----------------------
      敵の状態
    -----------------------*/
    public enum ENEMY_TYPE
    {
        PATROL,     // 巡回
        VIGILANCE,  // 警戒
        TRACKING,   // 追跡
        PEPPER,     // ペッパー(呼び寄せられてる)
    }
    // 現在の状態
    private ENEMY_TYPE eType;

    /*-----------------------
      目的地
    -----------------------*/
    [Header("Destination")]
    // 格納場所(0にプレイヤーの場所)
    public Transform[] points;
    // 次の目的地
    private int nextPoint = 1;
    // プレイヤーの位置
    private int playerPoint = 0;
    // 追跡中の目的地
    private Vector3 destination;
    // プレイヤーへのパス
    private NavMeshPath playerPath = null;

    /*-----------------------
      足跡
    -----------------------*/
    [Header("FootPrint")]
    // プレハブ格納場所
    public GameObject footPrint_L;
    public GameObject footPrint_R;
    // 生成フレーム管理
    private float frame;
    // 生成間隔(秒)
    public uint frameCount;
    // 左右管理(trueで右falseで左)
    private bool footPrint_RoL;
    // 生成場所
    private Vector3 footPrintPotision;
    // 生成角度
    private Quaternion footPrintAngle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // autoBrakingを無効にすると目的地に近づいても速度が落ちない
        agent.autoBraking = false;

        // GameManager取得
        gameMaster = GameObject.FindGameObjectWithTag("Manager");
        gameManager = gameMaster.GetComponent<GameMng>();

        // 追跡中の目的地初期化
        destination = this.transform.position;
        // プレイヤーへのパス初期化
        playerPath = new NavMeshPath();

        // 足跡生成フレーム初期化
        frame = 0;
        // 右足跡から生成
        footPrint_RoL = true;
        // 足跡生成角度初期化
        footPrintAngle = Quaternion.Euler(transform.localEulerAngles.x + 90.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);

        // 目的地に向かう
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返す
        if (points.Length == 0)
            return;

        // 現在設定された目的地に行くように設定
        agent.destination = points[nextPoint].position;

        // 配列内の次の位置を目的地に設定し
        // 必要ならば出発地点(1)に戻る
        nextPoint = (nextPoint + 1) % (points.Length);
        if (nextPoint == 0)
            nextPoint = 1;
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
                agent.SetDestination(destination);
                break;

            case ENEMY_TYPE.PEPPER: // ペッパー
                GetComponent<Renderer>().material.color = Color.blue; //色を変える
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(destination);
                // 現目的地に近づいたら次の目的地を選択
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                    SetEnemyType(ENEMY_TYPE.PATROL);
                }
                break;
        }

        frame += Time.deltaTime;

        // 足跡生成
        if (frame > frameCount)
        {
            // 角度調整
            footPrintAngle = Quaternion.Euler(this.transform.localEulerAngles.x + 90.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);

            if (footPrint_RoL)
            {
                // 右足跡
                footPrintPotision = this.transform.localPosition
                                    - transform.up * 0.49f    // 上下調整
                                    + transform.right * 0.2f; // 左右調整
                Instantiate(footPrint_R, footPrintPotision, footPrintAngle);
                footPrint_RoL = false;
            }
            else
            {
                // 左足跡
                footPrintPotision = this.transform.localPosition
                                    - transform.up * 0.49f
                                    - transform.right * 0.2f;
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

    // destination
    public void SetDestination(Vector3 dest) // セッター
    {
        destination = dest;
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
            gameManager.SetGameOver(true);
        }
    }
}