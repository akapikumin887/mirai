using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAction : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] GameObject danger_score;
    [SerializeField] int select_danger_score;//�댯�x�\���̑Ώۂ�I��
    public void ValueMath()
    {
        danger_score.transform.GetChild(select_danger_score).gameObject.GetComponent<Danger>().ScoreAction(value);
    }
}
