using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clockget : MonoBehaviour
{
    [SerializeField] private int _clockNum;
    [SerializeField] private GameObject notificationUI;
    [SerializeField] private GameObject clockUI;
    [SerializeField] private GameObject findUI;
    private GameMng _Script;

    private bool _FirstTime;    //始めてだったらここをtrueにする

    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    void Start()
    { 
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        //接触しているオブジェクトのタグが"Player"のとき
        if (other.CompareTag("Player"))
        {
            //UIの表示


                audioSource.PlayOneShot(clip);
            //KEYを押したらアイテム入手
            if (Input.GetKeyDown(KeyCode.E))
            {

                Destroy(this.gameObject);
                _Script._ClockCount++;
                Notification nof = notificationUI.GetComponent<Notification>();

            }

        }
    }
}
