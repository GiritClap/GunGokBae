using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed; //걷기 속도
    public float runSpeed; //달리기 속도
    public float applySpeed; //현재 속도

    bool isRun = false; // 달리기 상태
    bool isGround = true; // 땅에 닿았는지

    Rigidbody myRigid;

    public float jumpForce; // 점프 힘
    bool isJumping = false; //점프중인지 확인

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed; //초기 속도 설정
    }

    void Update()
    {
        IsGround(); // 땅에 닿았는지 
        Move(); //플레이어 이동

        //달리기 시도
        TryRun();

        //점프 시도
        TryJump();
        Debug.Log(myRigid.velocity.magnitude);
    }

    private void IsGround()
    {   //캐릭터 아래쪽으로 Ray를 쏴서 땅에 닿았는지 확인
        isGround = Physics.Raycast(transform.position, Vector3.down, GetComponent<CapsuleCollider>().bounds.extents.y + 0.1f);
        if(isGround)
        {
            isJumping = false;
        } else
        {
            isJumping = true;
        }
    }

    private void Move()
    {
        if(isJumping == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            /* Vector3 h = transform.right * x;
             Vector3 v = transform.forward * z;

             Vector3 _velocity = (h + v).normalized * applySpeed;


             myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);*/

            Vector3 getVel = new Vector3(x, 0, z) * applySpeed * Time.deltaTime;
            myRigid.velocity = getVel;
        }
        
    }

    

    //달리기 시도
    private void TryRun()
    {   //쉬프트 키를 눌렀을 때 달리기 실행
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Running();
        }
        // 쉬프트 키 땠을 때 달리기 취소
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }

    //달리기 실행
    private void Running()
    {
        if (isGround)  // 땅에 있을 때만 달리기 가능
        {
            if (isRun) // 이미 달리고 있다면 취소
            {
                RunningCancel();
            }
            else
            {
                isRun = true;
                applySpeed = runSpeed;
            }
        }
    }

    //달리기 취소
    private void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    //점프 시도
    private void TryJump()
    {
        //스페이스 키를 눌렀고 땅에 닿았을 때 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isJumping)
        {
            Jump();
        }
    }

    //점프
    private void Jump()
    {   //위쪽 방향으로 점프 힘ㄱㄱ
        myRigid.AddForce(Vector3.up * jumpForce);
    }
}
