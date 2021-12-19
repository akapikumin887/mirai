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
    [SerializeField] private GameObject _Alarm;

    private GameMng _GameManagerScript;

    //���������t���[���Ǘ�
    private uint _Frame;

    private List<GameObject> _PathFindings = new List<GameObject>();

    private float _Time;

    private Rigidbody rb;

    private bool Run = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _GameManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _PathFindings = _GameManagerScript.GetPathFinding();
    }

    void Update()
    {
        //�ړ��Ƒ����̏���
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

        //��󁫂Ŗڊo�܂����v�ݒu
        if (Input.GetKey(KeyCode.DownArrow))
            Instantiate(_Alarm);

        // ���N���b�N
        if (Input.GetMouseButton(0))
        {

        }
        // �E�N���b�N
        if (Input.GetMouseButton(1))
        {

        }
        // ���V�t�g
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }

        //�x���𐶐����ċ^���I�ɑ����𔭐�������
        if (_Frame > _FrameCount)
        {
            GameObject bell = Instantiate(_Bell, transform.position, Quaternion.identity);
            ring b = bell.GetComponent<ring>();

            float soundSize = 20.0f;
            if(Run)
            {
                soundSize *= 2.0f;
            }
            b.SetBell(soundSize, 2);
            _Frame = 0;
        }
    }

    private bool KeyInput()
    {
        //���͕����̎擾
        bool vertical = false;
        bool horizontal = false;
        Run = false;

        Vector3 velocity = Vector3.zero;

        if (rb.velocity.magnitude <= 0.1f)
        {
            GetComponent<Animator>().SetBool("walk", false);
            GetComponent<Animator>().SetBool("run", false);
        }
        else if(rb.velocity.magnitude <= _PlayerSpeed+0.5f)
        {
            GetComponent<Animator>().SetBool("walk", true);
            GetComponent<Animator>().SetBool("run", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", true);
        }
        //Debug.Log(Gamepad.current);
        // �Q�[���p�b�h���ڑ�����Ă��Ȃ���null�ɂȂ�B
        if (Gamepad.current == null)
        {
            if (Input.GetKey(KeyCode.LeftShift)
                || Input.GetKey(KeyCode.RightShift))
            {
                Run = true;
            }
            //���E����
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                int abs = Input.GetKey(KeyCode.A) ? -1 : 1;
                velocity.x += 0.5f * abs;
                velocity.z -= 0.5f * abs;
                vertical = true;
            }

            //�㉺����
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

            // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
            Vector3 moveForward = cameraForward * Gamepad.current.leftStick.ReadValue().y + Camera.main.transform.right * Gamepad.current.leftStick.ReadValue().x;
            Run = Gamepad.current.rightShoulder.isPressed;
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            velocity = moveForward.normalized + new Vector3(0, rb.velocity.y, 0);

            if (Gamepad.current.leftStick.ReadValue().magnitude <= 0.0f)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
                return false;
            }

            vertical = true;
        }


        //�΂ߓ��͂̉����𖳂���
        if (vertical && horizontal)
            velocity /= 1.41421356f;
        else if (!(vertical || horizontal))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
            return false;
        }


        //transform.position += velocity * _PlayerSpeed * Time.deltaTime;
        //transform.Rotate(0.0f, 0.0f, 0.0f);

        //�ړ��ƌ����ύX
        rb.velocity = velocity * (_PlayerSpeed + Convert.ToInt32(Run) * 5.0f);
        //transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rb.velocity, Vector3.up), (200.0f+ Convert.ToInt32(Run)*100.0f) * Time.deltaTime);

        //�������x�N�g���ɍ��킹��
        return true;
    }
}