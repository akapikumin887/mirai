using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeySet : MonoBehaviour
{
    [SerializeField] Text text;
    private string name;

    private void Start()
    {
        int num = this.gameObject.name.Length;
        num -= 9;
        name = this.gameObject.name.Substring(9, num);
    }
    public void SelectKey()
    {
        text.text = "SetKey : " + name;
    }
}
