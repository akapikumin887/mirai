using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyEnter : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text button;
    private string name;
    public void SelectKey()
    {
        int num = text.text.Length;
        num -= 9;
        name = text.text.Substring(9, num);
        button.text = name;
    }
}
