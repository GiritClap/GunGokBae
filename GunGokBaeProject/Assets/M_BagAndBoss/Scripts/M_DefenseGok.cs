using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_DefenseGok : MonoBehaviour
{
    public PlayerMovementGrappling playerMoveSpeed;
    public Collider melee;
    public Text bulletCntText;
    public Image crosshair;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        bulletCntText = GameObject.Find("BulletCnt").GetComponent<Text>();
        bulletCntText.text = "DefenseGok";
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        playerMoveSpeed = GameObject.Find("Player").GetComponent<PlayerMovementGrappling>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletCntText.text = "DefenseGok";

        if (Input.GetButtonDown("Fire1") && crosshair.gameObject.activeSelf == true) //��Ŭ�� -> ���� ä��
        {

            Debug.Log("Defense true");

            melee.enabled = true;

        }
        if (Input.GetButtonUp("Fire1"))
        {
            melee.enabled = false;
        }

        if (Input.GetKey(KeyCode.Mouse1) && crosshair.gameObject.activeSelf == true) //��Ŭ�� -> �����µ��� ���ý��� �۵�
        {
            playerMoveSpeed.ChangeWalkSpeed(2); //�۵��ϴ� ���� �̼� ������
            shield.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            playerMoveSpeed.ResetWalkSpeed(7);
            shield.SetActive(false);
        }
    }
}
