using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyeye : MonoBehaviour
{
    GameObject Player;      //�v���C���[�錾

    // Start is called before the first frame update
    void Start()
    {
        //�ړI�n�̃I�u�W�F�N�g���擾
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //�x�N�g���̐錾�i�����Ă��j
        Vector3 Enemy_forward_direction = Vector3.forward;//�G�̐��ʃx�N�g�����擾
        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;     // �v���C���[�̕����x�N�g��

        //�G�̎��E�̐ݒ�
        float dot = Vector3.Dot(Enemy_forward_direction, Player_direction);     //�G�̑O���x�N�g���ƃv���C���[�����Ƃ̃x�N�g���̓��όv�Z
        if(dot > 0.7f)
        {
            GetComponent<Renderer>().material.color = Color.black;        //�F��ς���

        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        Debug.Log(this.transform.position);
    }
}
