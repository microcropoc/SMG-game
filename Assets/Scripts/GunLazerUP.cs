using UnityEngine;
using System.Collections;

public class GunLazerUP : MonoBehaviour {
    public GameObject LazerColor;
    public GameObject LazerFir;
    public GameObject LazerEnd;
    Vector3 LazFirScr = new Vector3();
    Vector3 LazEndScr = new Vector3();
    Vector3 NormalFirEndScr = new Vector3();
    Vector3 LazerPos = new Vector3();
    public static float X, Y;
	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
        LazFirScr = Camera.main.ScreenToWorldPoint(LazerFir.transform.position);
        LazEndScr = Camera.main.ScreenToWorldPoint(LazerEnd.transform.position);
        NormalFirEndScr = LazFirScr - LazEndScr;
        NormalFirEndScr.Normalize();
        X = NormalFirEndScr.x;
        Y = NormalFirEndScr.y;
        LazerPos = LazerColor.transform.position;
        Instantiate(LazerColor,LazerEnd.transform.position,LazerEnd.transform.rotation);

  

       
	
	}
}
