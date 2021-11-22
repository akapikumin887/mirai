using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Linq;
public class Danger : MonoBehaviour
{
    //private float alltime;
    [SerializeField] GameObject player;
    [SerializeField] float range_max;
    [SerializeField] float timelimit;//�X�V����
    private List<GameObject> enemy_list = new List<GameObject>();
    private List<float> danger_score;
    private GameObject GAMEMASTER;
    private Text text;
    private UIPolygon uipol;
    private int sides;
    private float time;

    // Start is called before the first frame update

    void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
        GAMEMASTER = GameObject.FindGameObjectWithTag("Manager");
        enemy_list = GAMEMASTER.GetComponent<GameMng>().GetEnemy();//���ۂɂ͂�����EnemyManager����Enemy�̃��X�g���擾
        uipol = this.GetComponent<UIPolygon>();
        sides = uipol.Sides;
        danger_score = new List<float>(sides) { };

        for (int i = 0; i < danger_score.Capacity; i++)
        {
            danger_score.Add(0.0f);
        }

        time = 0;
        //alltime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;


        if (time > timelimit)
        {
            for (int i = 0; i < sides; i += 4)
            {
                List<float> enemy_length = new List<float>();//�͈͓��̓G�i�[�p

                //�͈͓�Enemy����
                foreach (var item in enemy_list)
                {
                    float angle = 360.0f / sides * i;
                    float offset = 360.0f / sides * 2.0f;
                    float plus = angle + offset > 360.0f ? angle + offset - 360.0f : angle + offset;
                    float minus = angle - offset < 0.0f ? angle - offset + 360.0f : angle - offset;

                    Debug.Log(GetAngle(player.transform.position, enemy_list[0].transform.position));


                    if (i == 0)//i��0�̎�����0�x��菬������360�x�ȉ��ɕς��̂ŕʘg
                    {
                        //�͈͓��m�F
                        if (GetAngle(player.transform.position, item.transform.position) >= minus || GetAngle(player.transform.position, item.transform.position) <= plus)
                        {
                            if (GetNavDistance(item) < range_max)
                            {
                                enemy_length.Add(GetNavDistance(item));//�ΏۂɂȂ�G��ǉ�
                            }
                        }
                    }
                    else
                    {
                        
                        if (GetAngle(player.transform.position, item.transform.position) >= minus && GetAngle(player.transform.position, item.transform.position) <= plus)
                        {
                            if (GetNavDistance(item) < range_max)
                            {
                                enemy_length.Add(GetNavDistance(item));
                            }
                        }
                    }
                }

                //�͈͓�trap����
                {/*
            foreach (var item in trap_list)
            {
                float angle = 360 / sides * i;
                float offset = 360 / sides * 2;
                float plus = angle + offset > 360.0f ? angle + offset - 360.0f : angle + offset;
                float minus = angle - offset < 0.0f ? angle - offset + 360.0f : angle - offset;

                //�͈͓��m�F
                if (GetAngle(player.transform.position, item.transform.position) >= minus && GetAngle(player.transform.position, item.transform.position) <= plus)
                {
                    if (GetNavDistance(item) < range_max)
                    {
                        trap_length.Add(GetNavDistance(item));
                    }
                }
            }
            */
                }

                //�O���t�̏���������
                if (enemy_length.Count == 0)
                {
                    danger_score[i] = 0.0f;
                    uipol.SetDistance(0.5f, i);
                    continue;
                }

                //�댯�x�̌v�Z
                float value = 0.0f;
                enemy_length.Sort();

                foreach (var item in enemy_length)
                {
                    value += (1 - item / range_max) / enemy_length.Count;//+EnemyState
                }
                value = Mathf.Clamp((1 - enemy_length[0] / range_max) * 100.0f + value * 10.0f, 0.0f, 100.0f);
                danger_score[i] = value;

                uipol.SetDistance(0.5f+danger_score[i]/200.0f, i);
            }

            //�]�g�v�Z
            //for(int i = 2; i < sides; i += 4)
            {

            }

            for(int i = 1; i < sides; i += 2)
            {
                uipol.SetDistance(Random.Range(0.4f, 0.5f), i);
            }

            text.text = (int)danger_score.Max()+"%";//�e�L�X�g���e
            time = 0;
        }


