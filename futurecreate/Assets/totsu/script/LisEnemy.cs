using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
    //[SerializeField] GameObject pin;    //ピン


    public enum State   //状態
    {
        Patrol = 0,
        Chase,

    };
    public State state = State.Patrol;

    Vector3 GoalPos;

    //NavMeshAgent Player_Nav;
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのNavMeshAgentを取得
        //Player_Nav = GetComponent<NavMeshAgent>();

        //プレイヤーを取得
        var mng = GameObject.FindGameObjectWithTag("Manager");
        
        if (mng != null)
        {
            var mngScript = mng.GetComponent<GameMng>();
            if (mngScript != null)
            {
                //Player = mngScript.GetPlayer();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter(Collider other)
    {
        //足音を検知
        if (other.gameObject.tag == "footsteps")
        {
            Debug.Log("足音検知");
            //追っかけモードにする
            //GetComponent<Renderer>().material.color = Color.red;
            state = State.Chase;

            Debug.Log("追っかけ");
            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);

            //目指す座標設定
            this.GetComponent<Enemy>().SetDestination(other.transform.position);

            //追跡解除地点を設定
            GoalPos = other.transform.position;


            //Instantiate(pin, other.transform.position, Quaternion.identity);

        }
      

        //if (other.gameObject.tag == "pin")
        //{
        //    Debug.Log("目標地点到達");
        //    //巡回モードにする
        //    GetComponent<Renderer>().material.color = Color.white;
        //    state = State.Patrol;

        //    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
        
        //}
    }

    void StateAct()
    {
        if (state == State.Patrol)
        {
            //GetComponent<Renderer>().material.color = Color.white;
        }
        else if (state == State.Chase)
        {
            if (Vector3.Distance(transform.position, GoalPos) <= 0.1f)
            {
                Debug.Log("目標地点到達");
                //巡回モードにする
                //GetComponent<Renderer>().material.color = Color.white;
                state = State.Patrol;

                this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            }
        }
    }

    public State GetState()
    {
        return state;
    }

    //パトロール状態に戻す
    public void SetPatrol()
    {
        state = State.Patrol;
    }
}
