using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] DoorController door;
    private bool doorLock = true;      //ドアのロック状況を取得するフラグ
    private bool f_doorLock = false;    //色変更フラグ

    [SerializeField] GameObject OKLight;

    // Start is called before the first frame update
    void Start()
    {
        doorLock = door.GetDoorLock();
    }

    // Update is called once per frame
    void Update()
    {
        if(!f_doorLock
            && !doorLock)
        {
            //f_doorLock = true;
            ////緑色に変更する
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 15);
            Instantiate(OKLight, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
