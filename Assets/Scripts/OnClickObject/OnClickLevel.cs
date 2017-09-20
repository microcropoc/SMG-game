using UnityEngine;
using System.Collections;

public class OnClickLevel : MonoBehaviour {

    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(1.3f);
        Application.LoadLevel(nameLevel);

    }

    

    void OnMouseDown()
    {
        //проверка на пиратство
        //  if (Application.genuine && Application.genuineCheckAvailable)
        #region forFullVersion

        StartCoroutine(OpenLoadLevel("MenuLevel"));

        #endregion

        #region forDemoVersion

      //  StartCoroutine(OpenLoadLevel("Menu"));

        #endregion
        
    }
}
