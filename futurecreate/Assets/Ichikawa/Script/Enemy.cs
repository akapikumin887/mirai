using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*=========================================================

    �C���X�y�N�^�[

    Points:���[�g�ɉ�����Point������
         �������A�p�X���擾���邽��0�ɂ̓v���C���[������

    FootPrint_L,R:���E�̑��Ղ̃v���n�u������

    frameCount:���Ղ̐����Ԋu��ݒ�(�b)

=========================================================*/

public class Enemy : MonoBehaviour
{
    // NavMesh
    private NavMeshAgent agent;

    // GameManager�ϐ�
    private GameObject gameMaster;
    private GameMng gameManager;

    /*-----------------------
      �G�̏��
    -----------------------*/
    public enum ENEMY_TYPE
    {
        PATROL,     // ����
        VIGILANCE,  // �x��
        TRACKING,   // �ǐ�
        PEPPER,     // �y�b�p�[(�Ăъ񂹂��Ă�)
    }
    // ���݂̏��
    private ENEMY_TYPE eType;

    /*-----------------------
      �ړI�n
    -----------------------*/
    [Header("Destination")]
    // �i�[�ꏊ(0�Ƀv���C���[�̏ꏊ)
    public Transform[] points;
    // ���̖ړI�n
    private int nextPoint = 1;
    // �v���C���[�̈ʒu
    private int playerPoint = 0;
    // �ǐՒ��̖ړI�n
    private Vector3 destination;
    // �v���C���[�ւ̃p�X
    private NavMeshPath playerPath = null;

    /*-----------------------
      ����
    -----------------------*/
    [Header("FootPrint")]
    // �v���n�u�i�[�ꏊ
    public GameObject footPrint_L;
    public GameObject footPrint_R;
    // �����t���[���Ǘ�
    private float frame;
    // �����Ԋu(�b)
    public uint frameCount;
    // ���E�Ǘ�(true�ŉEfalse�ō�)
    private bool footPrint_RoL;
    // �����ꏊ
    private Vector3 footPrintPotision;
    // �����p�x
    private Quaternion footPrintAngle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // autoBraking�𖳌��ɂ���ƖړI�n�ɋ߂Â��Ă����x�������Ȃ�
        agent.autoBraking = false;

        // GameManager�擾
        gameMaster = GameObject.FindGameObjectWithTag("Manager");
        gameManager = gameMaster.GetComponent<GameMng>();

        // �ǐՒ��̖ړI�n������
        destination = this.transform.position;
        // �v���C���[�ւ̃p�X������
        playerPath = new NavMeshPath();

        // ���Ր����t���[��������
        frame = 0;
        // �E���Ղ��琶��
        footPrint_RoL = true;
        // ���Ր����p�x������
        footPrintAngle = Quaternion.Euler(transform.localEulerAngles.x + 90.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);

        // �ړI�n�Ɍ�����
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ�
        if (points.Length == 0)
            return;

        // ���ݐݒ肳�ꂽ�ړI�n�ɍs���悤�ɐݒ�
        agent.destination = points[nextPoint].position;

        // �z����̎��̈ʒu��ړI�n�ɐݒ肵
        // �K�v�Ȃ�Ώo���n�_(1)�ɖ߂�
        nextPoint = (nextPoint + 1) % (points.Length);
        if (nextPoint == 0)
            nextPoint = 1;
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
                agent.SetDestination(destination);
                break;

            case ENEMY_TYPE.PEPPER: // �y�b�p�[
                GetComponent<Renderer>().material.color = Color.blue; //�F��ς���
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(destination);
                // ���ړI�n�ɋ߂Â����玟�̖ړI�n��I��
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    GotoNextPoint();
                    SetEnemyType(ENEMY_TYPE.PATROL);
                }
                break;
        }

        frame += Time.deltaTime;

        // ���Ր���
        if (frame > frameCount)
        {
            // �p�x����
            footPrintAngle = Quaternion.Euler(this.transform.localEulerAngles.x + 90.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);

            if (footPrint_RoL)
            {
                // �E����
                footPrintPotision = this.transform.localPosition
                                    - transform.up * 0.49f    // �㉺����
                                    + transform.right * 0.2f; // ���E����
                Instantiate(footPrint_R, footPrintPotision, footPrintAngle);
                footPrint_RoL = false;
            }
            else
            {
                // ������
                footPrintPotision = this.transform.localPosition
                                    - transform.up * 0.49f
                                    - transform.right * 0.2f;
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

    // destination
    public void SetDestination(Vector3 dest) // �Z�b�^�[
    {
        destination = dest;
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
            gameManager.SetGameOver(true);
        }
    }
}