using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] float PlayerSpeed; // �ړ����x


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
        
    }

}
