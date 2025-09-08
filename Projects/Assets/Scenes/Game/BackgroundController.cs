using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed; // スクロール速度
    public float resetPositionY; // 下に行ったらリセットするY座標
    public float startPositionY;  // 上に戻すときのY座標（もう1枚の上に戻す）

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -scrollSpeed * Time.deltaTime, 0);

        // 一定位置より下にいったら、上に戻す
        if (transform.position.y <= resetPositionY)
        {
            transform.position = new Vector3(transform.position.x, startPositionY, transform.position.z);
        }
    }
}
