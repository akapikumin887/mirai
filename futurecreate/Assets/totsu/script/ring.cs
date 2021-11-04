using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    [SerializeField] float SoundSize = 0.0f; //���͈̔�
    [SerializeField] int SoundTime = 1; //���̌p������(F���Z)
    int frame = 0;

    private void Start()
    {
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }

    // �����蔻�����ɏ�����������LateUpdate
    void LateUpdate()
    {
        if (SoundTime >= 1)
        {
            //�p�����ԏI����ɏ���
            if (frame++ >= SoundTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //�O���X�N���v�g����p�����[�^���Z�b�g����
    public void SetBell(float soundsize,int soundtime)
    {
        SoundSize = soundsize;
        SoundTime = soundtime;
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }
}
