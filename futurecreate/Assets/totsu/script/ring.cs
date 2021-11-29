using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    [SerializeField] float SoundSize = 0.0f; //音の範囲
    [SerializeField] float SoundTime = 1; //音の継続時間(F換算)
    float frame = 0;

    private void Start()
    {
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }

    // 当たり判定より後に消したいためLateUpdate
    void LateUpdate()
    {
        frame += Time.deltaTime;
       
        //継続時間終了後に消す
        if (frame >= SoundTime)
        {
            Destroy(this.gameObject);
        }
        
    }

    //外部スクリプトからパラメータをセットする
    public void SetBell(float soundsize,float soundtime,string tag_name = "footsteps" )
    {
        SoundSize = soundsize;
        SoundTime = soundtime / 60;
        this.tag = tag_name;
        //Debug.Log("タグ : "+ tag_name);
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }
}
