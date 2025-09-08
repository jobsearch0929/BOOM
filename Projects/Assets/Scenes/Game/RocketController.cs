using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed;
    public AudioClip shootSound;   // �e�۔��ˉ�
    private AudioSource audioSource;  // AudioSource�R���|�[�l���g
    // Start is called before the first frame update
    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
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

        // �L�[�{�[�h���E�L�[
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
            // �R���g���[���[���X�e�B�b�N��X������
            float joystickInput = Input.GetAxis("Horizontal");
            moveX = joystickInput;
        }
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) // space�����Œe���o��
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shootSound);  // �����Đ�
        }

        Vector2 newPosition = transform.position;

        // �͈͐���
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
