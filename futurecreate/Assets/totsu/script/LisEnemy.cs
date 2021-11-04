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

    NavMeshAgent Player_Nav;
    GameObject Player;

    // ENEMY_TYPE eNEMY_TYPE;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[��NavMeshAgent���擾
        Player_Nav = GetComponent<NavMeshAgent>();
        //�ړI�n�̃I�u�W�F�N�g���擾
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (state == State.Chase)
        //    {
        //        state = State.Patrol;
        //    }
        //    else
        //    {
        //        state = State.Chase;
        //    }
        //}
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


            //Player_Nav.SetDestination(Player.transform.position);

            //Instantiate(pin, other.transform.position, Quaternion.identity);

        }
        else
        {
            Debug.Log("�ڕW�n�_���B");
            //���񃂁[�h�ɂ���
            GetComponent<Renderer>().material.color = Color.white;
            state = State.Patrol;
            

        }

        if (other.gameObject.tag == "pin")
        {
            Debug.Log("�ڕW�n�_���B");
            //���񃂁[�h�ɂ���
            GetComponent<Renderer>().material.color = Color.white;
            state = State.Patrol;

            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);



        }
    }

    void StateAct()
    {
        if (state == State.Patrol)
        {
            //GetComponent<Renderer>().material.color = Color.white;
        }
        else if (state == State.Chase)
        {
           // GetComponent<Renderer>().material.color = Color.red;
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
