using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// トリガーに接触したオブジェクトが OccludeeController を持っていたら、その機能を呼んで（半）透明にする。
/// </summary>
[RequireComponent(typeof(Collider))]
public class OccluderController : MonoBehaviour
{
    /// <summary>（半）透明状態にする時にどれくらいの alpha にするか指定する</summary>
    [SerializeField, Range(0f, 1f)] float Wall_transparency = 0.2f;
    [SerializeField, Range(0f, 1f)] float Item_transparency = 0.2f;
    [SerializeField, Range(0f, 1f)] float Door_transparency = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        OccludeeController dee = other.gameObject.GetComponent<OccludeeController>();
        if (other.gameObject.tag == "wall")
        {
            if (dee)
            {
                dee.ChangeAlpha(Wall_transparency);
            }
        }
        else if (other.gameObject.tag == "item")
        {
            if (dee)
            {
                dee.ChangeAlpha(Item_transparency);
            }
        }
        else if (other.gameObject.tag == "door")
        {
            if (dee)
            {
                dee.ChangeAlpha(Door_transparency);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OccludeeController dee = other.gameObject.GetComponent<OccludeeController>();
        if (dee)
        {
            dee.ChangeAlpha2Original();
        }
    }
}
