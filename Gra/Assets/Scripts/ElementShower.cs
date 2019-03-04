using UnityEngine;
using System.Collections;

public class ElementShower : MonoBehaviour
{
    public Sprite[] img = new Sprite[10];

    public SpriteRenderer[] spriteGUI = new SpriteRenderer[6];
    public SpriteRenderer imgMark;
    //public  SpriteRenderer[] spirteResultPlayer = new SpriteRenderer[3];

    //private static string elementGUI = "null";

   // private bool isResultColected = false;
    //private bool oneTiemm = false;

    
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isResultColected == false && elementGUI != "null" )
        //{
        //    //imgResultByPlayer.sprite = img[int.Parse(elementGUI)];
        //    isResultColected =true;
        //}

        //if (isResultColected == true && oneTiemm == false)
        //{
        //    oneTiemm = true;
        //    if (int.Parse(imgResultByPlayer.sprite.name) == RandomGenereatorNumbersForPlayer.correctReasult)
        //    {
        //        Debug.Log("Wynik poprawyny");
        //    }
        //    else
        //    {
        //        Debug.Log("Spróbuj jeszcze raz");
        //    }
        //}

    }
    
    public static void WhatElement (string element)
    {
       // elementGUI = element;
    }

}
