using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCall : MonoBehaviour
{
    [SerializeField] GameObject Bell; //ここに音オブジェクトをアタッチ

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bell = Instantiate(Bell, transform.position, transform.rotation) as GameObject;
            // Shotスクリプトオブジェクトを取得
            ring b = bell.GetComponent<ring>();
            // 移動速度を設定
            b.SetBell(5.0f, 120);
        }
    }
}
