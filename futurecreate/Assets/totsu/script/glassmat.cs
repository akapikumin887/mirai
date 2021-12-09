using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassmat : MonoBehaviour
{
    [SerializeField] GameObject Bell; //音オブジェクト

    [SerializeField] float SoundSize = 15.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //スクリプトオブジェクトを取得
            ring b = bell.GetComponent<ring>();
            //音の設定(規模、なっている時間(f),タグ)
            b.SetBell(SoundSize, 1);
        }
    }
}
