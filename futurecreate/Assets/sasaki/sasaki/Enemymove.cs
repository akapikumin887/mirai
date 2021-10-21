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
        //プレイヤーのNavMeshAgentを取得
        Player_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Player = GameObject.Find("Player" );
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Enemy_position = this.transform.position;
        Vector3 Player_position = Player.transform.position;

        Vector3 hit;
        hit.x = Enemy_position.x - Player_position.x;
        hit.y = Enemy_position.y - Player_position.y;
        hit.z = Enemy_position.z - Player_position.z;

        if(hit.x * hit.x + hit.y * hit.y < 50)
        {
            GetComponent<NavMeshAgent>().isStopped = false;

            Player_Nav.SetDestination(Player.transform.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            //Stopping distance
            //NavMeshAgent.Stop(stopUpdates: true);
        }
    }
}
