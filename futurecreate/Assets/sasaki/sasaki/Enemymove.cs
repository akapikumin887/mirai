using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymove : MonoBehaviour
{
    NavMeshAgent Player_Nav;
    GameObject Player;    
    
    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[��NavMeshAgent���擾
        Player_Nav = GetComponent<NavMeshAgent>();
        //�ړI�n�̃I�u�W�F�N�g���擾
        Player = GameObject.Find("Player" );
    }

    // Update is called once per frame
    void Update()
    {
        //�G�͈̔͂ɓ�������
        if(Enemy_hit())
        {
            GetComponent<NavMeshAgent>().isStopped = false;

            Player_Nav.SetDestination(Player.transform.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    //�͈͂ɓ�������true��Ԃ�
    public bool Enemy_hit()
    {
        Vector3 Enemy_position = this.transform.position;
        Vector3 Player_position = Player.transform.position;

        Vector3 hit;
        hit.x = Enemy_position.x - Player_position.x;
        hit.y = Enemy_position.y - Player_position.y;
        hit.z = Enemy_position.z - Player_position.z;

        if (hit.x * hit.x + hit.y * hit.y < 50)
            return true;
        else
            return false;
    }

}
