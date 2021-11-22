using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector3 Center;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //簡易的な追従
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z-5.5f);
        //Debug.Log(transform.position);

        test();
    }

    void test ()
    {


        RaycastHit hit;

        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;
        Debug.DrawRay(Player.transform.position, Player_direction* 50, Color.red, 100000, true);

        if (Physics.Raycast(this.transform.position, Player_direction, out hit, Mathf.Infinity))            //プレイヤーからカメラにレイを飛ばす
        {
            //GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

            Debug.Log(hit.collider.tag);


            if (hit.collider.tag == "wall")
            {
                var a = hit.collider.tag;
                hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                Debug.Log("atatta"); 
            }

            if (hit.collider.tag == "Player")
            {
                GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
                foreach (GameObject wall in walls)
                {
                    //hit.collider.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                    wall.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }

        }
        else
        {
            //hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

    }
}
