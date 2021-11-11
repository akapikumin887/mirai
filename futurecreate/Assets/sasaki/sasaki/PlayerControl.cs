using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _PlayerSpeed; // �ړ����x

    private Vector3 _Position; //�v���C���[�̃|�W�V����
    
    [SerializeField] private GameObject _Bell;

    private int frame = 0;

    void Start()
    {
        _Position = GetComponent<Transform>().position; //�ŏ��̎��_�ł̃v���C���[�̃|�W�V�������擾
    }

    void Update()
    {
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-_PlayerSpeed * Time.deltaTime, 0.0f, 0.0f);
            frame++;
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(_PlayerSpeed * Time.deltaTime, 0.0f, 0.0f);
            frame++;
        }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, _PlayerSpeed * Time.deltaTime);
            frame++;
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -_PlayerSpeed * Time.deltaTime);
            frame++;
        }
        // ���N���b�N
        if (Input.GetMouseButton(0))
        {

        }
        // �E�N���b�N
        if (Input.GetMouseButton(1))
        {

        }
        // ���V�t�g
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }

        //�x���𐶐����ċ^���I�ɑ����𔭐�������
        if (frame > 15)
        {
            GameObject bell = Instantiate(_Bell,transform.position,Quaternion.identity);
            ring b = bell.GetComponent<ring>();
            b.SetBell(50,1);
            frame = 0;
        }
    }
}