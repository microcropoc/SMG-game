﻿using UnityEngine;
using System.Collections;

public class UIbtnSongOff : MonoBehaviour {


    //переписать!!!!!
	// Use this for initialization
	void Start () {
      this.gameObject.SetActive(!(GameParam.IsSongActive));
	}
	
	// Update is called once per frame

    public void OnClickToHideThis()
    {

        this.gameObject.SetActive(false);

    }

    public void OnClickToShowThis()
	{
		this.gameObject.SetActive(true);
        GameParam.IsSongActive = false;
	}
}
