using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class key : MonoBehaviour
{
    bool key_code1 = false;
    bool key_code2 = false;
    float key_dis;
    float door_dis;

    GameObject Key;
    GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("key");
        Door = GameObject.Find("door");
    }

    // Update is called once per frame
    void Update()
    {
        if(Key == true)
        {
            key_dis = Vector3.Distance(Key.transform.position, this.transform.position);           //２点間の距離をとる
        }

        if(Door == true)
        {
            door_dis = Vector3.Distance(Door.transform.position, this.transform.position);
        }

        if (key_dis <= 2.0f)
        {
            if(Input.GetKey(KeyCode.E) )
            {
                // 衝突した相手オブジェクトを削除する
                Destroy(Key.gameObject);
                Getkey2();
            }
        }

        if (door_dis <= 2.0f)                       //低レベルのカギを持っていれば
        {
            if(Input.GetKey(KeyCode.E)&& key_code2 == true)
            {
                Destroy(Door.gameObject);
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
