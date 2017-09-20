using UnityEngine;
using System.Collections;

public class OnClickExit : MonoBehaviour {

    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(0.8f);
        Application.Quit();
    }

    void OnMouseDown()
    {
        StartCoroutine(OpenLoadLevel("Exit"));
    }
   
}
