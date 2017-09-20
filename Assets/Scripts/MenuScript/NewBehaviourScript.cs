using System.Collections;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour {

	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	
}
