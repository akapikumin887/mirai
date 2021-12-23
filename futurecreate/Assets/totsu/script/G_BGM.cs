using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_BGM : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void OnDestroy()
    {
        audioSource.Stop();
    }
}
