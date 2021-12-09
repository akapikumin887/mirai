using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassmat : MonoBehaviour
{
    [SerializeField] GameObject Bell; //���I�u�W�F�N�g

    [SerializeField] float SoundSize = 15.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //�X�N���v�g�I�u�W�F�N�g���擾
            ring b = bell.GetComponent<ring>();
            //���̐ݒ�(�K�́A�Ȃ��Ă��鎞��(f),�^�O)
            b.SetBell(SoundSize, 1);
        }
    }
}
