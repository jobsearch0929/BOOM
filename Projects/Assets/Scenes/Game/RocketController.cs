using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed;
    public AudioClip shootSound;   // 弾丸発射音
    private AudioSource audioSource;  // AudioSourceコンポーネント
    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.Instance != null && UIController.Instance.IsGameOver)
        {
            return;
        }
        float moveX = 0f;

        // キーボード左右キー
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }
        else
        {
            // コントローラー左スティックのX軸入力
            float joystickInput = Input.GetAxis("Horizontal");
            moveX = joystickInput;
        }
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) // spaceか□で弾が出る
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shootSound);  // 撃つ音再生
        }

        Vector2 newPosition = transform.position;

        // 範囲制限
        if (newPosition.x < -7.5f)
        {
            newPosition.x = -7.5f;
        }
        else if (newPosition.x > 7.5f)
        {
            newPosition.x = 7.5f;
        }

        transform.position = newPosition;
    }
}
