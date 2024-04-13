using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EnemyCtrl : MonoBehaviour
{
    public Image hpBar;
    public int curHp;
    public int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f , 1f);

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other) // �׺�Ž� Ʈ���Ŷ� ���ļ� ���� ������
    {
        // �⺻ �� ����
        if (other.tag == "player_attack") // �⺻ ��
        {
            Debug.Log(other.gameObject.name + " �浹");
            Attack();
        }

        if(other.tag == "rocket_attack") // Ư���� - ����
        {
            Debug.Log(other.gameObject.name + " �浹");
            RocketAttack();
        }

        // �� ��
        if(other.tag == "gun_heal")
        {
            Debug.Log(other.gameObject.name + " ��");
            Heal();
        }
    }

    public void Attack()
    {
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp/ (float)maxHp, 1f, 1f); //HP�� ü�� ����ȭ
        if(curHp <= 0)
        {
            Destroy(transform.parent.gameObject); // ���� Enemy �ڽ� ������Ʈ�� �θ� ������Ʈ ������ ����
        }
    }

    public void RocketAttack()
    {
        curHp -= 100;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
        if (curHp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void Heal()
    {
        curHp += 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f);
    }

}
