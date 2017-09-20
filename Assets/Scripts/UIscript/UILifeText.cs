using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILifeText : MonoBehaviour {


    Text _lifeText;
    int _currentLife;

	// Use this for initialization
	void Start () {

        _lifeText = gameObject.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (_currentLife != GameParam.LifeSMG)
        {
            _currentLife = GameParam.LifeSMG;
            _lifeText.text = "Life: " + _currentLife;
        }
	}
}
