using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCall : MonoBehaviour
{
    [SerializeField] GameObject Bell; //���I�u�W�F�N�g

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //�X�N���v�g�I�u�W�F�N�g���擾
            ring b = bell.GetComponent<ring>();
            //���̐ݒ�(�K�́A�Ȃ��Ă��鎞��(f),�^�O)
            b.SetBell(5.0f, 10);

            
        }
    }
}
