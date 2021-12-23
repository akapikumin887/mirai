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

    private bool _FirstTime;    //�n�߂Ă������炱����true�ɂ���

    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    void Start()
    { 
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        //�ڐG���Ă���I�u�W�F�N�g�̃^�O��"Player"�̂Ƃ�
        if (other.CompareTag("Player"))
        {
            //UI�̕\��


                audioSource.PlayOneShot(clip);
            //KEY����������A�C�e������
            if (Input.GetKeyDown(KeyCode.E))
            {

                Destroy(this.gameObject);
                _Script._ClockCount++;
                Notification nof = notificationUI.GetComponent<Notification>();

            }

        }
    }
}
