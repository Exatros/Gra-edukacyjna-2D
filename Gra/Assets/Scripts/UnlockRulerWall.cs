using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRulerWall : MonoBehaviour
{
    public GameObject RulerWall;
    private bool oneClick = false;
    private Animator anim;
    private static UnlockRulerWall instance;
    private Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        vector3 = RulerWall.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (oneClick)
        {
            RulerWall.transform.localScale -= new Vector3(Time.deltaTime*2, 0 , 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!oneClick)
        {
            oneClick = true;
            anim.SetTrigger("test_trigger");
            StartCoroutine(HideLasser());
            Sounds.LeverSound();
        }

    }

    public static void Reset()
    {
        instance.RulerWall.transform.localScale = instance.vector3;
        instance.RulerWall.SetActive(true);
        instance.anim.Rebind();
        instance.oneClick = false;

    }

    private IEnumerator HideLasser ()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        RulerWall.SetActive(false);

    }
}
