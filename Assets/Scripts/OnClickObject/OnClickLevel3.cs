﻿using UnityEngine;
using System.Collections;

public class OnClickLevel3 : MonoBehaviour {

    public IEnumerator OpenLoadLevel(string nameLevel)
    {
        rigidbody2D.gravityScale = 10f;
        yield return new WaitForSeconds(1f);
        GameParam.SelectGameMode = 0;
        Application.LoadLevel(nameLevel);

    }
    void OnMouseDown()
    {
        //проверка на пиратство
      //  if (Application.genuine && Application.genuineCheckAvailable)
        {
          //  GameParam.CurrentLevel = 3;
            StartCoroutine(OpenLoadLevel("Level3"));
        }
    }

   
}
