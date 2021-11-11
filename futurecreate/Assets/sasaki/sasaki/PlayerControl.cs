using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*NavMesh
using UnityEngine.AI;
//*/

public class PlayerControl : MonoBehaviour
{
    [Header("�ړ����x")] [SerializeField] private float _PlayerSpeed;

    [Header("�����𔭂���t���[����")]�@[SerializeField] private uint _FrameCount;

    [SerializeField] private GameObject _Bell;

    private GameMng _GameManagerScript;

    //���������t���[���Ǘ�
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
            GameObject bell = Instantiate(_Bell,transform.position,Quaternion.identity);
            ring b = bell.GetComponent<ring>();
            b.SetBell(20,1);
            _Frame = 0;
        }
    }

    private bool KeyInput()
    {
        bool vertical = false;
        bool horizontal = false;

        Vector2 moveSpeed = new Vector2();

        //���E����
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveSpeed.x = _PlayerSpeed * (Input.GetKey(KeyCode.A) ? -1 : 1);
            vertical = true;
        }

        //�㉺����
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            moveSpeed.y = _PlayerSpeed * (Input.GetKey(KeyCode.S) ? -1 : 1);
            horizontal = true;
        }

        //�΂ߓ��͂̉����𖳂���
        if (vertical && horizontal)
            moveSpeed /= 1.41421356f;
        else if (!(vertical || horizontal))
            return false;

        transform.Translate(moveSpeed.x * Time.deltaTime, 0.0f, moveSpeed.y * Time.deltaTime);

        return true;
    }
}