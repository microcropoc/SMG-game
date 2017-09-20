using UnityEngine;
using System.Collections;

public class DestroyBulletSprite : MonoBehaviour {

	// Use this for initialization
    public float sleep = 0.05f;
   // public GameObject DestroyBulletSpr;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        sleep -= Time.deltaTime;
        if (sleep <= 0)
        {
            Destroy(gameObject);
        }
	
	}
}
