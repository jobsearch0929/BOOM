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
        startText.GetComponent<TextMeshProUGUI>().text = "�X�y�[�X��B�ŃX�^�[�g";
        titleText.GetComponent<TextMeshProUGUI>().text = "BOOM";
    }
    IEnumerator Flash()
    {
        while (true)
        {
            startText.SetActive(false); // ��\��
            yield return new WaitForSecondsRealtime(0.5f); // 0.5�b�҂�
            startText.SetActive(true); // �\��
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
