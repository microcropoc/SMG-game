using UnityEngine;
using System.Collections;

public class PanzerEzh : MonoBehaviour {

	// Use this for initialization
   // public GameObject Ezh_obj;
    float SleepDie = 0.5f;
    bool Die = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Die)
        {
            SleepDie -= Time.deltaTime;
            if (SleepDie <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "panzer")
        {
            Die = true;
        }
    }
}
