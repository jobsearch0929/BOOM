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
    bool isGameOver = false; // ゲームオーバーしてるかどうか
   
    public static UIController Instance { get; private set; }
    public GameBgmController gameBgmController;

    public bool IsGameOver => isGameOver; // 外部から参照用

    public void GameOver()
    {
        gameBgmController.PlayGameOverBGM();
        resultText.SetActive(true);
        scoreText.SetActive(false);
        gameOverText.SetActive(true);
        retryText.SetActive(true);
        titleText.SetActive(true);
        gameOverText.GetComponent<TextMeshProUGUI>().text = "ゲームオーバー";
        retryText.GetComponent<TextMeshProUGUI>().text = "スペースかBでリトライ";
        titleText.GetComponent<TextMeshProUGUI>().text = "ESCかAでタイトルに戻る";
        resultText.GetComponent<TextMeshProUGUI>().text = "スコア " + score.ToString("D4");
        isGameOver = true;
        Time.timeScale = 0f; // ゲームを停止

        // 点滅
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
        gameOverText.SetActive(false); // 最初は非表示
        retryText.SetActive(false);
        titleText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "スコア " + score.ToString("D4");
    }

    IEnumerator Flash()
    {
        while (true)
        {
            retryText.SetActive(false); // 非表示
            yield return new WaitForSecondsRealtime(0.5f); // 0.5秒待つ
            retryText.SetActive(true); // 表示
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

}
