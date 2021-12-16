using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // �G�̏��
    public enum ENEMY_TYPE
    {
        PATROL,     // ����
        VIGILANCE,  // �x��
        TRACKING,   // �ǐ�
        PEPPER,     // �y�b�p�[
    }

    // �G�̏�ԕϐ�
    private ENEMY_TYPE eType;

    // �ړI�n�̊i�[�ꏊ(0�̓v���C���[�̏ꏊ)
    public Transform[] points;

    private NavMeshAgent agent;

    // ���Ճv���n�u�i�[�ꏊ
    public GameObject footPrint_L;
    public GameObject footPrint_R;

    // ���Ր����t���[���Ǘ�
    private uint frame;
    // ���Ր����Ԋu
    public uint frameCount;
    // ���E�Ǘ�(true�ŉEfalse�ō�)
    private bool footPrint_RoL;
    // ���Ղ̐����ꏊ-----------------------------------------------------------------------------------
    private Vector3 footPrintPotision;
    // ���Ղ̐����p�x
    private Quaternion footPrintAngle;

    // ���̖ړI�n
    [SerializeField] int destPoint = 1;
    // �v���C���[�̈ʒu
    [SerializeField] int playerPoint = 0;

    // GameManager�ϐ�
    GameObject GAMEMASTER;
    GameMng game_mng;

    // �ǐՒ��̖ړI�n
    Vector3 Destination;

    // �v���C���[�ւ̃p�X
    NavMeshPath playerPath = null;

    void Start()
    {
        // GameManager�擾
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // �ǐՒ��̖ړI�n������
        Destination = this.transform.position;

        agent = GetComponent<NavMeshAgent>();

        // autoBraking�𖳌��ɂ���ƖړI�n�ɋ߂Â��Ă����x�������Ȃ�
        agent.autoBraking = false;

        // ���Ր����t���[��������
        frame = 0;
        // �E���Ղ��琶��
        footPrint_RoL = true;
        // ���Ր����ꏊ������-------------------------------------------------------------------------
        footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
        // ���Ր����p�x������
        footPrintAngle = Quaternion.Euler(this.transform.localEulerAngles.x + 90.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 90.0f);

        // �v���C���[�ւ̃p�X������
        playerPath = new NavMeshPath();

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ�
        if (points.Length == 0)
            return;

        // ���ݐݒ肳�ꂽ�ړI�n�ɍs���悤�ɐݒ�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ړI�n�ɐݒ肵
        // �K�v�Ȃ�Ώo���n�_(1)�ɖ߂�
        destPoint = (destPoint + 1) % (points.Length);
        if (destPoint == 0)
            destPoint = 1;
    }

    void Update()
    {
        switch (eType)
        {
            case ENEMY_TYPE.PATROL: // ����
                GetComponent<Renderer>().material.color = Color.red; //�F��ς���
                agent.speed = 1.5f;    // �ړ����x1.5
                // ���ړI�n�ɋ߂Â����玟�̖ړI�n��I��
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;

            case ENEMY_TYPE.VIGILANCE: // �x��
                break;

            case ENEMY_TYPE.TRACKING: // ����
                GetComponent<Renderer>().material.color = Color.black; //�F��ς���
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.speed = 2.0f;    // �ړ����x2.0
                agent.SetDestination(Destination);
                break;

            case ENEMY_TYPE.PEPPER: // �y�b�p�[
                GetComponent<Renderer>().material.color = Color.blue; //�F��ς���
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(Destination);
                // ���ړI�n�ɋ߂Â����玟�̖ړI�n��I��
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                    SetEnemyType(ENEMY_TYPE.PATROL);
                }
                break;
        }

        frame++;

        // ���Ր���--------------------------------------------------------------------------------
        if (frame > frameCount)//��time�ǉ�����
        {
            if (footPrint_RoL)
            {
                // �E����
                footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - 0.2f);
                Instantiate(footPrint_R, footPrintPotision, footPrintAngle);
                footPrint_RoL = false;
            }
            else
            {
                // ������
                footPrintPotision = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z + 0.2f);
                Instantiate(footPrint_L, footPrintPotision, footPrintAngle);
                footPrint_RoL = true;
            }
            frame = 0;
        }

        // �v���C���[�ւ̃p�X�v�Z
        NavMesh.CalculatePath(transform.position, points[playerPoint].position, NavMesh.AllAreas, playerPath);
    }

    // ���݂̏��(ENEMY_TYPE)
    public ENEMY_TYPE GetEnemyType() // �擾
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type) // �ύX
    {
        eType = type;
    }

    // agent
    public NavMeshAgent GetAgent() // �Q�b�^�[
    {
        return agent;
    }
    public void SetAgent(NavMeshAgent agentType) // �Z�b�^�[
    {
        agent = agentType;
    }

    // Destination
    public void SetDestination(Vector3 destination) // �Z�b�^�[
    {
        Destination = destination;
    }

    // �v���C���[�̏��(points[playerPoint])
    public Transform GetPlayerPoint()
    {
        return points[playerPoint];
    }

    // �v���C���[�ւ̃p�X�擾(playerPath)
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