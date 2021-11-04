using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
    [SerializeField] GameObject pin;    //�s��


    public enum State   //���
    {
        Patrol = 0,
        Chase,

    };
    public State state = State.Patrol;

    Vector3 GoalPos;

    NavMeshAgent Player_Nav;
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[��NavMeshAgent���擾
        Player_Nav = GetComponent<NavMeshAgent>();

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
            GetComponent<Renderer>().material.color = Color.red;
            state = State.Chase;

            Debug.Log("�ǂ�����");
            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);


            Player_Nav.SetDestination(other.transform.position);

            GoalPos = other.transform.position;

            Instantiate(pin, other.transform.position, Quaternion.identity);

        }
      

        //if (other.gameObject.tag == "pin")
        //{
        //    Debug.Log("�ڕW�n�_���B");
        //    //���񃂁[�h�ɂ���
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
            
        }
    }

    public State GetState()
    {
        return state;
    }

    //�p�g���[����Ԃɖ߂�
    public void SetPatrol()
    {
        state = State.Patrol;
    }
}
