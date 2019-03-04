using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreatePositionForNumbers : MonoBehaviour
{


    public GameObject[] randomNumbers = new GameObject[3];
    public GameObject correctNumbers;
    private GameObject[] cloneToDestroy;
    private GameObject[] resPoints;
    private GameObject[] cloneList;
    private GameObject clone;
    private int maxOneDigitNmbers = 0;
    private int random;


    // Use this for initialization
    void Start()
    {
        //Tworzenie nowej liczby i przypisywanie jej odpowiedniej wartości 
        resPoints = GameObject.FindGameObjectsWithTag("Respoint");
        GenPositionForNumbers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Generowanie losowej liczby na ustalone pozycje na mapie
    private void GenPositionForNumbers()
    {
        int ran = Random.Range(1, resPoints.Length);
        for (int i = 0; i < resPoints.Length; i++)
        {
            if (i == ran)
            {
                //tworzenie poprawnego obiektu
                clone = Instantiate(correctNumbers, resPoints[i].transform.position, Quaternion.identity);
            }
            else
            {
                //Generowanie wszytkich liczb 1,2,3 cyfrowych dla poziomów najtrudniejszych
                if (RandomGenereatorNumbersForPlayer.sceneLevel.name == "addition_hard" || RandomGenereatorNumbersForPlayer.sceneLevel.name == "subtraction_hard")
                {
                    random = Random.Range(0, 3);
                    if (maxOneDigitNmbers > 9) // warunek sprawdzania czy zostały juz uzyte wszystkie mozliwe jedno cyfrowe liczby
                    {
                        random = Random.Range(1, 3);
                    }
                    else
                    {
                        //tworzenie losowej liczby
                        clone = Instantiate(randomNumbers[random], resPoints[i].transform.position, Quaternion.identity);
                        clone.tag = "cloneNumbers";
                        if(random == 0) maxOneDigitNmbers++;
                    }


                }
                else // Generowanie liczb 1,2 cyfrowych
                {
                    random = Random.Range(0, 2);
                    if (maxOneDigitNmbers > 9)
                    {
                        random = 1;
                    }
                    else
                    {
                        //tworzenie losowej liczby
                        clone = Instantiate(randomNumbers[random], resPoints[i].transform.position, Quaternion.identity);
                        clone.tag = "cloneNumbers";
                        if (random == 0) maxOneDigitNmbers++;
                    }
                }
            }
        }
    }
}
