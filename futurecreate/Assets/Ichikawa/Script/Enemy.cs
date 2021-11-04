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

    public Transform[] points;
    private NavMeshAgent agent;
    // ���̖ړI�n
    [SerializeField] int destPoint = 0;

    // GameManager�ϐ�
    GameObject GAMEMASTER;
    GameMng game_mng;

    // �ǐՒ��ړI�n
    Vector3 Destination;

    void Start()
    {
        // GameManager�擾
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // �ǐՒ��ړI�n������
        Destination = this.transform.position;

        agent = GetComponent<NavMeshAgent>();

        // autoBraking�𖳌��ɂ���ƖړI�n�ɋ߂Â��Ă����x�������Ȃ�
        agent.autoBraking = false;

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
        // �K�v�Ȃ�Ώo���n�_�ɖ߂�
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        switch (eType)
        {
            case ENEMY_TYPE.PATROL: // ����
                GetComponent<Renderer>().material.color = Color.red; //�F��ς���
                // ���ړI�n�ɋ߂Â����玟�̖ړI�n��I��
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;

            case ENEMY_TYPE.VIGILANCE: // �x��
                break;

            case ENEMY_TYPE.TRACKING: // ����
                GetComponent<Renderer>().material.color = Color.black; //�F��ς���
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(Destination);
                break;

            case ENEMY_TYPE.PEPPER: // �y�b�p�[
                GetComponent<Renderer>().material.color = Color.blue; //�F��ς���
                GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(Destination);
                break;
        }
    }

    // ENEMY_TYPE
    public ENEMY_TYPE GetEnemyType() // �Q�b�^�[
    {
        return eType;
    }
    public void SetEnemyType(ENEMY_TYPE type) // �Z�b�^�[
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
}