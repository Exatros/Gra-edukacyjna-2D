using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveUI : MonoBehaviour {
    public Canvas GUI;
    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
    }
}
