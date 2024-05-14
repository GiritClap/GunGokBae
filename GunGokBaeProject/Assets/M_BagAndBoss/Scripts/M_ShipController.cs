using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ShipController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeforwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    public ParticleSystem[] engineParticles;

    Rigidbody rigid;

    public AudioClip moveSoudClip;
    public AudioSource audioSource;

    public ParticleSystem directionArrow;
    public Transform target; // 도착 행성 위치

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = moveSoudClip;
        audioSource.loop = true;
        audioSource.volume = 0.1f;
        audioSource.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x)/ screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeforwardSpeed = Mathf.Lerp(activeforwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration *Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        directionArrow.gameObject.transform.LookAt(target);

        Debug.Log(activeforwardSpeed);
        if (activeforwardSpeed > 20f)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.volume = 0.8f;
                audioSource.Play();
            }
           
            for (int i = 0; i < engineParticles.Length; i++)
            {
                engineParticles[i].Play();
                engineParticles[i].gameObject.transform.localScale = new Vector3(100f, 100f, 100f);
            }
        }
        else if (activeforwardSpeed > 0.5f)
        {

            audioSource.Stop();

            for (int i = 0; i < engineParticles.Length; i++)
            {
                engineParticles[i].Play();
                engineParticles[i].gameObject.transform.localScale = new Vector3(50f, 50f, 50f);
            }
        }
        else if (activeforwardSpeed > 0f)
        {
            audioSource.Stop();

            for (int i = 0; i < engineParticles.Length; i++)
            {
                engineParticles[i].Stop();
            }
        }
    }
}
