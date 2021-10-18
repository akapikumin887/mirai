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
        //�ړI�n��ݒ�
        Player_Nav.SetDestination(Player.transform.position);
    }
}
