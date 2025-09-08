using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleSceneManager : MonoBehaviour
{
    public Image Fade; // �����
    public float fadeTime = 1f; // �t�F�[�h����
    public string SceneName;

    private bool isChange = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2") && !isChange) // �J��Ԃ��Ȃ�     �X�y�[�X���~�ŃX�^�[�g
        {
            StartCoroutine(FadeOut());
        }
    }
  

    public IEnumerator FadeOut() // B�ŌĂяo�����
    {
        isChange = true;
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = t / fadeTime; // alpha��0~1
            SetAlpha(alpha);
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
    }

    void SetAlpha(float alpha)
    {
        if (alpha < 0f) alpha = 0f;
        if (alpha > 1f) alpha = 1f;

        Color c = Fade.color; // ���݂̐F
        c.a = alpha;�@
        Fade.color = c; // �����������F
    }
}
