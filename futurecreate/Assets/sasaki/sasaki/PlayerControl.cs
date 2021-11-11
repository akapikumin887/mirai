using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _PlayerSpeed; // 移動速度

    private Vector3 _Position; //プレイヤーのポジション
    
    [SerializeField] private GameObject _Bell;

    private int frame = 0;

    void Start()
    {
        _Position = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
    }

    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-_PlayerSpeed * Time.deltaTime, 0.0f, 0.0f);
            frame++;
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(_PlayerSpeed * Time.deltaTime, 0.0f, 0.0f);
            frame++;
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, _PlayerSpeed * Time.deltaTime);
            frame++;
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -_PlayerSpeed * Time.deltaTime);
            frame++;
        }
        // 左クリック
        if (Input.GetMouseButton(0))
        {

        }
        // 右クリック
        if (Input.GetMouseButton(1))
        {

        }
        // 左シフト
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }

        //ベルを生成して疑似的に足音を発生させる
        if (frame > 15)
        {
            GameObject bell = Instantiate(_Bell,transform.position,Quaternion.identity);
            ring b = bell.GetComponent<ring>();
            b.SetBell(50,1);
            frame = 0;
        }
    }
}