using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockController : MonoBehaviour
{
    float fallSpeed; // óéâ∫ë¨ìx
    float rotSpeed; // âÒì]ë¨ìx
    int time = 0;

    void Start()
    {
        this.fallSpeed = Random.Range(2.0f, 4.0f);
        this.rotSpeed = 360.0f;
    }

    void Update()
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject); // â∫Ç…Ç¬Ç≠Ç∆è¡Ç¶ÇÈ
        }
    }
}
