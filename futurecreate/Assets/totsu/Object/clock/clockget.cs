using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clockget : MonoBehaviour
{
    [SerializeField] private int _clockNum;
    [SerializeField] private GameObject notificationUI;
    private GameMng _Script;

    private bool _FirstTime;    //�n�߂Ă������炱����true�ɂ���

    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    private ItemUI _ItemUI;


    void Start()
    { 
        //Component���擾
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
        //�ڐG���Ă���I�u�W�F�N�g�̃^�O��"Player"�̂Ƃ�
        if (other.CompareTag("Player"))
        {
            //UI�̕\��
            _ItemUI._IsDraw = true;

            //KEY����������A�C�e������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.PlayOneShot(clip);
                Destroy(this.gameObject);
                _Script._ClockCount++;
                Notification nof = notificationUI.GetComponent<Notification>();
                nof.CallNotification("�ڊo�܂����v�@�@����肵��");
                _ItemUI._IsDraw = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
    }

}
