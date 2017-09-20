using UnityEngine;
using System.Collections;

public class MenuScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // if (Application.genuine && Application.genuineCheckAvailable)
            Application.LoadLevel("Menu");
        }
	}
}
