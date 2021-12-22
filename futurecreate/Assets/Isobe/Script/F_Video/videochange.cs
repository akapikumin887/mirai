using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class videochange : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    [SerializeField] VideoClip loop;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.clip = loop;
            videoPlayer.isLooping = true;
        }
    }

 
}
