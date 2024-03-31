using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Transform orientation;
    Vector3 moveDirection;

    LayerMask whatIsGround;

    float walkSpeed; //걷기 속도
    float runSpeed; //달리기 속도
    float applySpeed; //현재 속도

    public float moveSpeed = 30f;


    bool isRun = false; // 달리기 상태
    bool isGround = true; // 땅에 닿았는지
    bool isBorder;

    Rigidbody myRigid;

    public float jumpForce; // 점프 힘
    bool isJumping = false; // 점프하는지 확인

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        GroundSpeed groundSpeed = GetComponent<GroundSpeed>();
        applySpeed = groundSpeed.walkSpeed; // 초기 속도 설정
        myRigid.freezeRotation = true;
        
        // 레이어 마스크를 인식 못해서 직접 값 넣어줌 -> 추후 개선 필요해보이는듯?
        whatIsGround = (1 << 7);
    }

    void Update()
    {
        IsGround(); // 땅에 닿았는지

        Move(); //플레이어 이동

        //달리기 시도
        TryRun();

        //점프 시도
        TryJump();

        Debug.Log("땅 확인 : " + isGround);
        Debug.Log("점프중 확인 : " + isJumping);
        Debug.Log("현재속도 확인 : " + applySpeed);


    }

    private void IsGround()
    {   //캐릭터 아래쪽으로 Ray를 쏴서 땅에 닿았는지 확인
        Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.red);
        isGround = Physics.Raycast(transform.position, Vector3.down, 1.2f, whatIsGround);
        if (isGround)
        {
            isJumping = false;
        }
    }

    private void Move()
    {
        Debug.Log("Move() 메서드 호출 확인");
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * z + orientation.right * x;
       
        //문승준 수정
        myRigid.AddForce(moveDirection.normalized * applySpeed * Time.deltaTime * 10f, ForceMode.Force);

        Vector3 flatVel = new Vector3(myRigid.velocity.x, 0f, myRigid.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            myRigid.velocity = new Vector3(limitedVel.x, myRigid.velocity.y, limitedVel.z);
        }

    }
   

    private void TryRun()
    {
        GroundSpeed groundSpeed = GetComponent<GroundSpeed>();

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        applySpeed = isRun ? groundSpeed.runSpeed : groundSpeed.walkSpeed;
        
        
    
    }


    //점프 시도
    private void TryJump()
    {
        //스페이스 키를 눌렀고 땅에 닿았을 때 점프
        if (Input.GetKey(KeyCode.Space) && isGround == true && isJumping == false)
        {
            isJumping = true;

            Jump();
        }
    }

    //점프
    private void Jump()
    {   //위쪽 방향으로 점프 힘ㄱㄱ
        //myRigid.velocity = transform.up * jumpForce;
        myRigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Portal1"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
