using UnityEngine;
using System.Collections;

public class Hide : MonoBehaviour
{
    //Ukrywanie murku na 2 sekundy
    public IEnumerator HideBlockFor2Seconds(GameObject gameObject, Animator anim)
    {
        anim.SetTrigger("Hide_wall");
        yield return new WaitForSecondsRealtime(1);
        gameObject.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        gameObject.gameObject.SetActive(true);
        anim.Rebind();
    }
}
