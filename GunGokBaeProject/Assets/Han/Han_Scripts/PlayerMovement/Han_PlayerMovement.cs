using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Han_PlayerMovement : MonoBehaviour
{
    public float speed = 7.0f; // �÷��̾��� �ӵ��� �����մϴ�.

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // ���� �Է��� �޽��ϴ�.
        float moveVertical = Input.GetAxis("Vertical"); // ���� �Է��� �޽��ϴ�.

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // ������ ���͸� �����մϴ�.

        transform.Translate(movement * speed * Time.deltaTime); // �÷��̾ �����Դϴ�.
    }
}