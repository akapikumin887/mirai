using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_transition : MonoBehaviour
{
    [SerializeField] int num;

    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           scene_manager.FadeOut(num);
        }
    }

    public void SceneGame()
    {
        scene_manager.FadeOut(num);
        audioSource.Stop();
    }
}
