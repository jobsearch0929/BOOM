using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBgmController : MonoBehaviour
{
    public AudioClip bgmClip;  // BGM
    public AudioClip gameOverClip; // �Q�[���I�[�o�[BGM
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.Play();
    }
    public void PlayGameOverBGM()
    {
        audioSource.Stop();
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}
