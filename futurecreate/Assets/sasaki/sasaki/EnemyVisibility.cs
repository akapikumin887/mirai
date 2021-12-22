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



    Vector3 Enemy_forward_direction;
    Vector3 Player_direction;
    bool visibility_hit = false;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // �ړI�n�̃I�u�W�F�N�g���擾
        Player = game_mng._Pleyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Enemy>().eType == Enemy.ENEMY_TYPE.NULL)
            return;

        //----------------------------------------------------------------------------------------
        //�x�N�g���̐錾�i�����Ă��j
        Enemy_forward_direction = this.transform.forward;//�G�̐��ʃx�N�g�����擾
        Player_direction = (Player.transform.position - this.transform.position).normalized;     // �v���C���[�̕����x�N�g��
        //RaycastHit hit = new RaycastHit();

        Debug.DrawLine(this.transform.position, Player_direction * 100, Color.red);


        //if (light_visibility(this.transform.position, Player.transform.position, Mathf.Infinity, 0.0f))
        //{

        //    if (hit.collider.tag == "wall")   //�v���C���[�܂ŏ�Q�����Ȃ��Ƃ�
        //    {
        //        Debug.Log("���ׂ���������");
        //        return;
        //    }

        //}

        if (light_visibility(Enemy_forward_direction, Player_direction, 6.1f, 0.4f))
        {

            if (hit.collider.tag == "wall")   //�v���C���[�܂ŏ�Q�����Ȃ��Ƃ�
            {
                if (this.GetComponent<Enemy>().eType != Enemy.ENEMY_TYPE.PEPPER)
                {
                    //this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                    this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.PATROL;
                    Debug.Log("�ǂ���������");
                    return;
                }
            }

            Debug.Log("���E�ɓ�������");

            //this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);
            this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.TRACKING;
            //this.GetComponent<Enemy>().SetDestination(Player.transform.position);
            this.GetComponent<Enemy>().destination = Player.transform.position;
            //Debug.Log("��������");
            
        }
        else
        {
            if (this.GetComponent<Enemy>().eType != Enemy.ENEMY_TYPE.PEPPER)
            {
                //this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
                this.GetComponent<Enemy>().eType = Enemy.ENEMY_TYPE.PATROL;

            }
        }

        //{
        //    if (light_visibility(Enemy_forward_direction, Player_direction, 6.0f, 0.4f))
        //    {
        //        Debug.Log(hit.collider.tag);

        //        if (hit.collider.tag == "Player")   //�v���C���[�܂ŏ�Q�����Ȃ��Ƃ�
        //        {
        //            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);        //Enemy�̍s���p�^�[���̕ύX�@�p�g���[���̃p�^�[���ɕύX
        //            this.GetComponent<Enemy>().SetDestination(Player.transform.position);
        //            Debug.Log("��������");
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (this.GetComponent<Enemy>().GetEnemyType() != Enemy.ENEMY_TYPE.PEPPER)
        //        {
        //            this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
        //        }
        //    }
        //}
    }

    bool light_visibility(Vector3 vector3, Vector3 vector3_player, float kyori, float hanni)
    {
        //�G�̎��E�̐ݒ�
        float dot = Vector3.Dot(vector3, vector3_player);     //�G�̑O���x�N�g���ƃv���C���[�����Ƃ̃x�N�g���̓��όv�Z
        if (dot > hanni)     //����
        {
            if (Physics.Raycast(this.transform.position, vector3_player, out hit, kyori))     //Ray�ɂ�������̂���������  �Ō�̈���������
            {
                visibility_hit = true;      //�������Ă锻��
            }
        }
        else
        {
            visibility_hit = false;
        }
        return visibility_hit;
    }
}
