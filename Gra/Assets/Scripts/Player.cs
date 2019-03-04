using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static bool isEnd = false;
    public static bool isPause = false;
    public static GameObject[] panel;
    public static Player instance;
    public static int countCorrectNumbers = 0;
    public static Vector3 startPosition;


    // MOVING & JUMPING
    private bool isMove = false;
    private float timeToNextStep = 0;
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool canMoveInair;// = true;
    private bool grounded;
    private bool doubleJump;
    private float howRotate;
    private Animator anim;
    Rigidbody2D myBody;

    public AudioClip hurtSpikesClip;
    public AudioClip walkClip;
    public AudioClip jumpClip;
    public AudioSource audioSource;



    //COMBAT
    public static int health;


    void Start()
    {
        startPosition = this.transform.position;
        health = 5;
        Timer.times = 180;
        Time.timeScale = 1;
        isEnd = false;
        isPause = false;
        DestroyElementAfterCollected.oneTimeColison = false;

        instance = this;

        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        panel = GameObject.FindGameObjectsWithTag("PlayerMenu");
        panel[0].gameObject.SetActive(false);//End win
        panel[1].gameObject.SetActive(false);//End loss
        panel[2].gameObject.SetActive(false);//Pause


    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (Mathf.Abs(myBody.velocity.x) < 0.05f && Mathf.Abs(myBody.velocity.y) < 0.05f) canMoveInair = false;
        else canMoveInair = true;

        if (grounded)
            doubleJump = false;
        anim.SetBool("Grounded", grounded);
        anim.SetBool("DoubleJump", doubleJump);
        anim.SetBool("OneTimeDoubleJump", true);
        //Menu podczas "Przerwy"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isEnd)
            {
                if (!isPause)
                {
                    Time.timeScale = 0;
                    panel[2].gameObject.SetActive(true);
                    isPause = true;
                }
                else
                {

                    Time.timeScale = 1;
                    panel[2].gameObject.SetActive(false);
                    isPause = false;
                }
            }

        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded == true)
        {
            Jump();
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded == false && doubleJump == false)
        {
            Jump();
            doubleJump = true;
            anim.SetBool("DoubleJump", doubleJump);
            anim.SetBool("OneTimeDoubleJump", false);

        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (!isEnd && !isPause))
        {
            if (!canMoveInair && !grounded) return;
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            howRotate = 0;
        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (!isEnd && !isPause))
        {
            if (!canMoveInair && !grounded) return;
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            howRotate = 0.1f;

        }

        if (myBody.velocity.x <= 0.1f && myBody.velocity.x >= -0.1f)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
        anim.SetFloat("Speed", Mathf.Abs(myBody.velocity.x));

        if (myBody.velocity.x >= howRotate)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else transform.localScale = new Vector3(-1f, 1f, 1f);
        MakeSoundsWalk();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }



    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
        audioSource.clip = jumpClip;
        audioSource.Play();
    }


    //Funkcja odpowiedzialna za włączenie możliwości ponowniego zebrania liczby po 2s 
    public static void PossibleToCollectAgain(DestroyElementAfterCollected element)
    {
        DestroyElementAfterCollected elTemple = element;
        instance.StartCoroutine(instance.Time2sec(elTemple));
    }

    public IEnumerator HurtAfterJumpInToSpikes()
    {
        audioSource.clip = hurtSpikesClip;
        audioSource.Play();
        SpikesHurt.dealayForDmg = true;
        anim.SetLayerWeight(1, 1);
        yield return new WaitForSecondsRealtime(2);
        anim.SetLayerWeight(1, 0);
        SpikesHurt.dealayForDmg = false;


    }

    private IEnumerator Time2sec(DestroyElementAfterCollected element)
    {
        anim.SetLayerWeight(1, 1);
        yield return new WaitForSecondsRealtime(2);
        element.gameObject.SetActive(true);
        anim.SetLayerWeight(1, 0);
        DestroyElementAfterCollected.oneTimeColison = false;
    }

    private void MakeSoundsWalk()
    {
        if (isMove == true && timeToNextStep <= 0 && grounded == true)
        {
            audioSource.clip = walkClip;
            audioSource.Play();
            timeToNextStep = 0.6f;
        }
        else
        {
            timeToNextStep -= Time.deltaTime;
        }
    }


}
