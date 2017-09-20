using UnityEngine;
using System.Collections;

public class OnClickLevel1 : MonoBehaviour {

	public IEnumerator OpenLoadLevel(string nameLevel)
	{
            rigidbody2D.gravityScale = 10f;
            yield return new WaitForSeconds(1.5f);
			GameParam.SelectGameMode = 0;
            Application.LoadLevel(nameLevel);
			
	}
	void OnMouseDown()
	{
        //проверка на пиратство
      //  if (Application.genuine && Application.genuineCheckAvailable)
        {
           // GameParam.CurrentLevel = 1;
            StartCoroutine(OpenLoadLevel("Level1"));
        }
	}

}
