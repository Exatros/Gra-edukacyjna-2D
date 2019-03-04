using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair_Murek : MonoBehaviour {

    public GameObject murek;
    private GameObject[] gameObjectMurek;
    private GameObject[] cloneToDestroy;
    private Vector2[] transformMurek;
    private bool oneClick = true;
    private float time = 0;
    public AudioClip openClip;
    public AudioSource audioSource;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Pobieranie ilosci obieków murek
        gameObjectMurek = GameObject.FindGameObjectsWithTag("Murek");
        transformMurek = new Vector2[gameObjectMurek.Length];
        //Przypisanie pozycji 
        for (int i = 0; i < gameObjectMurek.Length; i++)
        {
            transformMurek[i] = gameObjectMurek[i].transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.clip = openClip;
        audioSource.Play();
        anim.SetTrigger("test_trigger");
        DestroyClone();
        //Tworzenie nowych obiektów
        for (int i = 0; i < gameObjectMurek.Length; i++)
        {
            Instantiate(murek, transformMurek[i], Quaternion.identity);
        }
        oneClick = false;
        time = 0;
    }


    private void Update()
    {
        time += Time.deltaTime;
        //Używanie dzwigni co 2 sekundy
        if(time >= 2f && oneClick == false)
        {
            anim.SetTrigger("test_trigger_2");
            oneClick = true;
        }
    }

    private void DestroyClone()
    {
        //Usuwanie wszystkich obiektów
        cloneToDestroy = GameObject.FindGameObjectsWithTag("Murek");
        for (int i = 0; i < cloneToDestroy.Length; i++)
        {
            Destroy(cloneToDestroy[i], 0.5f);

        }
    }

}
