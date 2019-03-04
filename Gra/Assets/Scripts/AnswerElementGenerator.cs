using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerElementGenerator : MonoBehaviour {
    public Sprite[] img = new Sprite[10];
    public SpriteRenderer[] spriteNumbers = new SpriteRenderer[3];
    private bool OneTime = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!OneTime)
        {
            Answer(RandomGenereatorNumbersForPlayer.correctReasult.ToString().Length);
            OneTime = true;
        }
	}

    private void Answer(int length)
    {
        char[] correctReasult = RandomGenereatorNumbersForPlayer.correctReasult.ToString().ToCharArray();
        switch (length)
        {
            case 1:
                
                spriteNumbers[0].sprite = img[int.Parse(correctReasult[0].ToString())];
                spriteNumbers[1].enabled = false;
                spriteNumbers[2].enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.4f,0.5f);
                this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.4f,0.5f);
                this.name = correctReasult[0].ToString();
                break;
            case 2:
                spriteNumbers[0].sprite = img[int.Parse(correctReasult[0].ToString())];
                spriteNumbers[1].sprite = img[int.Parse(correctReasult[1].ToString())];
                spriteNumbers[2].enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.5f);
                this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.5f, 0.5f);
                this.name = correctReasult[0].ToString() + correctReasult[1].ToString();

                break;
            case 3:
                spriteNumbers[0].sprite = img[int.Parse(correctReasult[0].ToString())];
                spriteNumbers[1].sprite = img[int.Parse(correctReasult[1].ToString())];
                spriteNumbers[2].sprite = img[int.Parse(correctReasult[2].ToString())];
                this.name = correctReasult[0].ToString() + correctReasult[1].ToString() + correctReasult[2].ToString();

                break;

        }

    }
}
