using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesHurt : MonoBehaviour
{
    public static  bool oneTimeCollision = false;
    public static bool dealayForDmg;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        dealayForDmg = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Wykonywanie funkcji skakania oraz odbieranie zycia przy dotknieciu kolców
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !oneTimeCollision)
        {
            player.Jump();
            oneTimeCollision = true;
            if (!dealayForDmg)
            {
                Player.health--;
                Heart.HeartHit(Player.health);
                StartCoroutine(player.HurtAfterJumpInToSpikes());
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        oneTimeCollision = false;
    }



}
