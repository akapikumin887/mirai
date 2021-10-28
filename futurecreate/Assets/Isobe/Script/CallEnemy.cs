using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallEnemy : MonoBehaviour
{
    List<GameObject> enemy_list = new List<GameObject>();
    private GameObject enemys;
    // Start is called before the first frame update
    void Start()
    {
        enemy_list = enemys.GetComponent<EnemyManager>().GetEnemy();//���ۂɂ͂�����EnemyManager����Enemy�̃��X�g���擾
       
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//�v���C���[���͈͓��ɓ�������
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
