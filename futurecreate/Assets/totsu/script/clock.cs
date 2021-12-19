using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    [SerializeField] GameObject Bell; //音オブジェクト
    [SerializeField] float IdlingTime = 5.0f;
    [SerializeField] float Size = 100.0f;
    [SerializeField] float RingingTime = 300.0f;


    private float frame = 0.0f;
    private bool Ring = false;

    // Update is called once per frame
    void Update()
    {
        frame += Time.deltaTime;

        //一定時間経過後に鳴らす
        if (frame >= IdlingTime && !Ring)
        {
            GameObject bell = Instantiate(Bell, transform.position, Quaternion.identity) as GameObject;
            //スクリプトオブジェクトを取得
            ring b = bell.GetComponent<ring>();
            //音の設定(規模、なっている時間(f),タグ)
            b.SetBell(Size, RingingTime, "Bell");

            Debug.Log("お隣");

            Ring = true;
        }

        if(frame >= IdlingTime + RingingTime / 60)
        {
            Destroy(this.gameObject);
        }
    }
}
