using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class Player : MonoBehaviour
{
    public float PlayerSpeed; // 移動速度

    private Vector3 Player_pos; //プレイヤーのポジション
    
    private float x; //x方向のImputの値
    private float z; //z方向のInputの値

    /*NavMesh
    Vector3 prev;
    //*/

    void Start()
    {
        Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
    }

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

        //Vector3 diff = this.transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得

        //if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        //{
        //    transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        //}

        //Player_pos = transform.position; //プレイヤーの位置を更新

        /*NavMesh
        // 移動
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        float moveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed;
        float moveVertical = Input.GetAxis("Vertical") * PlayerSpeed;
        agent.Move(new Vector3(moveHorizontal, 0, moveVertical));

        // 進行方向に回転させる
        Vector3 diff = transform.position - prev;
        if (diff.magnitude > 0.01)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        prev = transform.position;
        //*/
    }
}