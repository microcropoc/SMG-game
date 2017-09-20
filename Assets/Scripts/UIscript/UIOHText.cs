using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIOHText : MonoBehaviour {

	// Use this for initialization

	Text _lifeOH;
	int _currentOH;
	void Start () 
	{
		_lifeOH = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		if (_currentOH != GameParam.Razbros / 10)
		{
			_currentOH = GameParam.Razbros / 10;
			_lifeOH.text = "OH: " + GameParam.Razbros / 10;
		}

	
	}
}
