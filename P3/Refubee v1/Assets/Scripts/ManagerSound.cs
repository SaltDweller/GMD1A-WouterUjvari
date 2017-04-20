using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSound : MonoBehaviour {

    public GameObject playerBee;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip mah;
    public AudioClip au;
    public AudioSource as1;
    public AudioSource as2;
    public AudioSource as3;

    void Start()
    {
        playerBee = GameObject.FindGameObjectWithTag("Player");
    }

    public void SoundPlayJump()
    {
        gameObject.GetComponent<AudioSource>().clip = jumpSound;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void SoundPlayland()
    {
        gameObject.GetComponent<AudioSource>().clip = landSound;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void SoundPlayMeh()
    {
        as2.Play();
    }

    public void SoundPlayAU()
    {
        as3.Play();
    }


}
