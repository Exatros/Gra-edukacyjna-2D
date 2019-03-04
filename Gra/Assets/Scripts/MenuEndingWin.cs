using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndingWin : MonoBehaviour {


    public void Menu()
    {
        RandomGeneratorNumbersForElementsMap.listOfNumbers.Clear();
        Player.countCorrectNumbers = 0;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PopSound()
    {
        Sounds.ClickButton();
    }
}
