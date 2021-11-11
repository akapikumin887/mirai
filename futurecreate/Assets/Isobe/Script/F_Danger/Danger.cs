using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Danger : MonoBehaviour
{
    private Text text;
    //private float alltime;
    [SerializeField] float danger_score;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        text = this.GetComponent<Text>();
        //alltime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //alltime += Time.deltaTime;
        //Debug.Log(Mathf.Sin(alltime));

        //NavMeshPath path = enemy.GetComponent<NavMeshAgent>().path; //�o�H�p�X�i�Ȃ���p���W��Vector3�z��j���擾
        //float dist = 0f;//����
        //Vector3 corner = player.transform.position; //�����̌��݈ʒu
                                            
        //for (int i = 0; i < path.corners.Length; i++) //�Ȃ���p�Ԃ̋�����ݐς��Ă���
        //{
        //    Vector3 corner2 = path.corners[i];//�p�X�̃|�W�V����
        //    dist += Vector3.Distance(corner, corner2);//�������Z
        //    corner = corner2;

        //}

        //Debug.Log(dist);

        danger_score = 5.0f/Vector3.Distance(enemy.transform.position,player.transform.position)*100.0f;   //���A���^�C���ϓ�

        danger_score = Mathf.Clamp(danger_score, 0.0f, 100.0f);
    
        Debug.Log(danger_score);
        text.text = "�댯�x:"+(int)danger_score+"%";                         //�e�L�X�g���e
    }
    public void ScoreAction(int value)
    {
        danger_score = Mathf.Clamp(danger_score + value, 0.0f, 100.0f);
    }
}
