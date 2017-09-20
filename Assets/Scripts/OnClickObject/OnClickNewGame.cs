using UnityEngine;
using System.Collections;

public class OnClickNewGame : MonoBehaviour {


    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(1.5f);
        //forFullVersion
         GameParam.SelectGameMode = 1;
        //forDemoVersion
        //GameParam.SelectGameMode = 0;
     //   GameParam.CurrentLevel = 1;
        Application.LoadLevel(nameLevel);

    }
    void OnMouseDown()
    {
        //проверка на пиратство
       // if(Application.genuine && Application.genuineCheckAvailable)
        StartCoroutine(OpenLoadLevel("Level1"));
	}

    
	
	// Update is called once per frame
	
}
