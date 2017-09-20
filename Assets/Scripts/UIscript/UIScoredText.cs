using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoredText : MonoBehaviour {

	Text _scoredText;
	int _currentScored;
	// Use this for initialization
	void Start () {

		_scoredText = gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (_currentScored != GameParam.ScoredSMG)
		{
			_currentScored = GameParam.ScoredSMG;
			_scoredText.text = "Scored: "+_currentScored;
		}
	
	}
}
