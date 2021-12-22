using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spritchange : MonoBehaviour
{
    private Image m_Image;
    public Sprite[] m_Sprite;
    int cardchange = 1;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
        m_Image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //// スペースキーが押された場合
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (cardchange >= 4)
        //        cardchange = 0;
        //    m_Image.sprite = m_Sprite[cardchange];
        //    cardchange++;
        //    //Debug.Log(cardchange);
        //}
    }

    public void GetCardKey()
    {
        if (!m_Image.enabled)
        {
            m_Image.enabled = true;
            return;
        }
        cardchange++;
        m_Image.sprite = m_Sprite[cardchange];
    }

}
