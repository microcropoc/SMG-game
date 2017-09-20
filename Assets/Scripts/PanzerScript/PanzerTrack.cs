using UnityEngine;
using System.Collections;

public class PanzerTrack : MonoBehaviour {

	short time = 30;
 
	void OnEnable()
	{
		time = 30;
	}

	void FixedUpdate()
	{
		if (--time < 0)
		{
			//gameObject.SetActive(false);
            GameParam.StackPanzerTrackForTanks.Push(gameObject);
		}
	}
}
