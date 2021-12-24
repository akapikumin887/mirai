using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject alpha;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject moji;

    private Image image;
    private Text text;

    private bool _IsLook;

    GameMng _Script;
    ItemUI _ItemUI;

    void Start()
    {
        _IsLook = false;

        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _ItemUI = _Script._Pleyer.transform.GetChild(5).GetComponent<ItemUI>();

    }

    void Update()
    {
        if (_IsLook)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("������");
                IsPaper(false);
                _IsLook = false;

                var player = _Script._Pleyer.GetComponent<PlayerControl>();
                player._Freeze = false;
                Debug.Log("������");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_IsLook)
        {
            //UI�̕\��
            _ItemUI._IsDraw = true;

            //key����������A�C�e������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsPaper(true);
                _IsLook = true;

                var player = _Script._Pleyer.GetComponent<PlayerControl>();
                player._Freeze = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
    }

    private void IsPaper(bool draw)
    {
        image = alpha.GetComponent<Image>();
        image.enabled = draw;
        image = paper.GetComponent<Image>();
        image.enabled = draw;
        text = moji.GetComponent<Text>();
        text.enabled = draw;
    }
}
