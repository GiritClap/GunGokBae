using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerBody : MonoBehaviour
{

    public AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "gun")
        {
            M_BagManager.Instance.SetGun(true);
            M_SoundManager.instance.SFXPlay("gunEarn" , clip);
            Destroy(collision.gameObject);
        }   
        if (collision.collider.tag == "gun2")
        {
            M_BagManager.Instance.SetGun2(true);
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "gun3")
        {
            M_BagManager.Instance.SetGun3(true);
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "gun4")
        {
            M_BagManager.Instance.SetGun4(true);
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "gun5")
        {
            M_BagManager.Instance.SetGun5(true);
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }




        if (collision.collider.tag == "stone")
        {
            M_BagManager.Instance.SetStone();
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone2")
        {
            M_BagManager.Instance.SetStone2();
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone3")
        {
            M_BagManager.Instance.SetStone3();
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone4")
        {
            M_BagManager.Instance.SetStone4();
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "stone5")
        {
            M_BagManager.Instance.SetStone5();
            M_SoundManager.instance.SFXPlay("gunEarn", clip);
            Destroy(collision.gameObject);
        }


    }
}
