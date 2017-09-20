using UnityEngine;
using System.Collections;

public class UIPanelInScoresMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	 public void OnClick () 
     {
	//  if (Application.genuine && Application.genuineCheckAvailable)
        Application.LoadLevel("Menu");
	 }
}
