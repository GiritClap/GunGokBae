using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class C_EnemyCtrl : MonoBehaviour
{
    public Image hpBar;
    public int curHp;
    public int maxHp;

    // �ִϸ��̼�
    private Animator ani;

    private bool isHit = false;

    public bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        curHp = maxHp;
        hpBar.rectTransform.localScale = new Vector3(1f, 1f , 1f);

        ani = transform.GetComponentInParent<Animator>();
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
            if (isHit == false)
            {
                StartCoroutine(Hit());
            }
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
        ani.SetBool("attack", true);
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp/ (float)maxHp, 1f, 1f); //HP�� ü�� ����ȭ
        if(curHp <= 0)
        {
            Destroy(transform.parent.gameObject); // ���� Enemy �ڽ� ������Ʈ�� �θ� ������Ʈ ������ ����
        }
    }

    IEnumerator Hit() // ���� ������ ��
    {
        isHit = true;
        curHp -= 10;
        hpBar.rectTransform.localScale = new Vector3((float)curHp / (float)maxHp, 1f, 1f); //HP�� ü�� ����ȭ

        if (curHp <= 0)
        {
            isDie = true;
            ani.SetBool("Die", true);  // ü�� 0�̸� ���� �ִϸ��̼� ��� 
            transform.GetComponentInParent<CapsuleCollider>().enabled = false; // �ݶ��̴� ����
            yield return new WaitForSeconds(2.0f);
            Destroy(transform.parent.gameObject); // ���� Enemy �ڽ� ������Ʈ�� �θ� ������Ʈ ������ ����
        }

        else
        {
            ani.SetBool("Hit", true); // Hit �ִϸ��̼� ���
            yield return new WaitForSeconds(0.2f);
            ani.SetBool("Hit", false);
        }

        isHit = false;
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
