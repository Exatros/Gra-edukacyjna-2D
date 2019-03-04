using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Animator anim;
    private bool touched = false;
    private static int numerOfCollectionStar = 0;
    private bool oneTimeTriggered = false;
    public AudioClip openClip;
    public AudioSource audioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && oneTimeTriggered == false)
        {
            audioSource.clip = openClip;
            audioSource.Play();
            anim = GetComponent<Animator>();
            touched = true;
            anim.SetBool("Touched", touched);
            Destroy(this.gameObject, 0.78f);
            numerOfCollectionStar++;
            oneTimeTriggered = true;
        }
    }

    public static int ShowNumberOfCollectionStar()
    {
        return numerOfCollectionStar;
    }

    public static void ResetStars()
    {
        numerOfCollectionStar = 0;
    }
}
