using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LisEnemy : MonoBehaviour
{
    public enum State
    {
        Patrol = 0,
        Chase,

    };
    public State state = State.Patrol;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public State GetState()
    {
        return state;
    }

    void OnTriggerEnter(Collider other)
    {
        //音を検知
        if (other.gameObject.tag == "Bell")
        {
            Debug.Log("音検知");
            //追っかけモードにする
            GetComponent<Renderer>().material.color = Color.red;
            state = State.Chase;
        }
    }
}