        {//for (int i = 0; i < sides; i += 4)
         //{
         //    List<float> enemy_length = new List<float>();//�͈͓��̓G�i�[�p

            //    //�͈͓�Enemy����
            //    foreach (var item in enemy_list)
            //    {
            //        float angle = 360 / sides * i;
            //        float offset = 360 / sides * 2;
            //        float plus = angle + offset > 360.0f ? angle + offset - 360.0f : angle + offset;
            //        float minus = angle - offset < 0.0f ? angle - offset + 360.0f : angle - offset;

            //        //�͈͓��m�F
            //        if (GetAngle(player.transform.position, item.transform.position) >= minus && GetAngle(player.transform.position, item.transform.position) <= plus)
            //        {
            //            if (GetNavDistance(item) < range_max)
            //            {
            //                enemy_length.Add(GetNavDistance(item));
            //            }
            //        }
            //    }

            //    //�͈͓�trap����
            //    {/*
            //    foreach (var item in trap_list)
            //    {
            //        float angle = 360 / sides * i;
            //        float offset = 360 / sides * 2;
            //        float plus = angle + offset > 360.0f ? angle + offset - 360.0f : angle + offset;
            //        float minus = angle - offset < 0.0f ? angle - offset + 360.0f : angle - offset;

            //        //�͈͓��m�F
            //        if (GetAngle(player.transform.position, item.transform.position) >= minus && GetAngle(player.transform.position, item.transform.position) <= plus)
            //        {
            //            if (GetNavDistance(item) < range_max)
            //            {
            //                trap_length.Add(GetNavDistance(item));
            //            }
            //        }
            //    }
            //    */
            //    }


            //    //�댯�x�̌v�Z
            //    float value = 0.0f;
            //    enemy_length.Sort();
            //    foreach (var item in enemy_length)
            //    {
            //        value += (1 - item / range_max) / enemy_length.Count;//+EnemyState
            //    }
            //    value = Mathf.Clamp((1 - enemy_length[0] / range_max) * 100.0f + value * 10.0f, 0.0f, 100.0f);
            //    danger_score[i] = value;
            //}
        }
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

        //danger_score = 5.0f/Vector3.Distance(enemy.transform.position,player.transform.position)*100.0f;   //���A���^�C���ϓ�

        //danger_score = Mathf.Clamp(danger_score, 0.0f, 100.0f);

        //Debug.Log(danger_score);
        //text.text = "�댯�x:"+(int)danger_score+"%";                         //�e�L�X�g���e
    }
    }
    public void ScoreAction(int value)
    {
        //danger_score = Mathf.Clamp(danger_score + value, 0.0f, 100.0f);
    }

    private float GetAngle(Vector3 start, Vector3 target)
    {

        Vector2 dt = new Vector2(target.x - start.x, target.z - start.z);
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        if (degree < 0)
        {
            degree += 360;
        }

        return degree;
    }

    private float GetNavDistance(GameObject enemy)
    {
        //NavMeshPath path=null;
        //NavMesh.CalculatePath(enemy.transform.position, player.transform.position, NavMesh.AllAreas, path);
        NavMeshPath path = enemy.GetComponent<Enemy>().GetToPlayerPath(); //�o�H�p�X�i�Ȃ���p���W��Vector3�z��j���擾

        //NavMeshPath path = enemy.GetComponent<NavMeshAgent>().path; //�o�H�p�X�i�Ȃ���p���W��Vector3�z��j���擾
        float dist = 0f;//����
        Vector3 corner = player.transform.position; //�����̌��݈ʒu

        for (int i = 0; i < path.corners.Length; i++) //�Ȃ���p�Ԃ̋�����ݐς��Ă���
        {
            Vector3 corner2 = path.corners[i];//�p�X�̃|�W�V����
            dist += Vector3.Distance(corner, corner2);//�������Z
            corner = corner2;

        }
        return dist;
    }
}