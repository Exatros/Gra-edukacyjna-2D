using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMove : MonoBehaviour {

    public GameObject platform;

    private float moveSpeed = 0;

    private Transform currenPoint;

    public Transform[] points;

    public int pointSelection;

    private void Start()
    {
        currenPoint = points[pointSelection];

        if (Player.countCorrectNumbers == 0)
        {
            moveSpeed = 1.5f;
        }
        else if (Player.countCorrectNumbers == 1)
        {
            moveSpeed = 2.5f;
        }
        else if (Player.countCorrectNumbers == 2)
        {
            moveSpeed = 3.5f;
        }
    }

    private void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currenPoint.position,Time.deltaTime * moveSpeed);
        if (platform.transform.position == currenPoint.position)
        {
            pointSelection++;
            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currenPoint = points[pointSelection];
        }
    }

}
