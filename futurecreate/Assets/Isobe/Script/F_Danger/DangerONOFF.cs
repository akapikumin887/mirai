using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerONOFF : MonoBehaviour
{
    private bool on_off=true;//true���ƕ\��
    [SerializeField] GameObject danger_score;
    public void OnoffSet()
    {
        on_off = !on_off;//ONOFF�؂�ւ�
        danger_score.SetActive(on_off);
    }
}
