using UnityEngine;
using System.Collections;
using System.Threading;

public class Enemy_Spawn : MonoBehaviour {
    public GameObject Spw0;
    public GameObject Spw1;
    public GameObject Spw2;
    public GameObject PanzerClone;
    public float TimeStart = 2f;
    public float TimeDecriment = 0.01f;
    public float sleep;
    public int RandomSpw;
	// Use this for initialization
	void Start () {
       // RandomSpw = Random.Range(0,3);
        sleep = TimeStart;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        sleep-=Time.deltaTime;
        if (sleep <= 0)
        {
        if (TimeStart >= 1.2f) {
           
                switch (Random.Range(0, 3))
                {
                    case 0:
                        Instantiate(PanzerClone, Spw0.transform.position, PanzerClone.transform.rotation);
                        break;
                    case 1:
                        Instantiate(PanzerClone, Spw1.transform.position, PanzerClone.transform.rotation);
                        break;
                    case 2:
                        Instantiate(PanzerClone, Spw2.transform.position, PanzerClone.transform.rotation);
                        break;
                }
            }
            else
            {
                switch (Random.Range(0, 9))
                {
                    case 0:
                        Instantiate(PanzerClone, Spw0.transform.position, PanzerClone.transform.rotation);
                        break;
                    case 1:
                        Instantiate(PanzerClone, Spw1.transform.position, PanzerClone.transform.rotation);
                        break;
                    case 2:
                        Instantiate(PanzerClone, Spw2.transform.position, PanzerClone.transform.rotation);
                        break;
                        //----------
                    case 3:
                        Instantiate(PanzerClone, new Vector3((Spw1.transform.position.x + Spw2.transform.position.x) / 2, (Spw1.transform.position.y + Spw2.transform.position.y) / 2), PanzerClone.transform.rotation);
                        break;
                    case 4:
                        Instantiate(PanzerClone, new Vector3((Spw1.transform.position.x + Spw2.transform.position.x) / 1.2f, Spw2.transform.position.y ), PanzerClone.transform.rotation);
                        break;
                    case 5:
                        Instantiate(PanzerClone, new Vector3((Spw1.transform.position.x + Spw2.transform.position.x) / 4, Spw0.transform.position.y), PanzerClone.transform.rotation);
                        break;
                       //-----------
                    case 6:
                        Instantiate(PanzerClone, new Vector3((Spw0.transform.position.x + Spw2.transform.position.x) / 2, (Spw0.transform.position.y + Spw2.transform.position.y) / 2), PanzerClone.transform.rotation);
                        break;
                    case 7:
                        Instantiate(PanzerClone, new Vector3((Spw0.transform.position.x + Spw2.transform.position.x) / 1.2f, Spw2.transform.position.y), PanzerClone.transform.rotation);
                        break;
                    case 8:
                        Instantiate(PanzerClone, new Vector3((Spw0.transform.position.x + Spw2.transform.position.x) / 4, Spw0.transform.position.y), PanzerClone.transform.rotation);
                        break;
                }
            }
        
    sleep = TimeStart;
            if(TimeStart>0.6f)
            {
                TimeStart -= TimeDecriment;
            }
    
  //  Debug.Log(TimeStart);
                    }
	}
}
