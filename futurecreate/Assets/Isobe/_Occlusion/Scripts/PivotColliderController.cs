using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// m_start と m_end を繋ぐようなコライダーを作る機能を提供する。
/// 四角い棒のようなコライダーになるが、その太さを変えたい場合は Box Collider の Size.x, sixe.y を編集すること。
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class PivotColliderController : MonoBehaviour
{
    /// <summary>コライダーの始点</summary>
    [SerializeField] Transform m_start;
    /// <summary>コライダーの終点</summary>
    [SerializeField] Transform m_end;
    [SerializeField] Vector2 size;//透明化する範囲調整
    [SerializeField] float offset_z;
    private BoxCollider col;
    void Start()
    {
        col = GetComponent<BoxCollider>();
        //col.size = new Vector3(m_end.GetComponent<BoxCollider>().size.x, m_end.GetComponent<BoxCollider>().size.y, col.size.z);
        col.size = new Vector3(size.x, size.y, col.size.z);
        if (!m_start || !m_end)
        {
            Debug.LogError(name + " needs both Start and End.");
        }
    }

    void Update()
    {
        if (m_start && m_end)
        {
            // 始点と終点の中間に移動し、角度を調整し、コライダーの長さを計算して設定する
            Vector3 pivotPosition = (m_end.position + m_start.position) / 2;
            transform.position = pivotPosition;
            Vector3 dir = m_end.position - transform.position;
            //transform.forward = dir;
            float distance = Vector3.Distance(m_start.position, m_end.position);
            col.size = new Vector3(col.size.x, col.size.y, distance+offset_z);
        }
    }
}
