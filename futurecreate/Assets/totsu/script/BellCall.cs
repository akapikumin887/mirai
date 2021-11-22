using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCall : MonoBehaviour
{
    [SerializeField] GameObject Bell; //音オブジェクト

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //スクリプトオブジェクトを取得
            ring b = bell.GetComponent<ring>();
            //音の設定(規模、なっている時間(f),タグ)
            b.SetBell(5.0f, 10);

            
        }
    }
}
