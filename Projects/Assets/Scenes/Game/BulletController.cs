using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject BoomPrefab; // 爆発エフェクトのPrefab
    public AudioClip boomSound;
    private AudioSource boomAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        boomAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 20.0f * Time.deltaTime, 0); // 球を上方向へ

        if (transform.position.y > 5) // 画面外に出たら消える
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        AudioSource.PlayClipAtPoint(boomSound, transform.position);
        // 衝突したときにスコアを更新する
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
        // 爆発エフェクト生成
        GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
        Destroy(boom, 1.0f); // 1秒後に削除
        Destroy(coll.gameObject); // 衝突したオブジェクト破壊
        Destroy(gameObject); // 弾破壊
    }
}
