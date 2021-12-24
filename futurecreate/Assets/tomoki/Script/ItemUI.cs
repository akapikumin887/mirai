using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private MeshRenderer _UI;
    private MeshRenderer _ChildUI;
    public bool _IsDraw { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        _UI = transform.GetChild(0).GetComponent<MeshRenderer>();
        _ChildUI = transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>();
        _UI.enabled = false;
        _IsDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
        if (_IsDraw)
            _UI.enabled = _ChildUI.enabled = true;
        else
            _UI.enabled = _ChildUI.enabled = false;
    }

    public void DrawUI()
    {
        _IsDraw = true;
        _UI.enabled = true;
        _ChildUI.enabled = true;
    }
}
