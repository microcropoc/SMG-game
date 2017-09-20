using UnityEngine;
using System.Collections;

public class Fraps : MonoBehaviour {

    string folder = "ScreenshotFolder";
    int farmeRate = 1;
	// Use this for initialization
	void Start () {
        Time.captureFramerate = farmeRate;
        System.IO.Directory.CreateDirectory(folder);
	}
	
	// Update is called once per frame
	void Update () {
        string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount);
        Application.CaptureScreenshot(name);
	}
}
