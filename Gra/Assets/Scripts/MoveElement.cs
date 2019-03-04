using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElement : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;
    private float positionY;
    private float randomTimeForStartMove = 0;

    // Use this for initialization
    void Start () {

        positionY = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        if (randomTimeForStartMove > Random.Range(0f, 10f))
        {
            MoveUpAndDown();
        }
        else
        {
            randomTimeForStartMove += Time.time;
        }
    }
    //Poruszanie w góre i w dół
    private void MoveUpAndDown()
    {
        gameObject.transform.Translate(MovingDirection * Time.smoothDeltaTime * Random.Range(0.2f, 0.4f));

        if (gameObject.transform.position.y > 0.5f + positionY)
        {
            MovingDirection = Vector3.down;
        }
        else if (gameObject.transform.position.y < positionY)
        {
            MovingDirection = Vector3.up;
        }
    }
}
