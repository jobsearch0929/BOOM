using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
    public Image Fade;
    public float fadeTime = 1f; // フェード時間
    public string SceneName;

    private bool isChange = false;

    void Start()
    {
        // フェードイン開始
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (UIController.Instance.IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2")) // スペースか×でリトライ
            {
                Retry();
            }
        }

        if (UIController.Instance.IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3") && !isChange) // 繰り返さない     エスケープかAでスタート
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneName);
            }
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator FadeIn()
    {
        float t = fadeTime;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeTime;
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0f);
    }

    void SetAlpha(float alpha)
    {
        if (alpha < 0f) alpha = 0f;
        if (alpha > 1f) alpha = 1f;

        Color c = Fade.color;
        c.a = alpha;
        Fade.color = c;
    }
}
