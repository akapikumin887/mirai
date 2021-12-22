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
    private float oldframe = 0.0f;
    private float clkrot = 10.0f;

    private bool Ring = false;

    [SerializeField] AudioClip alarm;
    AudioSource audioSource;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

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

            //Debug.Log("お隣");

            audioSource.PlayOneShot(alarm);

            transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            Ring = true;
        }

        if(Ring)
        {
            Ringing(frame);
        }

        if(frame >= IdlingTime + RingingTime / 60)
        {
            Destroy(this.gameObject);
        }
    }

    private void Ringing(float frm)
    {
       
        clkrot *= -1;
        
        transform.rotation = Quaternion.Euler(clkrot, 0f, 0f); 
    }
}
