using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Vector3 Center;

    List<Collider> colliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        test();
    }

    void test ()
    {
        RaycastHit hit;

        Vector3 Player_direction = (Player.transform.position - this.transform.position).normalized;
        //Debug.DrawRay(Player.transform.position, Player_direction* 50, Color.red, 100000, true);

        if (Physics.Raycast(this.transform.position, Player_direction, out hit, Mathf.Infinity))            //�v���C���[����J�����Ƀ��C���΂�
        {

            if (hit.collider.tag == "wall")
            {
                //�^�O�����Ă���
                if(colliders.Count == 0)
                {
                    colliders.Add(hit.collider);
                    hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                    return;
                }
                //��ׂ�
                hit.collider.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                foreach (Collider c in colliders)
                {
                    if(c == hit.collider)   //���������Ă�����
                    {
                        continue;
                    }
                }
            }
        }

    }
}
