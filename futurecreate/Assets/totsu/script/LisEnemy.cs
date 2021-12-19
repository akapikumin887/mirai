using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class LisEnemy : MonoBehaviour
{
//�ǐՊ֌W=======================================================================
    
    //���X�g�n
    private List<GameObject> Sound_list = new List<GameObject>();
    private List<String> Tag_list = new List<String>();

    //�G�̏��
    public enum State
    {
        Patrol = 0,
        Chase,
    };
    public State state = State.Patrol;

    //�ڕW���W
    private Vector3 GoalPos;

    //�v���C���[��ǂ������t���O
    private bool f_TrackingPlayer = false;

     //�ڕW�n�_�y�уv���C���[�Ƃ̐ڐG���苗��(����ł����ƌ��߂邱��)
    [SerializeField] float TouchDis = 1.0f;

//�擾�֌W=======================================================================
    //NavMeshAgent Player_Nav;
    [SerializeField] GameObject Player;

    //Enemy�擾
    //[SerializeField] GameObject Ene;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[���擾
        var mng = GameObject.FindGameObjectWithTag("Manager");
        
        if (mng != null)
        {
            var mngScript = mng.GetComponent<GameMng>();
            if (mngScript != null)
            {
                Player = mngScript._Pleyer;
            }
        }

        //Enemy�X�N���v�g���擾
        //Enemy enescr = Ene.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        StateAct();
    }

    private void LateUpdate()
    {
        //�T�E���h���X�g�ƃ^�O���X�g�����Z�b�g
        Sound_list.Clear();
        Tag_list.Clear();

    }

    void StateAct()
    {
        if (Vector3.Distance(transform.position, GoalPos) <= TouchDis)
        {
            //���񃂁[�h�ɂ���
            SetPatrol();
                        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Sound_list.Add(other.gameObject);
        if (state == State.Patrol && Sound_list.Count != 0) 
        {
            SelectTarget();
        }
        else if(state == State.Chase && f_TrackingPlayer)
        {
            SetTracking(Player.transform.position);
        }
    }

    void SelectTarget()
    {
        if (Sound_list.Count != 0)
        {
            for (int i = 0; i < Sound_list.Count; i++)
            {
                Tag_list.Add(Sound_list[i].gameObject.tag);
                //Debug.Log(Sound_list[i].gameObject.tag);
            }
        }
        else
        {
            return;
        }

        //�D�揇�ʏ��ɌJ��Ԃ�
        string item;

        item = "Bell";
        if (Tag_list.Contains(item))
        {
            SetTarget(item);
            //Debug.Log("�ڊo�܂���������");
            return;
        }
        
        //�v���C���[��ǂ�������
        item = "footsteps";
        if (Tag_list.Contains(item))
        {
            //Debug.Log(Player.transform.position);
            SetTracking(Player.transform.position);
            f_TrackingPlayer = true;
            return;
        }
        
    }

    void SetTarget(String tag_name)
    {
        float dis = 0.0f;
        float befdis = 0.0f;
        int dis_count = 0;

        for (int i = 0; i < Sound_list.Count; i++)
        {
            if(Sound_list[i].gameObject.tag == tag_name)
            {
                dis = Vector3.Distance(
                    Sound_list[i].gameObject.transform.position,
                    this.transform.position);

                if(dis < befdis || befdis == 0)
                {
                    befdis = dis;
                    dis_count = i;
                }
            }
        }

        //�ł��߂��n�_���w��
        SetTracking(Sound_list[dis_count].transform.position);
        
    }

    

    public State GetState()
    {
        return state;
    }

    //�ǐՏ�Ԃɂ���
    public void SetTracking(Vector3 pos)
    {
        //�ǂ��������[�h�ɂ���
        //state = State.Chase;
        Debug.Log("�ǐՏ��");
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);

        //�ǐՉ����n�_��ݒ�
        GoalPos = pos;
        //Debug.Log(GoalPos);

        //�ڎw�����W�ݒ�
        this.GetComponent<Enemy>().SetDestination(GoalPos);

        //�T�E���h���X�g�ƃ^�O���X�g�����Z�b�g
        //Sound_list.Clear();
        //Tag_list.Clear();
    }

    //�����Ԃɂ���
    public void SetPatrol() 
    {
        //state = State.Patrol;
        //Debug.Log("������");
        f_TrackingPlayer = false;
        this.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PATROL);
    }
}
