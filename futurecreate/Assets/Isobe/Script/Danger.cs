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

        //NavMeshPath path = enemy.GetComponent<NavMeshAgent>().path; //経路パス（曲がり角座標のVector3配列）を取得
        //float dist = 0f;//距離
        //Vector3 corner = player.transform.position; //自分の現在位置
                                            
        //for (int i = 0; i < path.corners.Length; i++) //曲がり角間の距離を累積していく
        //{
        //    Vector3 corner2 = path.corners[i];//パスのポジション
        //    dist += Vector3.Distance(corner, corner2);//距離加算
        //    corner = corner2;

        //}

        //Debug.Log(dist);

        danger_score = 5.0f/Vector3.Distance(enemy.transform.position,player.transform.position)*100.0f;   //リアルタイム変動

        danger_score = Mathf.Clamp(danger_score, 0.0f, 100.0f);
    
        Debug.Log(danger_score);
        text.text = "危険度:"+(int)danger_score+"%";                         //テキスト内容
    }
    public void ScoreAction(int value)
    {
        danger_score = Mathf.Clamp(danger_score + value, 0.0f, 100.0f);
    }
}
