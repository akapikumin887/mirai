using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class PlayerControl : MonoBehaviour
{
    [Header("Speed")] [SerializeField] private float _PlayerSpeed;

    [Header("FootFrame")] [SerializeField] private uint _FrameCount;

    [SerializeField] private GameObject _Bell;

    private GameMng _GameManagerScript;

    //足音発生フレーム管理
    private uint _Frame = 0;

    private List<GameObject> _PathFindings = new List<GameObject>();

    private float _Time;

    void Start()
    {
        _GameManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _PathFindings = _GameManagerScript.GetPathFinding();
    }

    void Update()
    {
        //移動と足音の処理
        if (KeyInput())
        {
            _Time += Time.deltaTime;
            if (_Time > 0.01666667f)
            {
                _Frame++;
                _Time = 0.0f;
            }
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
        if (_Frame > _FrameCount)
        {
            GameObject bell = Instantiate(_Bell,transform.position,Quaternion.identity);
            ring b = bell.GetComponent<ring>();
            b.SetBell(20,1);
            _Frame = 0;
        }
    }

    private bool KeyInput()
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