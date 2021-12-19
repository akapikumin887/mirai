using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    [SerializeField] GameObject Bell; //���I�u�W�F�N�g
    [SerializeField] float IdlingTime = 5.0f;
    [SerializeField] float Size = 100.0f;
    [SerializeField] float RingingTime = 300.0f;


    private float frame = 0.0f;
    private bool Ring = false;

    // Update is called once per frame
    void Update()
    {
        frame += Time.deltaTime;

        //��莞�Ԍo�ߌ�ɖ炷
        if (frame >= IdlingTime && !Ring)
        {
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //�X�N���v�g�I�u�W�F�N�g���擾
            ring b = bell.GetComponent<ring>();
            //���̐ݒ�(�K�́A�Ȃ��Ă��鎞��(f),�^�O)
            b.SetBell(Size, RingingTime, "Bell");

            Debug.Log("����");

            Ring = true;
        }

        if(frame >= IdlingTime + RingingTime / 60)
        {
            Destroy(this.gameObject);
        }
    }
}
