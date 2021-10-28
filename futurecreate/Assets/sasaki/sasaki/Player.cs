using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class Player : MonoBehaviour
{
    public float PlayerSpeed; // �ړ����x

    private Vector3 Player_pos; //�v���C���[�̃|�W�V����
    
    private float x; //x������Imput�̒l
    private float z; //z������Input�̒l

    /*NavMesh
    Vector3 prev;
    //*/

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //�ŏ��̎��_�ł̃v���C���[�̃|�W�V�������擾
    }

    void Update()
    {
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-PlayerSpeed, 0.0f, 0.0f);
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(PlayerSpeed, 0.0f, 0.0f);
        }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, PlayerSpeed);
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -PlayerSpeed);
        }

        //Vector3 diff = this.transform.position - Player_pos; //�v���C���[���ǂ̕����ɐi��ł��邩���킩��悤�ɁA�����ʒu�ƌ��ݒn�̍��W�������擾

        //if (diff.magnitude > 0.01f) //�x�N�g���̒�����0.01f���傫���ꍇ�Ƀv���C���[�̌�����ς��鏈��������(0�ł͓���Ȃ��̂Łj
        //{
        //    transform.rotation = Quaternion.LookRotation(diff);  //�x�N�g���̏���Quaternion.LookRotation�Ɉ����n����]�ʂ��擾���v���C���[����]������
        //}

        //Player_pos = transform.position; //�v���C���[�̈ʒu���X�V

        /*NavMesh
        // �ړ�
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        float moveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed;
        float moveVertical = Input.GetAxis("Vertical") * PlayerSpeed;
        agent.Move(new Vector3(moveHorizontal, 0, moveVertical));

        // �i�s�����ɉ�]������
        Vector3 diff = transform.position - prev;
        if (diff.magnitude > 0.01)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        prev = transform.position;
        //*/
    }
}