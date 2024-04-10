using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JumpMap : MonoBehaviour
{
    public GameObject foot;
    private float timer;
    private float spawnTime = 2f; // 발판이 생성되는 시간 간격
    private float disappearTime = 2f; // 발판이 사라지는 시간 간격
    private bool isFootActive = false;


    public GameObject foot2;

    public float moveSpeed = 1f; // 발판의 이동 속도
    public float maxDistance = 2f; // 발판의 최대 이동 거리
    public GameObject foot3; // 발판 GameObject
    private Vector3 initialPosition; // 발판의 초기 위치
    private bool moveRight = true; // 발판의 초기 이동 방향

    void Start()
    {
        if (foot3 == null)
        {
            Debug.LogError("Foot3 GameObject is not assigned in MovingPlatform script.");
            return;
        }

        initialPosition = foot3.transform.position;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (!isFootActive && timer >= spawnTime)
        {
            foot.SetActive(true);
            isFootActive = true;
            timer = 0f;
        }
        else if (isFootActive && timer >= disappearTime)
        {
            foot.SetActive(false);
            isFootActive = false;
            timer = 0f;
        }

        MovingVertical();
        MovingHorizontal();
    }
    void MovingVertical()
    {
        float newY = Mathf.PingPong(Time.time * 2, 10) +5; 
        foot2.transform.position = new Vector3(foot2.transform.position.x, newY, foot2.transform.position.z);
    }

    void MovingHorizontal()
    {
        Vector3 newPosition = foot3.transform.position;

        float moveAmount = moveSpeed * Time.deltaTime;
        if (moveRight)
        {
            newPosition.z += moveAmount;
            if (newPosition.z >= initialPosition.z + maxDistance)
            {
                moveRight = false;
            }
        }
        else
        {
            newPosition.z -= moveAmount;
            if (newPosition.z <= initialPosition.z - maxDistance)
            {
                moveRight = true;
            }
        }

        foot3.transform.position = newPosition;
    }

}

    

    

