using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float times;
    public Text textTime;

    // Start is called before the first frame update
    void Start()
    {
        if(Player.countCorrectNumbers >= 2)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        times -= Time.deltaTime;
        textTime.text = Mathf.Round(times).ToString();
        noMoreTime(Mathf.RoundToInt(times));
    }

    private void noMoreTime(int times)
    {
        
        if(times == 0 && !Player.isEnd)
        {
            UnlockRulerWall.Reset();
            DestroyElementAfterCollected.HideWrongMark();
            Player.isEnd = true;
            Time.timeScale = 0;
            Player.panel[1].gameObject.SetActive(true);
        }
    }
}
