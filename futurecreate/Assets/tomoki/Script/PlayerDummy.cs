using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    private float _PlayerSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private bool Move()
    {
        //入力方向の取得
        bool vertical = false;
        bool horizontal = false;

        Vector3 velocity = Vector3.zero;

        //左右判定
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            int abs = Input.GetKey(KeyCode.A) ? -1 : 1;
            velocity.x += 0.5f * abs;
            velocity.z -= 0.5f * abs;
            vertical = true;
        }

        //上下判定
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            int abs = Input.GetKey(KeyCode.S) ? -1 : 1;
            velocity.x += 0.5f * abs;
            velocity.z += 0.5f * abs;
            horizontal = true;
        }

        //斜め入力の加速を無くす
        if (vertical && horizontal)
            velocity /= 1.41421356f;
        else if (!(vertical || horizontal))
            return false;

        transform.position += velocity * _PlayerSpeed * Time.deltaTime;
        return true;
    }
}
