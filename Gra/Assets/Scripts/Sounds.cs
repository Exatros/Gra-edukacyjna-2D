using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip lossclip;
    public AudioClip winClip;
    public AudioClip leverClip;
    public AudioClip clickButtonClip;
    private static Sounds instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        instance.audioSource = GameObject.FindGameObjectWithTag("SoundObjects").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void SoundLoss()
    {
        instance.audioSource.clip = instance.lossclip;
        instance.audioSource.Play();
    }

    public static void SoundWin()
    {
        instance.audioSource.clip = instance.winClip;
        instance.audioSource.Play();
    }

    public static void LeverSound()
    {
        instance.audioSource.clip = instance.leverClip;
        instance.audioSource.Play();
    }

    public static void ClickButton ()
    {
        instance.audioSource.clip = instance.clickButtonClip;
        instance.audioSource.Play();
    }
}
