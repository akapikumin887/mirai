using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

/*=========================================================

    �C���X�y�N�^�[

    eClass:�G�̎�ނ��w��(Vis,Lis,Pep)

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
    // �G�̏��
    public enum ENEMY_TYPE
    {
        PATROL,     // ����
        VIGILANCE,  // �x��
        TRACKING,   // �ǐ�
        PEPPER,     // �y�b�p�[(�Ăъ񂹂��Ă�)
        NULL,
    }
    // ���݂̏��
    public ENEMY_TYPE eType { set; get; }

    // �G�̎��
    public enum ENEMY_CLASS
    {
        VISIBIITY,  // �ڂ������G
        LISTENING,  // ���������G
        PEPPER,     // �y�b�p�[(�Ăъ񂹂�)
    }
    // ���̓G�̎�� ���ՂŎg�p
    public ENEMY_CLASS eClass;

    /*-----------------------
      �ړI�n
    -----------------------*/
    [Header("Destination")]
    // �i�[�ꏊ(0�Ƀv���C���[�̏ꏊ)
    private List<Transform> points = new List<Transform>();
    // ���̖ړI�n
    private int nextPoint = 1;
    // �v���C���[�̈ʒu
    private int playerPoint = 0;
    // �ǐՒ��̖ړI�n
    public Vector3 destination { set; get; }
    // �v���C���[�ւ̃p�X
    public NavMeshPath playerPath { set; get; } = null;

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
    public float frameCount;
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

        // �v���C���[�擾
        GameObject playerObj = GameObject.Find("character");
        // �ړI�n�̃|�C���g�擾
        GameObject pointObj = GameObject.Find("Points"); //�|�C���g�̂܂Ƃ܂�
        GameObject[] pointsObj = new GameObject[pointObj.transform.childCount]; //���ꂼ��̃|�C���g
        for (int i = 0; i < pointObj.transform.childCount; i++)
        {
            pointsObj[i] = pointObj.transform.GetChild(i).gameObject;
        }

        // �ړI�n���X�g���N���A���ăv���C���[�ƃ|�C���g��ǉ�
        points.Clear();
        points.Add(playerObj.transform);
        for (int j = 0; j < pointsObj.Length; j++)
        {
            points.Add(pointsObj[j].transform);
        }
        // �ǐՒ��̖ړI�n������
        destination = this.transform.position;
        // �v���C���[�ւ̃p�X������
        playerPath = new NavMeshPath();
        // �v���C���[�ւ̃p�X�v�Z
        NavMesh.CalculatePath(transform.position, points[playerPoint].position, NavMesh.AllAreas, playerPath);
        // ���Ր����t���[��������
        frame = 0;
        // �E���Ղ��琶��
        footPrint_RoL = true;
        // ���Ր����p�x������
        footPrintAngle = Quaternion.Euler(transform.localEulerAngles.x + 90.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);

        // �ŏ��̖ړI�n�Ɍ�����
        //GotoNextPoint();
        eType = ENEMY_TYPE.NULL;
    }

    // �ړI�n�Ǘ��֐�
    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ�
        if (points.Count == null)
            return;

        // ���ݐݒ肳�ꂽ�ړI�n�ɍs���悤�ɐݒ�
        agent.destination = points[nextPoint].position;

        // �z����̎��̈ʒu��ړI�n�ɐݒ肵
        // �K�v�Ȃ�Ώo���n�_(1)�ɖ߂�
        nextPoint = (nextPoint + 1) % (points.Count);
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
                //if (!agent.pathPending && agent.remainingDistance < 0.5f)
                //    GotoNextPoint();
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
                    //SetEnemyType(ENEMY_TYPE.PATROL);
                    eType = ENEMY_TYPE.PATROL;
                }
                break;

            case ENEMY_TYPE.NULL:
                return;
        }

        frame += Time.deltaTime;

        // ���Ր���
        if (frame > frameCount)
        {
            // �p�x����
            footPrintAngle = Quaternion.Euler(this.transform.localEulerAngles.x + 90.0f, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);

            switch (eClass)
            {
                case ENEMY_CLASS.VISIBIITY: // �ڂ������G(�񑫕��s)
                    CreateFootPrint(0);
                    break;

                case ENEMY_CLASS.LISTENING: // ���������G(�l�����s)
                    CreateFootPrint(0.5f);
                    CreateFootPrint(-0.5f);
                    break;

                case ENEMY_CLASS.PEPPER:    // �y�b�p�[
                    CreateFootPrint(0);
                    break;
            }

            frame = 0;
        }

        // �v���C���[�ւ̃p�X�v�Z
        NavMesh.CalculatePath(transform.position, points[playerPoint].position, NavMesh.AllAreas, playerPath);
    }

    // ���Ր����֐�(xpos -> �O�㒲��)
    public void CreateFootPrint(float xpos)
    {
        if (footPrint_RoL)
        {
            // �E����
            footPrintPotision = this.transform.position
                                + transform.forward * xpos  // �O�㒲��
                                - transform.up * 0.49f      // �㉺����
                                + transform.right * 0.2f;   // ���E����
            Instantiate(footPrint_R, footPrintPotision, footPrintAngle);
            footPrint_RoL = false;
        }
        else
        {
            // ������
            footPrintPotision = this.transform.position
                                + transform.forward * xpos
                                - transform.up * 0.49f
                                - transform.right * 0.2f;
            Instantiate(footPrint_L, footPrintPotision, footPrintAngle);
            footPrint_RoL = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GameOver = true;
        }
    }
}