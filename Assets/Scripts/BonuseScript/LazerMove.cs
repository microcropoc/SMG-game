using UnityEngine;
using System.Collections;

public class LazerMove : MonoBehaviour {

    public GameObject LazerColor;
    public Vector3 PosLazer = new Vector3();
    public float SpeedLazer = 2.8f;
    float X, Y;
	// Use this for initialization
	void Start () {
        PosLazer = LazerColor.transform.position;
        X = GunLazerUP.X;
        Y = GunLazerUP.Y;
	}
	
	// Update is called once per frame
	void Update () {
        PosLazer.y += SpeedLazer * -X;
        PosLazer.x += SpeedLazer * Y;
        LazerColor.transform.position = PosLazer;

        if ((Camera.main.WorldToScreenPoint(LazerColor.transform.position).x >= Screen.width) || (Camera.main.WorldToScreenPoint(LazerColor.transform.position).x <= 0) || (Camera.main.WorldToScreenPoint(LazerColor.transform.position).y >= Screen.height) || (Camera.main.WorldToScreenPoint(LazerColor.transform.position).y <= 0))
        {
            Destroy(LazerColor);
        }

	}

    void OnTrigger()
    {

        Destroy(LazerColor);
    }
}
