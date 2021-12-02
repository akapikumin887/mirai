using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyVisibility : MonoBehaviour
{

    NavMeshAgent Player_Nav;
    GameObject Player;
    GameObject GAMEMASTER;
    GameMng game_mng;

    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // �ړI�n�̃I�u�W�F�N�g���擾
        Player = game_mng.GetPlayer();
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

            if (Physics.Raycast(this.transform.position, Player_direction , out hit, 6.0f))     //Ray�ɂ�������̂���������  �Ō�̈���������
            {
                if (hit.collider.tag == "Player")   //�v���C���[�܂ŏ�Q�����Ȃ��Ƃ�
                {
                    this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemy�̍s���p�^�[���̕ύX�@�p�g���[���̃p�^�[���ɕύX
                    this.GetComponent<Enemy>().SetDestination(Player.transform.position);
                    return;
                }
            }

        }

        if(this.GetComponent<Enemy>().GetEnemyType() != Enemy.ENEMY_TYPE.PEPPER)
        {
            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
        }

    }


}
