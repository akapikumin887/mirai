using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
    //[SerializeField] GameObject pin;    //�s��
    private List<GameObject> Sound_list = new List<GameObject>();
    private List<String> Tag_list = new List<String>();

    public enum State   //���
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
        //�v���C���[��NavMeshAgent���擾
        //Player_Nav = GetComponent<NavMeshAgent>();

        //�v���C���[���擾
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
        
    }



    void OnTriggerEnter(Collider other)
    {
        //���������m
        if (other.gameObject.tag == "footsteps")
        {
            Debug.Log("�������m");
            //�ǂ��������[�h�ɂ���
            SetTracking();

            //�ǐՉ����n�_��ݒ�
            GoalPos = other.transform.position;

            //�ڎw�����W�ݒ�
            this.GetComponent<Enemy>().SetDestination(GoalPos);



            //Instantiate(pin, other.transform.position, Quaternion.identity);

        }


        Sound_list.Add(other.gameObject);
        //Tag_list.Add(other.gameObject.tag);

        if(Sound_list.Count != 0)
        {
            SelectTarget();
        }
    }

    void SelectTarget()
    {

        for (int i = 0; i < Sound_list.Count; i++)
        {
            Tag_list.Add(Sound_list[i].gameObject.tag);
        }

        //�D�揇�ʏ��ɌJ��Ԃ�
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
            SetTracking();

            //�ǐՉ����n�_��ݒ�
            GoalPos = Player.transform.position;

            //�ڎw�����W�ݒ�
            this.GetComponent<Enemy>().SetDestination(GoalPos);
            return;
        }



        //bool only_fs = true;   //�����̂݌��m

        ////���m���������݂̂����f
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
        //    Debug.Log("�������m");

        //    SetTracking();

        //    //�ǐՉ����n�_��ݒ�
        //    GoalPos = Sound_list[0].transform.position;

        //    //�ڎw�����W�ݒ�
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
        SetTracking();

        //�ǐՉ����n�_��ݒ�
        GoalPos = Sound_list[dis_count].transform.position;

        //�ڎw�����W�ݒ�
        this.GetComponent<Enemy>().SetDestination(GoalPos);
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
                Debug.Log("�ڕW�n�_���B");
                //���񃂁[�h�ɂ���
                SetPatrol();

                
                
            }
        }
    }

    public State GetState()
    {
        return state;
    }

    //�ǐՏ�Ԃɂ���
    public void SetTracking()
    {
        //�ǂ��������[�h�ɂ���
        state = State.Chase;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);
    }

    //�����Ԃɂ���
    public void SetPatrol() 
    {
        state = State.Patrol;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
    }
}
