using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(0f, Random.Range(0f,360f), 0f);

        // transformを取得
        Transform myTransform = this.transform;

        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x =  0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = Random.Range(0f, 360f); // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        worldAngle.z =  0.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        myTransform.eulerAngles = worldAngle; // 回転角度を設定
    }

}
