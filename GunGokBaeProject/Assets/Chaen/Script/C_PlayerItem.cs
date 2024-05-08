using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
using UnityEngine.SocialPlatforms;

public class C_PlayerItem : MonoBehaviour
{
    public GameObject gun;
    public GameObject pick;
    [Header("Special Guns in Canvas")] // �÷��̾� ������ �� Ư���� ������Ʈ��
    public GameObject[] special_Gun = new GameObject[6]; // 0 = ����, 1 = ������, 2 = �׶��� ��, 3 = �� ��, 4 = ���� ��, 5 = ���� ��
    [Header("Special Guns in Model")] // ���� �� Ư���� ������Ʈ��
    public GameObject[] m_Special_Gun = new GameObject[6]; // 0 = ����, 1 = ������, 2 = �׶��� ��, 3 = �� ��, 4 = ���� ��, 5 = ���� ��
    [Header("Original Guns in Model")] // ���� �� �⺻�� ������Ʈ��
    public GameObject[] m_Original_Gun; // 0 = ����, 1 = �ӽŰ�, 2 = ����, 3 = ��������
    [Header("Pick in Model")]
    public GameObject m_Pick;

    public int specialNum;

    public GameObject[] player_ItemNum = new GameObject[3];
    public GameObject nowItem;

    public Text bulletCntText;



    [Header("Original Gun Rigs")] // �⺻�� �ȸ��
    public M_GunManager gunManager;
    public Rig[] oriRigs; // 0 = ����, 1 = �ӽŰ�, 2 = ����, 3 = ��������

    [Header("Special Gun Rigs")] // Ư���� �ȸ��
    public Rig[] specRigs; // 0 = ����, 1 = ������, 2 = �׶��� ��, 3 = �� ��, 4 = ���� ��, 5 = ���� ��

    //public GameObject nowSpecialGun;

    int currentSpecialGun = 0; // 0 = ����, 1 = ������, 2 = �׶��� ��, 3 = �� ��, 4 = ���� ��, 5 = ���� ��



    // ä�� UI �κ�
    public Image itemFrameImg1; // �⺻ �� ���� �׵θ�
    public Image itemFrameImg2; // ��� ���� �׵θ�
    public Image itemFrameImg3; // Ư�� �� ���� �׵θ�

    public Image nowspecialGunImg;
    public Sprite [] specialGunImg = new Sprite[6]; // 0 = ����, 1 = ������, 2 = �׶��� ��, 3 = �� ��, 4 = ���� ��, 5 = ���� ��

    // Ư���� ��Ÿ�� ����
    public bool isCool = false;
    public Text coolTxt;
    public Image coolImg;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Image>().sprite = nowspecialGunImg.sprite;

        nowspecialGunImg.sprite = specialGunImg[0];
        isCool = false;
        itemFrameImg1.gameObject.SetActive(true);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(false);

        player_ItemNum[0] = gun;
        player_ItemNum[1] = pick;
        player_ItemNum[2] = special_Gun[0];
        m_Special_Gun[0].SetActive(true);

