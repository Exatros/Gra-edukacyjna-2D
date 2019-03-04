using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RandomGenereatorNumbersForPlayer : MonoBehaviour
{

    public Sprite[] img = new Sprite[10];
    public Sprite[] imgsMarks = new Sprite[4];

    public SpriteRenderer imgMark;
    public SpriteRenderer[] spriteGUI = new SpriteRenderer[6];
    public SpriteRenderer[] spriteReasultGUI = new SpriteRenderer[3];

    public static Scene sceneLevel;
    public static int numberOne, numberTwo;
    public static int correctReasult;

    public static int randomOperation = 0;

    public GameObject go;
    private static GameObject go2;


    // Use this for initialization
    // Po wybraniu poziomu bedzie nam wybierac znak odpowiedni do poziomu oraz losowac liczby do tego poziomu
    void Start()
    {
        go2 = GameObject.FindGameObjectWithTag("ReasultObject");
        sceneLevel = SceneManager.GetActiveScene();
        ChoseMark(sceneLevel.name);
        randomOperation = Random.Range(1, 4);
        if (randomOperation != 3)
        {
            ShowReasult();
        }
        SearchCorrectResult(randomOperation);
        ChangePosition(numberTwo.ToString().Length);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Wybór działania jakie bedzie i generowanie do niego liczb
    private void ChoseMark(string level)
    {
        switch (level)
        {   //DODAWANIE
            case "addition_easy":
                DeleteUnnecessaryNumbers(2);
                imgMark.sprite = imgsMarks[0];
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                numberOne = int.Parse(spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name);
                if (CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 20)
                {
                    ChoseMark("addition_easy");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);

                }
                break;

            case "addition_medium":
                DeleteUnnecessaryNumbers(4);
                imgMark.sprite = imgsMarks[0];
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[3]);
                numberOne = int.Parse(spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name);
                if (int.Parse(spriteGUI[2].sprite.name) == 0 || int.Parse(spriteGUI[1].sprite.name) == 0 || CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 100)
                {
                    ChoseMark("addition_medium");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }

                break;

            case "addition_hard":
                imgMark.sprite = imgsMarks[0];
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[3]);
                ChoseRandomNumbers(spriteGUI[4]);
                ChoseRandomNumbers(spriteGUI[5]);
                numberOne = int.Parse(spriteGUI[4].sprite.name + spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name + spriteGUI[5].sprite.name);
                if (int.Parse(spriteGUI[4].sprite.name) == 0 || int.Parse(spriteGUI[1].sprite.name) == 0 || CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 1000 || (int.Parse(spriteGUI[4].sprite.name) == 0 && int.Parse(spriteGUI[2].sprite.name) == 0) || (int.Parse(spriteGUI[1].sprite.name) == 0 && int.Parse(spriteGUI[3].sprite.name) == 0))
                {
                    ChoseMark("addition_hard");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }

                break;

            //ODEJMOWANIE
            case "subtraction_easy":
                DeleteUnnecessaryNumbers(3);
                imgMark.sprite = imgsMarks[1];
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[2]);
                numberOne = int.Parse(spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name);
                if (numberOne < 10)
                {
                    spriteGUI[2].enabled = false;
                }
                else
                {
                    spriteGUI[2].enabled = true;

                }
                if (numberOne > 20 || numberTwo > numberOne)
                {
                    ChoseMark("subtraction_easy");
                }
                else
                {

                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);

                }
                break;

            case "subtraction_medium":
                DeleteUnnecessaryNumbers(4);
                imgMark.sprite = imgsMarks[1];
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[3]);
                numberOne = int.Parse(spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name);
                if (int.Parse(spriteGUI[2].sprite.name) == 0 || int.Parse(spriteGUI[1].sprite.name) == 0 || numberOne < numberTwo || CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 100)
                {
                    ChoseMark("subtraction_medium");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }
                break;

            case "subtraction_hard":
                imgMark.sprite = imgsMarks[1];
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[3]);
                ChoseRandomNumbers(spriteGUI[4]);
                ChoseRandomNumbers(spriteGUI[5]);
                numberOne = int.Parse(spriteGUI[4].sprite.name + spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name + spriteGUI[5].sprite.name);
                if (int.Parse(spriteGUI[4].sprite.name) == 0 || int.Parse(spriteGUI[1].sprite.name) == 0 || numberOne < numberTwo || (int.Parse(spriteGUI[4].sprite.name) == 0 && int.Parse(spriteGUI[2].sprite.name) == 0) || (int.Parse(spriteGUI[1].sprite.name) == 0 && int.Parse(spriteGUI[3].sprite.name) == 0) || CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 1000)
                {
                    ChoseMark("subtraction_hard");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }
                break;

            //MNOŻENIE
            case "multiplication":
                DeleteUnnecessaryNumbers(4);
                imgMark.sprite = imgsMarks[2];
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[3]);
                numberOne = int.Parse(spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name);
                if (numberOne < 10)
                {
                    spriteGUI[2].enabled = false;
                }
                else
                {
                    spriteGUI[2].enabled = true;
                }
                if (numberTwo < 10)
                {
                    spriteGUI[1].sprite = spriteGUI[3].sprite;
                    spriteGUI[3].enabled = false;
                }
                else
                {
                    spriteGUI[1].enabled = true;
                }
                if (numberOne > 10 || numberTwo > 10 || numberOne == 0 || numberTwo == 0)
                {
                    ChoseMark("multiplication");
                }
                else
                {

                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }


                break;

            //DZIELENIE
            case "division":
                imgMark.sprite = imgsMarks[3];
                spriteGUI[5].enabled = false;
                ChoseRandomNumbers(spriteGUI[0]);
                ChoseRandomNumbers(spriteGUI[1]);
                ChoseRandomNumbers(spriteGUI[2]);
                ChoseRandomNumbers(spriteGUI[3]);
                ChoseRandomNumbers(spriteGUI[4]);
                numberOne = int.Parse(spriteGUI[4].sprite.name + spriteGUI[2].sprite.name + spriteGUI[0].sprite.name);
                numberTwo = int.Parse(spriteGUI[1].sprite.name + spriteGUI[3].sprite.name);

                if (numberOne < 100 && numberOne >= 10)
                {
                    spriteGUI[4].enabled = false;
                    spriteGUI[2].enabled = true;
                }
                if (numberOne < 10)
                {
                    spriteGUI[4].enabled = false;
                    spriteGUI[2].enabled = false;
                }
                if (numberOne > 100)
                {
                    spriteGUI[4].enabled = true;
                    spriteGUI[2].enabled = true;
                }

                if (numberTwo < 10)
                {
                    spriteGUI[1].sprite = spriteGUI[3].sprite;
                    spriteGUI[3].enabled = false;
                }
                else
                {
                    spriteGUI[3].enabled = true;

                }

                if (numberOne == 0 || numberTwo == 0 || numberTwo > 10 || numberOne % numberTwo != 0 || numberOne > 100 || CorrectReasult(numberOne, numberTwo, imgMark.sprite.name) > 10)
                {
                    ChoseMark("division");
                }
                else
                {
                    correctReasult = CorrectReasult(numberOne, numberTwo, imgMark.sprite.name);
                }
                break;



        }
    }

    //Usuwanie niepotrzebnych cyfr
    private void DeleteUnnecessaryNumbers(int k)
    {
        for (int i = k; i < 6; i++)
        {
            spriteGUI[i].enabled = false;
        }
    }

    //Losowanie cyfr
    private void ChoseRandomNumbers(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.sprite = img[Random.Range(0, 999) / 100];
    }

    //Obliczenie prawidłowego wyniku
    public static int CorrectReasult(int numberOne, int numberTwo, string mark)
    {
        switch (mark)
        {
            case "plus":
                return numberOne + numberTwo;
            case "minus":
                return numberOne - numberTwo;
            case "multiplier":
                return numberOne * numberTwo;
            case "divider":
                return numberOne / numberTwo;
        }
        return 0;
    }

    //Wyswietlanie prawidłowego wyniku
    private void ShowReasult()
    {
        if (correctReasult.ToString().Length == 1)
        {
            spriteReasultGUI[0].sprite = img[int.Parse(correctReasult.ToString()[0].ToString())];
            spriteReasultGUI[1].enabled = false;
            spriteReasultGUI[2].enabled = false;
        }
        else if (correctReasult.ToString().Length == 2)
        {
            spriteReasultGUI[0].sprite = img[int.Parse(correctReasult.ToString()[0].ToString())];
            spriteReasultGUI[1].sprite = img[int.Parse(correctReasult.ToString()[1].ToString())];
            spriteReasultGUI[2].enabled = false;
        }
        else if (correctReasult.ToString().Length == 3)
        {
            spriteReasultGUI[0].sprite = img[int.Parse(correctReasult.ToString()[0].ToString())];
            spriteReasultGUI[1].sprite = img[int.Parse(correctReasult.ToString()[1].ToString())];
            spriteReasultGUI[2].sprite = img[int.Parse(correctReasult.ToString()[2].ToString())];

        }
    }

    //Zmiana zmiennej wyniku na liczby jeżeli gracz dostanie zadanie na znalezienie liczby z działania 
    private void SearchCorrectResult(int x)
    {
        switch (x)
        {
            case 1:
                correctReasult = numberOne;
                break;
            case 2:
                correctReasult = numberTwo;
                break;
        }
    }

    private void ChangePosition(int value)
    {
        if (randomOperation != 2)
        {
            if (value == 1) go2.transform.localPosition = new Vector2(-0.6f, 0);
            if (value == 2) go2.transform.localPosition = new Vector2(-0.3f, 0);
            if (value == 3) go2.transform.localPosition = new Vector2(0, 0);
        }
        else
        {
            go2.transform.localPosition = new Vector2(-0.6f, 0);
        }


    }

}
