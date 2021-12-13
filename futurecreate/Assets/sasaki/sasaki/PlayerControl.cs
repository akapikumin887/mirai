using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

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
    private uint _Frame;

    private List<GameObject> _PathFindings = new List<GameObject>();

    private float _Time;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        else
        {
            _Frame = 0;
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
            GameObject bell = Instantiate(_Bell, transform.position, Quaternion.identity);
            ring b = bell.GetComponent<ring>();
            b.SetBell(20, 1);
            _Frame = 0;
        }
    }

    private bool KeyInput()
    {
        //入力方向の取得
        bool vertical = false;
        bool horizontal = false;
        bool Run = false;

        Vector3 velocity = Vector3.zero;

        if (rb.velocity.magnitude <= 0.1f)
        {
            GetComponent<Animator>().SetBool("walk", false);
            GetComponent<Animator>().SetBool("run", false);
        }
        else if(rb.velocity.magnitude <= _PlayerSpeed)
        {
            GetComponent<Animator>().SetBool("walk", true);
            GetComponent<Animator>().SetBool("run", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", true);
        }

        // ゲームパッドが接続されていないとnullになる。
        if (Gamepad.current == null)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run = true;
            }
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

        }
        else
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * Gamepad.current.leftStick.ReadValue().y + Camera.main.transform.right * Gamepad.current.leftStick.ReadValue().x;

            Run = Gamepad.current.leftStickButton.isPressed;
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            velocity = moveForward + new Vector3(0, rb.velocity.y, 0);

            vertical = true;
        }


        //斜め入力の加速を無くす
        if (vertical && horizontal)
            velocity /= 1.41421356f;
        else if (!(vertical || horizontal))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
            return false;
        }


        //transform.position += velocity * _PlayerSpeed * Time.deltaTime;
        //transform.Rotate(0.0f, 0.0f, 0.0f);

        //移動と向き変更
        rb.velocity = velocity * (_PlayerSpeed + Convert.ToInt32(Run) * 5.0f);
        //transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rb.velocity, Vector3.up), (200.0f+ Convert.ToInt32(Run)*100.0f) * Time.deltaTime);

        //向きもベクトルに合わせる
        return true;
    }
}