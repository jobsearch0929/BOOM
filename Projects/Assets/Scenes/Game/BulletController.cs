using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject BoomPrefab; // �����G�t�F�N�g��Prefab
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
        transform.Translate(0, 20.0f * Time.deltaTime, 0); // �����������

        if (transform.position.y > 5) // ��ʊO�ɏo���������
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        AudioSource.PlayClipAtPoint(boomSound, transform.position);
        // �Փ˂����Ƃ��ɃX�R�A���X�V����
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
        // �����G�t�F�N�g����
        GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
        Destroy(boom, 1.0f); // 1�b��ɍ폜
        Destroy(coll.gameObject); // �Փ˂����I�u�W�F�N�g�j��
        Destroy(gameObject); // �e�j��
    }
}
