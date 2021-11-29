using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
//追跡関係=======================================================================
    
    //リスト系
    private List<GameObject> Sound_list = new List<GameObject>();
    private List<String> Tag_list = new List<String>();

    //敵の状態
    public enum State   
    {
        Patrol = 0,
        Chase,
    };
    public State state = State.Patrol;

    //目標座標
    private Vector3 GoalPos;

    //プレイヤーを追いかけフラグ
    private bool f_TrackingPlayer = false;

     //目標地点及びプレイヤーとの接触判定距離(※後でちゃんと決めること)
    [SerializeField] float TouchDis = 1.0f;

//取得関係=======================================================================
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

    private void LateUpdate()
    {
        //サウンドリストとタグリストをリセット
        Sound_list.Clear();
        Tag_list.Clear();

    }
    void StateAct()
    {
        if (state == State.Patrol)
        {
            if (Sound_list.Count != 0)
            {
                //SelectTarget();
            }
        }
        else if (state == State.Chase)
        {
            if (Vector3.Distance(transform.position, GoalPos) <= TouchDis)
            {
                //巡回モードにする
                SetPatrol();
                
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Sound_list.Add(other.gameObject);
        if (state == State.Patrol && Sound_list.Count != 0) 
        {
            SelectTarget();
        }
        else if(state == State.Chase && f_TrackingPlayer)
        {
            SetTracking(Player.transform.position);
        }
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
        else
        {
            return;
        }

        //優先順位順に繰り返す
        string item;

        item = "Bell";
        if (Tag_list.Contains(item))
        {
            SetTarget(item);
            return;
        }
        
        //プレイヤーを追いかける
        item = "footsteps";
        if (Tag_list.Contains(item))
        {
            //Debug.Log(Player.transform.position);
            SetTracking(Player.transform.position);
            f_TrackingPlayer = true;
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
        //Sound_list.Clear();
        //Tag_list.Clear();
    }

    //巡回状態にする
    public void SetPatrol() 
    {
        state = State.Patrol;
        f_TrackingPlayer = false;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
    }
}
