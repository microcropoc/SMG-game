using UnityEngine;
using System.Collections;

public class OnClickLevel4 : MonoBehaviour {

    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(0.8f);
        GameParam.SelectGameMode = 0;
        Application.LoadLevel(nameLevel);

    }
    // Use this for initialization
    void OnMouseDown()
    {
        //проверка на пиратство
      //  if (Application.genuine && Application.genuineCheckAvailable)
        {
          //  GameParam.CurrentLevel = 4;
            StartCoroutine(OpenLoadLevel("Level4"));
        }
    }
}
