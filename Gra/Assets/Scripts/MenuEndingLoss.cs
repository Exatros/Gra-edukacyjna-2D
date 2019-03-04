using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndingLoss : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //Resetowanie poziomu 
    public void ResetLevel()
    {
        UnlockRulerWall.Reset();
        DestroyElementAfterCollected.HideWrongMark();
        Timer.times = 180;
        Time.timeScale = 1;
        Player.isEnd = false;
        Player.panel[1].gameObject.SetActive(false);
        DestroyElementAfterCollected.oneTimeColison = false;
        Heart.ResetHearts();
        player.transform.position = Player.startPosition;
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

    }

    public void Menu()
    {
        Player.countCorrectNumbers = 0;
        RandomGeneratorNumbersForElementsMap.listOfNumbers.Clear();
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
