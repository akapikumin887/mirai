using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] float PlayerSpeed; // 移動速度


    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-PlayerSpeed, 0.0f, 0.0f);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(PlayerSpeed, 0.0f, 0.0f);
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, PlayerSpeed);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -PlayerSpeed);
        }
        
    }

}
