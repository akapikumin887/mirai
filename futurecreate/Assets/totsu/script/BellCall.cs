using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCall : MonoBehaviour
{
    [SerializeField] GameObject Bell; //�����ɉ��I�u�W�F�N�g���A�^�b�`

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bell = Instantiate(Bell, transform.position, transform.rotation) as GameObject;
            // Shot�X�N���v�g�I�u�W�F�N�g���擾
            ring b = bell.GetComponent<ring>();
            // �ړ����x��ݒ�
            b.SetBell(5.0f, 120);
        }
    }
}
