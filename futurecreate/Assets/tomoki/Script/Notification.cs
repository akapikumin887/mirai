using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    private Text _Text;
    private RectTransform _RectTransform;
    private bool _IsAppear;
    private bool _IsMove;

    private float _Time;
    private float _TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        _Text = transform.GetChild(0).gameObject.GetComponent<Text>();
        _Text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        _RectTransform = GetComponent<RectTransform>();

        _IsAppear = false;
        _IsMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        _Time += Time.deltaTime;
        if (_Time < 1.0f / 60)
            return;
        else
            _Time = 0.0f;

        //“oê
        if (_IsAppear && _IsMove)
        {
            Appeared();
            if (_RectTransform.position.x < 1600.0f)
            {
                _IsMove = false;
                _TimeCount = 0.0f;
            }
        }
        //‘Þê
        else if (!_IsAppear && _IsMove)
        {
            Disappeared();
            if (_RectTransform.position.x > 2210.0f)
            {
                _IsMove = false;
                _TimeCount = 0.0f;
            }
        }

    }


    private IEnumerator PlayNotification(string sentence)
    {
        _Text.text = sentence;

        _IsAppear = true;
        _IsMove = true;

        yield return new WaitForSeconds(4);

        _IsAppear = false;
        _IsMove = true;
    }

    public void CallNotification(string sentence)
    {
        StartCoroutine("PlayNotification",sentence);
    }

    private void Appeared()
    {
        _TimeCount += 1.0f / 60 * 0.05f;

        float ease = 1 - Mathf.Pow(1.0f - _TimeCount, 5);
        if(_RectTransform.position.x - (ease * 810) < 1600.0f)
            _RectTransform.position = new Vector3(1600.0f, _RectTransform.position.y, _RectTransform.position.z);
        else
            _RectTransform.position = new Vector3(_RectTransform.position.x - (ease * 810), _RectTransform.position.y, _RectTransform.position.z);
    }

    private void Disappeared()
    {
        _TimeCount += 1.0f / 60 * 0.05f;

        float ease = 1 - Mathf.Pow(1.0f - _TimeCount, 5);
        if (_RectTransform.position.x - (ease * 810) > 2210.0f)
            _RectTransform.position = new Vector3(2210.0f, _RectTransform.position.y, _RectTransform.position.z);
        else
            _RectTransform.position = new Vector3(_RectTransform.position.x + (ease * 810), _RectTransform.position.y, _RectTransform.position.z);
    }


}
