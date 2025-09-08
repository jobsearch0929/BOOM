using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBgmController: MonoBehaviour
{
    public AudioClip bgmClip;          // BGM
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
