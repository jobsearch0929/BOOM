using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleUIcontroller : MonoBehaviour
{
    GameObject titleText;
    GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        titleText = GameObject.Find("Title");
        startText = GameObject.Find("Start");
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {
        startText.GetComponent<TextMeshProUGUI>().text = "スペースかBでスタート";
        titleText.GetComponent<TextMeshProUGUI>().text = "BOOM";
    }
    IEnumerator Flash()
    {
        while (true)
        {
            startText.SetActive(false); // 非表示
            yield return new WaitForSecondsRealtime(0.5f); // 0.5秒待つ
            startText.SetActive(true); // 表示
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
