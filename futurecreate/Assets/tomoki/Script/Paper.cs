using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject alpha;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject moji;

    private Image image;
    private Text text;

    [SerializeField] private bool _IsLook;

    GameMng _Script;
    ItemUI _ItemUI;

    bool me;

    void Start()
    {
        _IsLook = false;

        _Script = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        _ItemUI = _Script._Pleyer.transform.GetChild(5).GetComponent<ItemUI>();

    }

    void Update()
    {
        if (me)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Gamepad.current.buttonEast.wasPressedThisFrame)
            {
                if (!_IsLook)
                {
                    IsPaper(true);
                    _IsLook = true;

                    var player = _Script._Pleyer.GetComponent<PlayerControl>();
                    player._Freeze = true;
                }
                else
                {
                    IsPaper(false);
                    _IsLook = false;

                    var player = _Script._Pleyer.GetComponent<PlayerControl>();
                    player._Freeze = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //UI‚Ì•\Ž¦
            _ItemUI._IsDraw = true;
            me = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ItemUI._IsDraw = false;
        me = false;
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
