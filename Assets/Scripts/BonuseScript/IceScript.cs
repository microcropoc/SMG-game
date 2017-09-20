using UnityEngine;
using System.Collections;

public class IceScript : MonoBehaviour {


	byte _life = 3;
	int timeLife = 300;
	Vector3 Angles;
	// Use this for initialization
	void Start()
	{
		Angles = transform.eulerAngles;

	}
	void FixedUpdate()
	{
		Angles.z += 5;
		transform.eulerAngles = Angles;
		if(--timeLife<=0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "bullet")
		{
		
			transform.position = new Vector3(transform.position.x + (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY, transform.position.y + (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX);
			if (--_life <= 0)
			{
				GameParam.Razbros = 0;
				Destroy(gameObject);
			}
		}
	}
}
