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

    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("key");

        //Door = GameObject.FindGameObjectsWithTag("door");

        //door_dis = new float[] { Door.Length };


        //Door[] = GameObject.FindWithTag("door");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Key == true)
        //{
        //    key_dis = Vector3.Distance(Key.transform.position, this.transform.position);           //�Q�_�Ԃ̋������Ƃ�
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
        //        // �Փ˂�������I�u�W�F�N�g���폜����
        //        Destroy(Key.gameObject);
        //        Getkey2();
        //    }
        //}

        //for (int i = 0; i < Door.Length; i++)
        //{
        //    if (door_dis <= 2.0f)                       //�჌�x���̃J�M�������Ă����
        //    {

        //        if (Input.GetKey(KeyCode.E) && key_code2 == true)
        //        {
        //            Destroy(Door[i]);
        //        }
        //    }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("key") )
        {
            Destroy(collision.gameObject);
            Getkey1();
        }

        if (collision.gameObject.tag == ("door") && key_code1 == true)
            Destroy(collision.gameObject);

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
