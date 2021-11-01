using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ȈՓI�ȒǏ]
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z-5.5f);
    }
}
