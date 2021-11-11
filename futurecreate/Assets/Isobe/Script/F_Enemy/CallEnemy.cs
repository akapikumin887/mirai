using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject GAMEMASTER;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_list = GAMEMASTER.GetComponent<GameMng>().GetEnemy();//���ۂɂ͂�����EnemyManager����Enemy�̃��X�g���擾
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, Player.transform.position);
        Debug.Log(distance);
        if (distance<7.5f)//�v���C���[���͈͓��ɓ�������
        {
            //Enemy�̃X�e�[�g��ύX
            foreach (var item in enemy_list)
            {
                item.GetComponent<Enemy>().SetEnemyType(Enemy.ENEMY_TYPE.TRACKING);
            }
            //Enemy���Ă�(�ړI�n�ݒ�)
            foreach (var item in enemy_list)
            {
                item.GetComponent<NavMeshAgent>().SetDestination(this.transform.position);
            }
        } 
    }
}
