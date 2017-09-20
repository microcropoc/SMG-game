using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

	// Use this for initialization
    public GameObject Grass_obj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "panzer")
        {
            Destroy(Grass_obj);
        }
    }
}
