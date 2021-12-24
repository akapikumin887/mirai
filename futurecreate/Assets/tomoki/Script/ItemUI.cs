using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public MeshRenderer _UI { set; get; }
    private bool _IsDraw;

    // Start is called before the first frame update
    void Start()
    {
        _UI =transform.GetChild(0).GetComponent<MeshRenderer>();
        _UI.enabled = false;
        _IsDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
    }

    public void DrawUI()
    {
        _IsDraw = true;
        _UI.enabled = true;
    }
}
