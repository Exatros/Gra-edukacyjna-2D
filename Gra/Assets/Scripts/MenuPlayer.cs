using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayer : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    public void ExitGame()
    {
        Player.countCorrectNumbers = 0;
        RandomGeneratorNumbersForElementsMap.listOfNumbers.Clear();
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        Player.panel[2].gameObject.SetActive(false);
        Player.isPause = false;
    }
    //Resetowanie poziomu
    public void RestartLevel()
    {
        UnlockRulerWall.Reset();
        DestroyElementAfterCollected.HideWrongMark();
        Timer.times = 180;
        Time.timeScale = 1;
        Player.isPause = false;
        Player.panel[2].gameObject.SetActive(false);
        DestroyElementAfterCollected.oneTimeColison = false;
        Heart.ResetHearts();
        player.transform.position = Player.startPosition;
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

    }
    public void PopSound()
    {
        Sounds.ClickButton();
    }
}
