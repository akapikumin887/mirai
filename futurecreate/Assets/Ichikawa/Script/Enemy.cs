using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent�g���Ƃ��ɕK�v
using UnityEngine.AI;

//�I�u�W�F�N�g��NavMeshAgent�R���|�[�l���g��ݒu
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    // �G�̏��
    public enum ENEMY_TYPE
    {
        PATROL,     // ����
        VIGILANCE,  // �x��
        TRACKING,   // �ǐ�
    }

    public Transform[] points;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;
    private bool discover;  //����

    // �G�̏�ԕϐ�
    private ENEMY_TYPE eType;

    //�v���C���[�̏���錾
    NavMeshAgent Player_Nav;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̏����擾
        //�v���C���[��NavMeshAgent���擾
        Player_Nav = GetComponent<NavMeshAgent>();
        //�ړI�n�̃I�u�W�F�N�g���擾
        Player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        //enemymove = GetComponent<Enemymove>();

        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă�
        // ���x�����Ƃ��܂���)
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ��܂�
        if (points.Length == 0)
            return;

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ肵�܂�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肵�A
        // �K�v�Ȃ�Ώo���n�_�ɂ��ǂ�܂�
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_hit();

        switch (eType)
        {
            case ENEMY_TYPE.PATROL:
                //�G�͈̔͂ɓ�������
                if (discover)
                {
                    GetComponent<Renderer>().material.color = Color.black;        //�F��ς���
                    GetComponent<NavMeshAgent>().isStopped = false;
                    Player_Nav.SetDestination(Player.transform.position);
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.red;        //�F��ς���

                    // �G�[�W�F���g�����ڕW�n�_�ɋ߂Â��Ă�����A
                    // ���̖ڕW�n�_��I�����܂�
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                        GotoNextPoint();
                }
                break;

            case ENEMY_TYPE.VIGILANCE:
                break;

            case ENEMY_TYPE.TRACKING:
                break;
        }
    }

    //�G�͈̔�
    public void Enemy_hit()
    {
        Vector3 Enemy_position = this.transform.position;
        Vector3 Player_position = Player.transform.position;

        Vector3 hit;
        hit.x = Enemy_position.x - Player_position.x;
        hit.y = Enemy_position.y - Player_position.y;
        hit.z = Enemy_position.z - Player_position.z;

        if (hit.x * hit.x + hit.z * hit.z < 25)
            discover = true;
        else
            discover = false;
    }

    public bool GetDiscover()
    {
        return discover;
    }

    // ENEMY_TYPE
    public ENEMY_TYPE GetEnemyType()
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type)
    {
        eType = type;
    }
}