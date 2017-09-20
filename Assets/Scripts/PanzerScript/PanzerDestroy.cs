using UnityEngine;
using System.Collections;

public class PanzerDestroy : MonoBehaviour {

    public ParticleSystem Boom;
	// Use this for initialization
   // public GameObject PanzerDestroy_obj;
  //  public float sleep = 3f;
  //  private short Sleep = 50;
	void Start () {
        Destroy(gameObject,1f);
      //  ParticleSystem Boom = GetComponent<ParticleSystem>();
        Boom.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
     //   Boom.Play();
       // sleep -= Time.deltaTime;
       // if (--Sleep <= 0)
        //{
            
        //}
	}
}
