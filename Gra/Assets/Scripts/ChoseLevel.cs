using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseLevel : MonoBehaviour {
    public void PlayChosedGame(int nr)
    {
        Sounds.ClickButton();
        Player.countCorrectNumbers = 0;
        RandomGeneratorNumbersForElementsMap.listOfNumbers.Clear();
        SceneManager.LoadScene(nr);
    }
}
