using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed; // �X�N���[�����x
    public float resetPositionY; // ���ɍs�����烊�Z�b�g����Y���W
    public float startPositionY;  // ��ɖ߂��Ƃ���Y���W�i����1���̏�ɖ߂��j

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -scrollSpeed * Time.deltaTime, 0);

        // ���ʒu��艺�ɂ�������A��ɖ߂�
        if (transform.position.y <= resetPositionY)
        {
            transform.position = new Vector3(transform.position.x, startPositionY, transform.position.z);
        }
    }
}
