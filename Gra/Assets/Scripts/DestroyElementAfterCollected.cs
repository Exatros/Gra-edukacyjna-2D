using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyElementAfterCollected : MonoBehaviour
{
    public Sprite QuestionMark;
    public SpriteRenderer[] spriteNumber = new SpriteRenderer[0];
    private static SpriteRenderer[] spriteResult = new SpriteRenderer[3];
    private static SpriteRenderer[] spriteNumA = new SpriteRenderer[3];
    private static SpriteRenderer[] spriteNumB = new SpriteRenderer[3];
    private static SpriteRenderer[] badSprite = new SpriteRenderer[3];
    private GameObject reasultObject;
    private GameObject[] go;
    public static bool oneTimeColison = false;
    private static DestroyElementAfterCollected instance;
    private AudioSource audioSource;
    public AudioClip collectClip;
    private RandomGenereatorNumbersForPlayer ranGNFP;
    void Start()
    {
        instance = this;
        go = GameObject.FindGameObjectsWithTag("ElementGUIResult");//0-1-2 for Unity  / 1-2-0 for PC
        spriteResult[0] = go[1].GetComponent<SpriteRenderer>();
        spriteResult[1] = go[2].GetComponent<SpriteRenderer>();
        spriteResult[2] = go[0].GetComponent<SpriteRenderer>();

        go = GameObject.FindGameObjectsWithTag("ElementGUIB");//0-1-2 for Unity / 1/2/0 for PC
        spriteNumB[0] = go[1].GetComponent<SpriteRenderer>();
        spriteNumB[1] = go[2].GetComponent<SpriteRenderer>();
        spriteNumB[2] = go[0].GetComponent<SpriteRenderer>();

        go = GameObject.FindGameObjectsWithTag("ElementGUIA");//0-1-2 for Unity / 2/1/0 for PC
        spriteNumA[0] = go[2].GetComponent<SpriteRenderer>();
        spriteNumA[1] = go[1].GetComponent<SpriteRenderer>();
        spriteNumA[2] = go[0].GetComponent<SpriteRenderer>();



        go = GameObject.FindGameObjectsWithTag("BadMarkAnswer");//0-1-2 for Unity / 0/2/1 for PC
        badSprite[0] = go[0].GetComponent<SpriteRenderer>();
        badSprite[1] = go[2].GetComponent<SpriteRenderer>();
        badSprite[2] = go[1].GetComponent<SpriteRenderer>();

        badSprite[0].enabled = false;
        badSprite[1].enabled = false;
        badSprite[2].enabled = false;

        reasultObject = GameObject.FindGameObjectWithTag("ReasultObject");
        audioSource = GameObject.FindGameObjectWithTag("SoundObjects").GetComponent<AudioSource>();

        HideNumbers(RandomGenereatorNumbersForPlayer.randomOperation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && oneTimeColison == false)
        {
            // anim = GetComponent<Animator>();
            //  touched = true;
            //  anim.SetBool("Touched", touched);
            audioSource.clip = collectClip;
            audioSource.Play();
            oneTimeColison = true;
            StartCoroutine(timeForSound());

        }
    }

    private int CountValue(int length, SpriteRenderer[] spriteRenderers)
    {
        switch (length)
        {
            case 1:
                if (RandomGenereatorNumbersForPlayer.randomOperation == 1)
                {
                    spriteRenderers[0].enabled = false;
                    spriteRenderers[1].enabled = false;
                    spriteRenderers[2].enabled = true;
                    spriteRenderers[2].sprite = spriteNumber[0].sprite;
                    return int.Parse(spriteNumber[0].sprite.name);
                }
                else
                {
                    spriteRenderers[0].enabled = true;
                    spriteRenderers[1].enabled = false;
                    spriteRenderers[2].enabled = false;
                    spriteRenderers[0].sprite = spriteNumber[0].sprite;
                    return int.Parse(spriteNumber[0].sprite.name);
                }

            case 2:
                if (RandomGenereatorNumbersForPlayer.randomOperation == 1)
                {
                    spriteRenderers[0].enabled = false;
                    spriteRenderers[1].enabled = true;
                    spriteRenderers[2].enabled = true;

                    spriteRenderers[1].sprite = spriteNumber[0].sprite;
                    spriteRenderers[2].sprite = spriteNumber[1].sprite;
                    return int.Parse(spriteNumber[0].sprite.name + spriteNumber[1].sprite.name);
                }
                else
                {
                    spriteRenderers[0].enabled = true;
                    spriteRenderers[1].enabled = true;
                    spriteRenderers[2].enabled = false;

                    spriteRenderers[0].sprite = spriteNumber[0].sprite;
                    spriteRenderers[1].sprite = spriteNumber[1].sprite;
                    return int.Parse(spriteNumber[0].sprite.name + spriteNumber[1].sprite.name);
                }

            case 3:
                spriteRenderers[0].enabled = true;
                spriteRenderers[1].enabled = true;
                spriteRenderers[2].enabled = true;

                spriteRenderers[0].sprite = spriteNumber[0].sprite;
                spriteRenderers[1].sprite = spriteNumber[1].sprite;
                spriteRenderers[2].sprite = spriteNumber[2].sprite;
                return int.Parse(spriteNumber[0].sprite.name + spriteNumber[1].sprite.name + spriteNumber[2].sprite.name);
        }
        return 0;

    }

    private void IfGetCorrectNumber(int value)
    {
        if (RandomGenereatorNumbersForPlayer.randomOperation == 2)
        {
            MoveAfterCollect(value.ToString().Length);
        }

        if (RandomGenereatorNumbersForPlayer.correctReasult == value)
        {
            Player.countCorrectNumbers++;
            if (Player.countCorrectNumbers == 3)
            {
                Sounds.SoundWin();
                badSprite[RandomGenereatorNumbersForPlayer.randomOperation - 1].enabled = false;
                Time.timeScale = 0;
                Player.panel[0].gameObject.SetActive(true);
                Player.isEnd = true;

            }
            else
            {
                RandomGeneratorNumbersForElementsMap.listOfNumbers.Clear();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
        else
        {
            Player.health--;
            badSprite[RandomGenereatorNumbersForPlayer.randomOperation - 1].enabled = true;
            ChangeBadMark(value.ToString().Length);
            Heart.HeartHit(Player.health);
        }
    }

    private void ChooseSprite(int x)
    {
        switch (x)
        {
            case 1:
                IfGetCorrectNumber(CountValue(this.name.Length, spriteNumA));
                break;
            case 2:
                IfGetCorrectNumber(CountValue(this.name.Length, spriteNumB));
                break;
            case 3:
                IfGetCorrectNumber(CountValue(this.name.Length, spriteResult));
                break;
        }
    }

    private static void HideNumbers(int x)
    {
        switch (x)
        {
            case 1:
                spriteNumA[2].sprite = instance.QuestionMark;
                spriteNumA[0].enabled = false;
                spriteNumA[1].enabled = false;
                spriteNumA[2].enabled = true;
                break;
            case 2:
                spriteNumB[0].sprite = instance.QuestionMark;
                spriteNumB[0].enabled = true;
                spriteNumB[1].enabled = false;
                spriteNumB[2].enabled = false;
                break;
            case 3:
                spriteResult[0].sprite = instance.QuestionMark;
                spriteResult[0].enabled = true;
                spriteResult[1].enabled = false;
                spriteResult[2].enabled = false;
                break;

        }
    }

    public static void HideWrongMark()
    {
        badSprite[0].enabled = false;
        badSprite[1].enabled = false;
        badSprite[2].enabled = false;
        HideNumbers(RandomGenereatorNumbersForPlayer.randomOperation);
    }

    private IEnumerator timeForSound()
    {

        yield return new WaitForSecondsRealtime(0.5f);
        ChooseSprite(RandomGenereatorNumbersForPlayer.randomOperation);
        this.gameObject.SetActive(false);
        Player.PossibleToCollectAgain(this);
    }

    private void ChangeBadMark(int length)
    {
        switch (RandomGenereatorNumbersForPlayer.randomOperation - 1)
        {
            case 0:
                if (length == 1)
                {
                    badSprite[0].transform.localPosition = new Vector2(-1f, 0f);
                    badSprite[0].transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else if (length == 2)
                {
                    badSprite[0].transform.localPosition = new Vector2(-1.1f, 0f);
                    badSprite[0].transform.localScale = new Vector3(1.5f, 1f, 1f);
                }
                else
                {
                    badSprite[0].transform.localPosition = new Vector2(-1.25f, 0f);
                    badSprite[0].transform.localScale = new Vector3(2f, 1f, 1f);
                }
                break;
            case 1:
                if (length == 1)
                {
                    badSprite[1].transform.localPosition = new Vector2(-0.25f, 0f);
                    badSprite[1].transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else if (length == 2)
                {
                    badSprite[1].transform.localPosition = new Vector2(-0.1f, 0f);
                    badSprite[1].transform.localScale = new Vector3(1.5f, 1f, 1f);
                }
                else
                {
                    badSprite[1].transform.localPosition = new Vector2(0f, 0f);
                    badSprite[1].transform.localScale = new Vector3(2f, 1f, 1f);
                }
                break;
            case 2:
                if (length == 1)
                {
                    badSprite[2].transform.localPosition = new Vector2(1f, 0f);
                    badSprite[2].transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else if (length == 2)
                {
                    badSprite[2].transform.localPosition = new Vector2(1.1f, 0f);
                    badSprite[2].transform.localScale = new Vector3(1.5f, 1f, 1f);
                }
                else
                {
                    badSprite[2].transform.localPosition = new Vector2(1.25f, 0f);
                    badSprite[2].transform.localScale = new Vector3(2f, 1f, 1f);
                }
                break;
        }
    }
    private void MoveAfterCollect(int length)
    {
        if (length == 1) reasultObject.transform.localPosition = new Vector2(-0.6f, 0);
        if (length == 2) reasultObject.transform.localPosition = new Vector2(-0.3f, 0);
        if (length == 3) reasultObject.transform.localPosition = new Vector2(0, 0);
    }
}
