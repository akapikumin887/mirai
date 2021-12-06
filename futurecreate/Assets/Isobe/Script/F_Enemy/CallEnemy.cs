using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    [SerializeField] float WarningDistance;
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject GAMEMASTER;
    private GameObject Player;
    private bool flag=true;
    
    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        Player = GAMEMASTER.GetComponent<GameMng>().GetPlayer(); 
        enemy_list = GAMEMASTER.GetComponent<GameMng>().GetEnemy();//���ۂɂ͂�����EnemyManager����Enemy�̃��X�g���擾
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        Debug.Log(distance);

        if (distance<WarningDistance)//�v���C���[���͈͓��ɓ�������
        {
            if (flag)
            {
                foreach (var item in enemy_list)
                {
                    item.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.PEPPER); //Enemy�̃X�e�[�g��ύX
                    item.GetComponent<Enemy>().SetDestination(this.transform.position);//Enemy���Ă�(�ړI�n�ݒ�)
                }
                flag = false;
            }
        }
        else
        {
            flag= true;
        }
    }
}
