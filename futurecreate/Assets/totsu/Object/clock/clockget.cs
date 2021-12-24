using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clockget : MonoBehaviour
{
    [SerializeField] private int _clockNum;
    [SerializeField] private GameObject notificationUI;
    private GameMng _Script;

    private bool _FirstTime;    //始めてだったらここをtrueにする

    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    private ItemUI _ItemUI;


    void Start()
    { 
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _ItemUI = _Script._Pleyer.transform.GetChild(5).GetComponent<ItemUI>();
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
            _ItemUI._IsDraw = true;

            //KEYを押したらアイテム入手
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(clip);
                Destroy(this.gameObject);
                _Script._ClockCount++;
                Notification nof = notificationUI.GetComponent<Notification>();
                nof.CallNotification("目覚まし時計　　を入手した");
                _ItemUI._IsDraw = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
    }

}
