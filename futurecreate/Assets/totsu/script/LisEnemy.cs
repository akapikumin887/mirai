using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
    //[SerializeField] GameObject pin;    //ピン
    private List<GameObject> Sound_list = new List<GameObject>();
    private List<String> Tag_list = new List<String>();

    public enum State   //状態
    {
        Patrol = 0,
        Chase,

    };
    public State state = State.Patrol;

    

    Vector3 GoalPos;

    //NavMeshAgent Player_Nav;
    [SerializeField] GameObject Player;


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
                Player = mngScript.GetPlayer();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StateAct();
    }



    void OnTriggerEnter(Collider other)
    {
        //足音を検知
        if (other.gameObject.tag == "footsteps")
        {
            //Debug.Log("足音検知");
            ////追っかけモードにする
            //SetTracking();

            ////追跡解除地点を設定
            //GoalPos = other.transform.position;

            ////目指す座標設定
            //this.GetComponent<Enemy>().SetDestination(GoalPos);



            //Instantiate(pin, other.transform.position, Quaternion.identity);

        }


        Sound_list.Add(other.gameObject);
        //Tag_list.Add(other.gameObject.tag);

       
    }

    void SelectTarget()
    {
        if (Sound_list.Count != 0)
        {
            for (int i = 0; i < Sound_list.Count; i++)
            {
                Tag_list.Add(Sound_list[i].gameObject.tag);
            }
        }

        //優先順位順に繰り返す
        string item;

        item = "Bell";
        if (Tag_list.Contains(item))
        {
            SetTarget(item);
            return;
        }



        item = "footstep";
        if (Tag_list.Contains(item))
        {
            SetTracking(Player.transform.position);
            return;
        }

       

        //bool only_fs = true;   //足音のみ検知

        ////検知音が足音のみか判断
        //for(int i = 0; i < Sound_list.Count; i++)
        //{
        //    if(Sound_list[i].gameObject.tag != "footsteps")
        //    {
        //        only_fs = false;
        //        return;
        //    }
        //}

        //if (only_fs)
        //{
        //    Debug.Log("足音検知");

        //    SetTracking();

        //    //追跡解除地点を設定
        //    GoalPos = Sound_list[0].transform.position;

        //    //目指す座標設定
        //    this.GetComponent<Enemy>().SetDestination(GoalPos);


        //    return;
        //}
        //else
        //{
        //    List<float> Dis_list = new List<float>();

        //    for (int i = 0; i < Sound_list.Count; i++)
        //    {
        //        Dis_list.Add(
        //            Vector3.Distance(Sound_list[i].gameObject.transform.position, 
        //            this.transform.position));
        //    }

        //    Dis_list.Sort();

        //}


    }

    void SetTarget(String tag_name)
    {
        float dis = 0.0f;
        float befdis = 0.0f;
        int dis_count = 0;

        for (int i = 0; i < Sound_list.Count; i++)
        {
            if(Sound_list[i].gameObject.tag == tag_name)
            {
                dis = Vector3.Distance(
                    Sound_list[i].gameObject.transform.position,
                    this.transform.position);

                if(dis < befdis || befdis == 0)
                {
                    befdis = dis;
                    dis_count = i;
                }
            }
        }

        //最も近い地点を指定
        SetTracking(Sound_list[dis_count].transform.position);
        
    }

    void StateAct()
    {
        if (state == State.Patrol)
        {
            if (Sound_list.Count != 0)
            {
                SelectTarget();
            }
        }
        else if (state == State.Chase)
        {
            if (Vector3.Distance(transform.position, GoalPos) <= 0.1f)
            {
                Debug.Log("目標地点到達");
                //巡回モードにする
                SetPatrol();

                
                
            }
        }
    }

    public State GetState()
    {
        return state;
    }

    //追跡状態にする
    public void SetTracking(Vector3 pos)
    {
        //追っかけモードにする
        state = State.Chase;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);

        //追跡解除地点を設定
        GoalPos = pos;

        //目指す座標設定
        this.GetComponent<Enemy>().SetDestination(GoalPos);

        //サウンドリストとタグリストをリセット
        Sound_list.Clear();
        Tag_list.Clear();
    }

    //巡回状態にする
    public void SetPatrol() 
    {
        state = State.Patrol;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
    }
}
