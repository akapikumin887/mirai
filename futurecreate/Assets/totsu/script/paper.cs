using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(0f, Random.Range(0f,360f), 0f);

        // transform���擾
        Transform myTransform = this.transform;

        // ���[���h���W����ɁA��]���擾
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x =  0.0f; // ���[���h���W����ɁAx�������ɂ�����]��10�x�ɕύX
        worldAngle.y = Random.Range(0f, 360f); // ���[���h���W����ɁAy�������ɂ�����]��10�x�ɕύX
        worldAngle.z =  0.0f; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
        myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
    }

}
