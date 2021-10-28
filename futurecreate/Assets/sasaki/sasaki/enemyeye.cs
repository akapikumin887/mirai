using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyeye : MonoBehaviour
{
    GameObject Player;      //プレイヤー宣言

    // Start is called before the first frame update
    void Start()
    {
        //目的地のオブジェクトを取得
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //ベクトルの宣言（せってい）
        Vector3 Enemy_forward_direction = Vector3.forward;//敵の正面ベクトルを取得
        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;     // プレイヤーの方向ベクトル

        //敵の視界の設定
        float dot = Vector3.Dot(Enemy_forward_direction, Player_direction);     //敵の前方ベクトルとプレイヤー方向とのベクトルの内積計算
        if(dot > 0.7f)
        {
            GetComponent<Renderer>().material.color = Color.black;        //色を変える

        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        Debug.Log(this.transform.position);
    }
}
