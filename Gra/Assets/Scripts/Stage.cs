using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Text textTime;
    public GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        if (Player.countCorrectNumbers == 2)
        {
            walls.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textTime.text = Player.countCorrectNumbers.ToString();

    }


}
