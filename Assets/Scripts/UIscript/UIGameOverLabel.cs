using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameOverLabel : MonoBehaviour {

    Text _labelGameOver;
    bool Check;
	// Use this for initialization
	void Start () {
       _labelGameOver=gameObject.GetComponent<Text>();
       //заглушка
        
	}
	
	// Update is called once per frame
	void Update () {

	if(this.isActiveAndEnabled)
    {
        Debug.Log("InvokeGameOver");
        if (!Check)
        {
            if (GameParam.RecordScoreBeforeGameOver())
            {
                _labelGameOver.text = "New Score";

            }
            else
            {
                _labelGameOver.text = "Score";
            }

            Check = true;
        }
    }

	}
}
