using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowDeleteKey : MonoBehaviour
{
    [SerializeField] Text select_key1;
    [SerializeField] Text select_key2;
    [SerializeField] GameObject window_key1;
    [SerializeField] GameObject window_key2;
    private GameObject Delete_key1;
    private GameObject Delete_key2;

    private void Update()
    {
        if (Delete_key1 != null)
        {
            Delete_key1.GetComponent<Button>().enabled = true;
            Delete_key1.GetComponent<Animator>().enabled = true;
            Delete_key1.transform.GetChild(0).gameObject.GetComponent<Image>().color= new Color32(0, 140, 255, 255); 

            Delete_key2.GetComponent<Button>().enabled = true;
            Delete_key2.GetComponent<Animator>().enabled = true;
            Delete_key2.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(0, 140, 255, 255);
        }

        Delete_key1 = window_key1.transform.Find("GridCell-" + select_key2.text).gameObject;
        Delete_key2 = window_key2.transform.Find("GridCell-" + select_key1.text).gameObject;

        Delete_key1.GetComponent<Button>().enabled = false;
        Delete_key1.GetComponent<Animator>().enabled = false;
        Delete_key1.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(195, 195, 195, 255);

        Delete_key2.GetComponent<Button>().enabled = false;
        Delete_key2.GetComponent<Animator>().enabled = false;
        Delete_key2.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(195, 195, 195, 255);
    }

}
