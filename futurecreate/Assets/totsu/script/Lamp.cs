using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    DoorController door;
    private bool doorLock = true;      //ドアのロック状況を取得するフラグ

    [SerializeField] GameObject OKLight;

    // Start is called before the first frame update
    void Start()
    {
        door = transform.parent.GetComponent<DoorController>();
        doorLock = door.GetDoorLock();
    }

    // Update is called once per frame
    void Update()
    {
        doorLock = door.GetDoorLock();
        if(!doorLock)
        {
            //f_doorLock = true;
            ////緑色に変更する
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 15);
            Instantiate(OKLight, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
