using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] DoorController door;
    private bool doorLock = true;      //�h�A�̃��b�N�󋵂��擾����t���O
    private bool f_doorLock = false;    //�F�ύX�t���O

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
            ////�ΐF�ɕύX����
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 15);
            Instantiate(OKLight, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
