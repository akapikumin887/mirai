using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVisibility : MonoBehaviour
{

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
        //----------------------------------------------------------------------------------------
        //�x�N�g���̐錾�i�����Ă��j
        Vector3 Enemy_forward_direction = this.transform.forward;//�G�̐��ʃx�N�g�����擾
        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;     // �v���C���[�̕����x�N�g��

        //�G�̎��E�̐ݒ�
        float dot = Vector3.Dot(Enemy_forward_direction, Player_direction);     //�G�̑O���x�N�g���ƃv���C���[�����Ƃ̃x�N�g���̓��όv�Z
        if (dot > 0.4f)     //����
        {
            //Ray�̂����Ă��@�ǂ��ǂ������肷�邽��
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, Player_direction, out hit, Mathf.Infinity))     //Ray�ɂ�������̂���������
            {
                if (hit.collider.tag == "wall")      //�Ԃɕǂ�����Ƃ�
                {
                    GetComponent<Renderer>().material.color = Color.blue;
                    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                    //GetComponent<NavMeshAgent>().isStopped = true;

                }
                if (hit.collider.tag == "Player")   //�v���C���[�܂ŏ�Q�����Ȃ��Ƃ�
                {
                    GetComponent<Renderer>().material.color = Color.black;        //�F��ς���
                                                                                  //  GetComponent<NavMeshAgent>().isStopped = false;               //�i�r�Q�[�V�������g��
                    Debug.Log("�ǂ��������[");
                    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemy�̍s���p�^�[���̕ύX�@�p�g���[���̃p�^�[���ɕύX

                    Player_Nav.SetDestination(Player.transform.position);       //�i�r�Q�[�V�����̖ڕW���W SetEnemyType(ENEMY_TYPE type)���Ăяo�������ɕς���
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.blue;
                this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                //GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
            //GetComponent<NavMeshAgent>().isStopped = true;

        }

        //Debug.Log(Enemy_forward_direction);
        //------------------------------------------------------------------------------------------



        ////�͈͂ɓ�������true��Ԃ�
        //public bool Enemy_hit()
        //{
        //    Vector3 Enemy_position = this.transform.position;
        //    Vector3 Player_position = Player.transform.position;

        //    Vector3 hit;
        //    hit.x = Enemy_position.x - Player_position.x;
        //    hit.y = Enemy_position.y - Player_position.y;
        //    hit.z = Enemy_position.z - Player_position.z;

        //    if (hit.x * hit.x + hit.y * hit.y < 50)
        //        return true;
        //    else
        //        return false;
        //}



    }
}
