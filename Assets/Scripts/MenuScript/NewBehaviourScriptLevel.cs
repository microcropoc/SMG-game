using UnityEngine;
using System.Collections;
using System;


public class NewBehaviourScriptLevel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }

    }
 
}
