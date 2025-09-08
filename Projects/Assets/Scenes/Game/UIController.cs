using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    int score = 0;
    GameObject scoreText;
    GameObject resultText;
    GameObject gameOverText;
    GameObject retryText;
    GameObject titleText;
    bool isGameOver = false; // �Q�[���I�[�o�[���Ă邩�ǂ���
   
    public static UIController Instance { get; private set; }
    public GameBgmController gameBgmController;

    public bool IsGameOver => isGameOver; // �O������Q�Ɨp

    public void GameOver()
    {
        gameBgmController.PlayGameOverBGM();
        resultText.SetActive(true);
        scoreText.SetActive(false);
        gameOverText.SetActive(true);
        retryText.SetActive(true);
        titleText.SetActive(true);
        gameOverText.GetComponent<TextMeshProUGUI>().text = "�Q�[���I�[�o�[";
        retryText.GetComponent<TextMeshProUGUI>().text = "�X�y�[�X��B�Ń��g���C";
        titleText.GetComponent<TextMeshProUGUI>().text = "ESC��A�Ń^�C�g���ɖ߂�";
        resultText.GetComponent<TextMeshProUGUI>().text = "�X�R�A " + score.ToString("D4");
        isGameOver = true;
        Time.timeScale = 0f; // �Q�[�����~

        // �_��
        StartCoroutine(Flash());
    }
   
    public void AddScore()
    {
        this.score += 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameBgmController = FindObjectOfType<GameBgmController>();
        Instance = this;
        resultText = GameObject.Find("Result");
        scoreText = GameObject.Find("Score");
        gameOverText = GameObject.Find("GameOver");
        retryText = GameObject.Find("Retry");
        titleText = GameObject.Find("Title");
        resultText.SetActive(false); 
        scoreText.SetActive(true);
        gameOverText.SetActive(false); // �ŏ��͔�\��
        retryText.SetActive(false);
        titleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "�X�R�A " + score.ToString("D4");
    }

    IEnumerator Flash()
    {
        while (true)
        {
            retryText.SetActive(false); // ��\��
            yield return new WaitForSecondsRealtime(0.5f); // 0.5�b�҂�
            retryText.SetActive(true); // �\��
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

}
