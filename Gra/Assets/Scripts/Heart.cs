using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[5];
    private static Animator[] anim = new Animator[5];
    private float timeToRespHearts;
    private static Heart instance;
    // Use this for initialization
    void Start()
    {
        instance = this;

        for (int i = 0; i < hearts.Length; i++)
        {
            anim[i] = hearts[i].GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void HeartHit(int Health)
    {

        if (Health == 4)
        {
            anim[4].SetTrigger("HeartHitTrigger");
        }
        if (Health == 3)
        {
            anim[3].SetTrigger("HeartHitTrigger");
        }
        if (Health == 2)
        {
            anim[2].SetTrigger("HeartHitTrigger");
        }
        if (Health == 1)
        {
            anim[1].SetTrigger("HeartHitTrigger");
        }
        if (Health == 0)
        {
            instance.StartCoroutine(instance.BlinktLastHeart());
        }
    }

    private IEnumerator BlinktLastHeart ()
    {
        Sounds.SoundLoss();
        DestroyElementAfterCollected.HideWrongMark();
        UnlockRulerWall.Reset();
        anim[0].SetTrigger("HeartHitTrigger");
        Player.isEnd = true;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 0;
        Player.panel[1].gameObject.SetActive(true);

    }

    public static void ResetHearts()
    {
        Player.health = 5;
        foreach (Animator hertanim in anim)
        {
            hertanim.Rebind();
        }
    }

    




}
