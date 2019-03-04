using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour {

    private Hide hideBlocks;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hideBlocks = GameObject.FindGameObjectWithTag("HideMechanism").GetComponent<Hide>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Player.countCorrectNumbers >= 1)
        {

            hideBlocks.StartCoroutine(hideBlocks.HideBlockFor2Seconds(this.gameObject, anim));
        }
    }





}
