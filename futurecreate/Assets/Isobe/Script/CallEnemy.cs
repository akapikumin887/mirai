using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallEnemy : MonoBehaviour
{
    List<Enemy> enemy_list = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        enemy_list = enemy_list;//���ۂɂ͂�����EnemyManager����Enemy�̃��X�g���擾
        enemy_list.Add(this.GetComponent<Enemy>());
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//�v���C���[���͈͓��ɓ�������
        {
            //Enemy�̃X�e�[�g��ύX
            foreach (var item in enemy_list)
            {
                item.SetEnemyType((Enemy.ENEMY_TYPE)2);
            }
            //Enemy���Ă�(�ړI�n�ݒ�)
            foreach (var item in enemy_list)
            {
                //item
            }
        } 
    }
}
