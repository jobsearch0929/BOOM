using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleSceneManager : MonoBehaviour
{
    public Image Fade; // 黒画面
    public float fadeTime = 1f; // フェード時間
    public string SceneName;

    private bool isChange = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2") && !isChange) // 繰り返さない     スペースか×でスタート
        {
            StartCoroutine(FadeOut());
        }
    }
  

    public IEnumerator FadeOut() // Bで呼び出される
    {
        isChange = true;
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = t / fadeTime; // alphaを0~1
            SetAlpha(alpha);
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
    }

    void SetAlpha(float alpha)
    {
        if (alpha < 0f) alpha = 0f;
        if (alpha > 1f) alpha = 1f;

        Color c = Fade.color; // 現在の色
        c.a = alpha;　
        Fade.color = c; // 書き換えた色
    }
}
