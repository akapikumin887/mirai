using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CameraManager : MonoBehaviour
{
    NavMeshAgent Player_Nav;
    GameObject Player;
    GameObject GAMEMASTER;
    GameMng game_mng;


    // Start is called before the first frame update
    void Start()
    {
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        game_mng = GAMEMASTER.GetComponent<GameMng>();

        // 目的地のオブジェクトを取得
        Player = game_mng.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.transform.position);

        test();
    }

    void test ()
    {
        RaycastHit hit;

        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;
        Debug.DrawRay(Player.transform.position, Player_direction* 50, Color.red, 100000, true);

        if (Physics.Raycast(this.transform.position, Player_direction, out hit, Mathf.Infinity))            //プレイヤーからカメラにレイを飛ばす
        {
            //GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            //Debug.Log(hit.collider.tag);


            if (hit.collider.tag == "wall")
            {
                var a = hit.collider.tag;
                hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                Debug.Log("atatta"); 
            }

            if (hit.collider.tag == "Player")
            {
                GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
                foreach (GameObject wall in walls)
                {
                    //hit.collider.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                    wall.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }

        }
        else
        {
            //hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

    }
}
