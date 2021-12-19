using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class key : MonoBehaviour
{


    bool key_code1 = false;
    bool key_code2 = false;
    //float key_dis;
    //float door_dis;

    GameObject Key;
    //GameObject[] Door;

    [SerializeField] private int _KeyNum;
    GameMng _Script;

    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("key");

        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();

        //Door = GameObject.FindGameObjectsWithTag("door");

        //door_dis = new float[] { Door.Length };


        //Door[] = GameObject.FindWithTag("door");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Key == true)
        //{
        //    key_dis = Vector3.Distance(Key.transform.position, this.transform.position);           //２点間の距離をとる
        //}

        //for (int i = 0; i < Door.Length; i++)
        //{
        //    if (Door[i] == true)
        //    {
        //        door_dis = Vector3.Distance(Door[i].transform.position, this.transform.position);
        //    }
        //}


        //if (key_dis <= 2.0f)
        //{
        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        // 衝突した相手オブジェクトを削除する
        //        Destroy(Key.gameObject);
        //        Getkey2();
        //    }
        //}

        //for (int i = 0; i < Door.Length; i++)
        //{
        //    if (door_dis <= 2.0f)                       //低レベルのカギを持っていれば
        //    {

        //        if (Input.GetKey(KeyCode.E) && key_code2 == true)
        //        {
        //            Destroy(Door[i]);
        //        }
        //    }
        //}
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("atatta");
        //接触しているオブジェクトのタグが"Player"のとき
        if(Input.GetKey(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                _Script.SetKey(true, _KeyNum);
                ////オブジェクトの色を赤に変更する
                //GetComponent<Renderer>().material.color = Color.red;
            }


        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == ("key") )
    //    {
    //        Destroy(collision.gameObject);
    //        Getkey1();
    //    }

    //    if (collision.gameObject.tag == ("door") && key_code1 == true)
    //        Destroy(collision.gameObject);

    //}


    void Getkey1()
    {
        key_code1 = true;
    }
    void Getkey2()
    {
        key_code2 = true;
    }
}
