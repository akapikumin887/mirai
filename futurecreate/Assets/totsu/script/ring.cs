using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    [SerializeField] float SoundSize = 0.0f; //���͈̔�
    [SerializeField] float SoundTime = 1; //���̌p������(F���Z)
    float frame = 0;

    private void Start()
    {
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }

    // �����蔻�����ɏ�����������LateUpdate
    void LateUpdate()
    {
        frame += Time.deltaTime;
       
        //�p�����ԏI����ɏ���
        if (frame >= SoundTime)
        {
            Destroy(this.gameObject);
        }
        
    }

    //�O���X�N���v�g����p�����[�^���Z�b�g����
    public void SetBell(float soundsize,float soundtime,string tag_name = "footsteps" )
    {
        SoundSize = soundsize;
        SoundTime = soundtime / 60;
        this.tag = tag_name;
        //Debug.Log("�^�O : "+ tag_name);
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }
}
