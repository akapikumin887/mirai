using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    [SerializeField] float SoundSize = 0.0f; //音の範囲
    [SerializeField] int SoundTime = 1; //音の継続時間(F換算)
    int frame = 0;

    private void Start()
    {
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }

    // 当たり判定より後に消したいためLateUpdate
    void LateUpdate()
    {
        if (SoundTime >= 1)
        {
            //継続時間終了後に消す
            if (frame++ >= SoundTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //外部スクリプトからパラメータをセットする
    public void SetBell(float soundsize,int soundtime)
    {
        SoundSize = soundsize;
        SoundTime = soundtime;
        this.transform.localScale = new Vector3(SoundSize, SoundSize, SoundSize);
    }
}
