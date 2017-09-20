using UnityEngine;
using System.Collections;

public class GilzaMove : MonoBehaviour {

	// Use this for initialization
    public static Vector3 PosGilza = new Vector3();
    public static Vector3 PosCell = new Vector3();
    Vector3 GilPosSetca;
    float X, Y;
    public float speed = 0.2f;
    private short GilSleep = 100;
    private short GilSleepMove = 25;
    void Start()
    {
       
        GilPosSetca = -PosGilza + PosCell;
        GilPosSetca.Normalize();
        X = GilPosSetca.x;
        Y = GilPosSetca.y;
        GilPosSetca = transform.position;
        


    }

    void FixedUpdate()
    {
        if (--GilSleepMove > 0)
        {
            GilPosSetca.y += speed * -X;
            GilPosSetca.x += speed * Y;
            transform.position = GilPosSetca;
        }
        else 
        if(--GilSleep<=0)
        {
            Destroy(gameObject);
        }
        

      
    }
}
