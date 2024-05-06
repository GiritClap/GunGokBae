using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Han_PlayerMovement : MonoBehaviour
{
    public float speed = 7.0f; // 플레이어의 속도를 설정합니다.

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // 수평 입력을 받습니다.
        float moveVertical = Input.GetAxis("Vertical"); // 수직 입력을 받습니다.

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // 움직임 벡터를 생성합니다.

        transform.Translate(movement * speed * Time.deltaTime); // 플레이어를 움직입니다.
    }
}