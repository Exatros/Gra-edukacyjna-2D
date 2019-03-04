using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomGeneratorNumbersForElementsMap : MonoBehaviour
{
    public Sprite[] img = new Sprite[10];
    public SpriteRenderer[] spriteNumbers = new SpriteRenderer[0];
    public static List<int> listOfNumbers = new List<int>();



    // Use this for initialization
    void Start()
    {
        RandomNumber();
        listOfNumbers.Add(RandomGenereatorNumbersForPlayer.correctReasult);
    }


    // Update is called once per frame
    void Update()
    {

    }
    //Generowanie losowych liczb
    private void RandomNumber()
    {
        switch (spriteNumbers.Length)
        {
            case 1:
                ChoseRandomNumbers(spriteNumbers[0]);
                if (listOfNumbers.Contains(int.Parse(spriteNumbers[0].sprite.name)))
                {
                    RandomNumber();
                }
                else
                {
                    this.name = spriteNumbers[0].sprite.name;
                    listOfNumbers.Add(int.Parse(this.name));

                }
                break;
            case 2:
                ChoseRandomNumbers(spriteNumbers[0]);
                ChoseRandomNumbers(spriteNumbers[1]);
                if (int.Parse(spriteNumbers[0].sprite.name) == 0 || listOfNumbers.Contains(int.Parse(spriteNumbers[0].sprite.name + spriteNumbers[1].sprite.name)))
                {
                    RandomNumber();
                }
                else
                {
                    this.name = spriteNumbers[0].sprite.name + spriteNumbers[1].sprite.name;
                    if (int.Parse(this.name) > 20 && (SceneManager.GetActiveScene().name == "addition_easy" || SceneManager.GetActiveScene().name == "subtraction_easy"))
                    {
                        RandomNumber();
                    }
                    else
                    {
                        listOfNumbers.Add(int.Parse(this.name));
                    }
                }
                break;
            case 3:
                ChoseRandomNumbers(spriteNumbers[0]);
                ChoseRandomNumbers(spriteNumbers[1]);
                ChoseRandomNumbers(spriteNumbers[2]);
                if (int.Parse(spriteNumbers[0].sprite.name) == 0 || (int.Parse(spriteNumbers[0].sprite.name) == 0 || int.Parse(spriteNumbers[1].sprite.name) == 0)
                    || listOfNumbers.Contains(int.Parse(spriteNumbers[0].sprite.name + spriteNumbers[1].sprite.name + spriteNumbers[2].sprite.name)))

                {
                    RandomNumber();
                }
                else
                {
                    this.name = spriteNumbers[0].sprite.name + spriteNumbers[1].sprite.name + spriteNumbers[2].sprite.name;
                    listOfNumbers.Add(int.Parse(this.name));
                }
                break;
        }
    }
    //Losowanie cyfry 0-9
    private void ChoseRandomNumbers(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.sprite = img[Random.Range(0, 999) / 100];
    }

}
