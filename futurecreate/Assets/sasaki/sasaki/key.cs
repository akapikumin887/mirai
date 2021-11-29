using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class key : MonoBehaviour
{
    NavMeshAgent Player_Nav;
    GameObject Player;
    GameObject GAMEMASTER;
    GameMng game_mng;

    bool key_code1 = false;
    bool key_code2 = false;

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
        {         //float player_hitx = 0.0f;
                  //float player_hitz = 0.0f;
                  //float player_hit = 0.0f;

            //player_hitx = (this.transform.position.x - Player.transform.position.x) * (this.transform.position.x - Player.transform.position.x);
            //player_hitz = (this.transform.position.z - Player.transform.position.z) * (this.transform.position.z - Player.transform.position.z);

            //player_hit = (player_hitx + player_hitz) * (player_hitx + player_hitz);

            //if(player_hit < 5)
            //{
            //    
            //}
        }
    }
    void OnCollisionEnter(Collision collision)          //キーと当たった時オブジェクトを消す
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collision.gameObject.name == "key")         //キーに当たったら
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            Getkey2();
        }

        if(collision.gameObject.name == "door")         //ドアに当たったら
        {
            if(key_code1 == true)                       //低レベルのカギを持っていれば
            {
                Destroy(collision.gameObject);
            }
        }
    }

    void Getkey1()
    {
        key_code1 = true;
    }
    void Getkey2()
    {
        key_code2 = true;
    }
}
