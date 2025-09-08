using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBgmController : MonoBehaviour
{
    public AudioClip bgmClip;  // BGM
    public AudioClip gameOverClip; // ゲームオーバーBGM
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントを取得
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
