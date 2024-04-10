using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JumpMap : MonoBehaviour
{
    public GameObject foot;
    private float timer;
    private float spawnTime = 2f; // ������ �����Ǵ� �ð� ����
    private float disappearTime = 2f; // ������ ������� �ð� ����
    private bool isFootActive = false;


    public GameObject foot2;

    public float moveSpeed = 1f; // ������ �̵� �ӵ�
    public float maxDistance = 2f; // ������ �ִ� �̵� �Ÿ�
    public GameObject foot3; // ���� GameObject
    private Vector3 initialPosition; // ������ �ʱ� ��ġ
    private bool moveRight = true; // ������ �ʱ� �̵� ����

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

    

    

