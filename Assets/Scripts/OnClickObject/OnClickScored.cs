using UnityEngine;
using System.Collections;

public class OnClickScored : MonoBehaviour {


    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(nameLevel);

    }
    // Use this for initialization
    void OnMouseDown()
    {
        #region forFullVersion

        StartCoroutine(OpenLoadLevel("MenuScores"));

        #endregion

        #region forDemoVersion

       // StartCoroutine(OpenLoadLevel("MenuScoresDemo"));

        #endregion
    }
}