        nowItem = player_ItemNum[0];

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        if (gunManager.CurrentWep() == 0)
        {
            oriRigs[0].weight = 1;
            m_Original_Gun[0].SetActive(true);
        }
        if (gunManager.CurrentWep() == 1)
        {
            oriRigs[1].weight = 1;
            m_Original_Gun[1].SetActive(true);
        }
        if (gunManager.CurrentWep() == 2)
        {
            oriRigs[2].weight = 1;
            m_Original_Gun[2].SetActive(true);
        }
        if (gunManager.CurrentWep() == 3)
        {
            oriRigs[3].weight = 1;
            m_Original_Gun[3].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            itemFrameImg1.gameObject.SetActive(true);
            itemFrameImg2.gameObject.SetActive(false);
            itemFrameImg3.gameObject.SetActive(false);

            for (int i = 0; i < specRigs.Length; i++)
            {
                specRigs[i].weight = 0;
            }
            for (int i = 0; i < oriRigs.Length; i++)
            {
                oriRigs[i].weight = 0;
            }
            for (int i = 0; i < m_Original_Gun.Length; i++)
            {
                m_Original_Gun[i].SetActive(false);
            }
            for (int i = 0; i < m_Special_Gun.Length; i++)
            {
                m_Special_Gun[i].SetActive(false);
            }
            m_Pick.SetActive(false);

            player_ItemNum[0].SetActive(true);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(false);
            nowItem = player_ItemNum[0];

            if (gunManager.CurrentWep() == 0)
            {
                oriRigs[0].weight = 1;
                m_Original_Gun[0].SetActive(true);
            }
            if (gunManager.CurrentWep() == 1)
            {
                oriRigs[1].weight = 1;
                m_Original_Gun[1].SetActive(true);
            }
            if (gunManager.CurrentWep() == 2)
            {
                oriRigs[2].weight = 1;
                m_Original_Gun[2].SetActive(true);
            }
            if (gunManager.CurrentWep() == 3)
            {
                oriRigs[3].weight = 1;
                m_Original_Gun[3].SetActive(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(true);
            player_ItemNum[2].SetActive(false);

            itemFrameImg1.gameObject.SetActive(false);
            itemFrameImg2.gameObject.SetActive(true);
            itemFrameImg3.gameObject.SetActive(false);

            nowItem = player_ItemNum[1];
            m_Pick.SetActive(true);

            for (int i = 0; i < specRigs.Length; i++)
            {
                specRigs[i].weight = 0;
            }
            for (int i = 0; i < oriRigs.Length; i++)
            {
                oriRigs[i].weight = 0;
            }
            for (int i = 0; i < m_Original_Gun.Length; i++)
            {
                m_Original_Gun[i].SetActive(false);
            }
            for (int i = 0; i < m_Special_Gun.Length; i++)
            {
                m_Special_Gun[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            for (int i = 0; i < specRigs.Length; i++)
            {
                specRigs[i].weight = 0;
            }
            for (int i = 0; i < oriRigs.Length; i++)
            {
                oriRigs[i].weight = 0;
            }
            for (int i = 0; i < m_Original_Gun.Length; i++)
            {
                m_Original_Gun[i].SetActive(false);
            }
            for (int i = 0; i < m_Special_Gun.Length; i++)
            {
                m_Special_Gun[i].SetActive(false);
            }
            m_Pick.SetActive(false);

            player_ItemNum[0].SetActive(false);
            player_ItemNum[1].SetActive(false);
            player_ItemNum[2].SetActive(true);
            nowItem = player_ItemNum[2];

            itemFrameImg1.gameObject.SetActive(false);
            itemFrameImg2.gameObject.SetActive(false);
            itemFrameImg3.gameObject.SetActive(true);

            if (currentSpecialGun == 0)
            {
                specRigs[0].weight = 1;
                m_Special_Gun[0].SetActive(true);
            }
            if (currentSpecialGun == 1)
            {
                specRigs[1].weight = 1;
                m_Special_Gun[1].SetActive(true);
            }
            if (currentSpecialGun == 2)
            {
                specRigs[2].weight = 1;
                m_Special_Gun[2].SetActive(true);
            }
            if (currentSpecialGun == 3)
            {
                specRigs[3].weight = 1;
                m_Special_Gun[3].SetActive(true);
            }
            if (currentSpecialGun == 4)
            {
                specRigs[4].weight = 1;
                m_Special_Gun[4].SetActive(true);
            }
            if (currentSpecialGun == 5)
            {
                specRigs[5].weight = 1;
                m_Special_Gun[5].SetActive(true);
            }
        }

        //�� ��Ÿ��
        if (isCool)
        {
            coolTxt.gameObject.SetActive(true);
            coolImg.gameObject.SetActive(true);
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                isCool = false;
                coolImg.gameObject.SetActive(false);
                coolTxt.gameObject.SetActive(false);
            }
        }
        coolTxt.text = cooldown.ToString("F0");
    }

    public void SetCooldownTime(float cooltime)
    {
        cooldown = cooltime;
    }

    public void ChangeNoGun()
    {
        nowspecialGunImg.sprite = specialGunImg[0];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[0];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[0].SetActive(true);
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 0;
        specRigs[0].weight = 1;
    }

    public void ChangeGrappling()
    {
        nowspecialGunImg.sprite = specialGunImg[1];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[1];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[1].SetActive(true);

        bulletCntText.text = "Grappling Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 1;
        specRigs[1].weight = 1;
    }

    public void ChangeGround()
    {
        nowspecialGunImg.sprite = specialGunImg[2];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[2];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[2].SetActive(true);

        bulletCntText.text = "Ground Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 2;
        specRigs[2].weight = 1;
    }

    public void ChangeHeal()
    {
        nowspecialGunImg.sprite = specialGunImg[3];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[3];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[3].SetActive(true);

        bulletCntText.text = "Heal Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 3;
        specRigs[3].weight = 1;
    }

    public void ChangeRocket()
    {
        nowspecialGunImg.sprite = specialGunImg[4];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[4];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[4].SetActive(true);

        bulletCntText.text = "Rocket Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 4;
        specRigs[4].weight = 1;
    }

    public void ChangeTaunt()
    {
        nowspecialGunImg.sprite = specialGunImg[5];
        itemFrameImg1.gameObject.SetActive(false);
        itemFrameImg2.gameObject.SetActive(false);
        itemFrameImg3.gameObject.SetActive(true);

        player_ItemNum[0].SetActive(false);
        player_ItemNum[1].SetActive(false);
        player_ItemNum[2].SetActive(false);
        player_ItemNum[2] = special_Gun[5];
        for (int i = 0; i < m_Original_Gun.Length; i++)
        {
            m_Original_Gun[i].SetActive(false);
        }
        for (int i = 0; i < m_Special_Gun.Length; i++)
        {
            m_Special_Gun[i].SetActive(false);
        }
        m_Pick.SetActive(false);

        m_Special_Gun[5].SetActive(true);

        bulletCntText.text = "Taunt Gun";
        player_ItemNum[2].SetActive(true);

        for (int i = 0; i < oriRigs.Length; i++)
        {
            oriRigs[i].weight = 0;
        }
        for (int i = 0; i < specRigs.Length; i++)
        {
            specRigs[i].weight = 0;
        }
        currentSpecialGun = 5;
        specRigs[5].weight = 1;
    }
}
