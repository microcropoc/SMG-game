using UnityEngine;
using System.Collections;

public class FastBulletScript : MonoBehaviour {

	byte _life = 3;
	bool _activateBonus=false;
	int timeAction = 300;
	int timeLife = 300;
	Vector3 Angles;

	// Use this for initialization
	void Start () {
		Angles = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Angles.z += 5;
		transform.eulerAngles = Angles;

		if (_activateBonus)
		{
			if(--timeAction<=0)
			{
				GameParam.SleepFire = GameParam._constSleepFire;
				Destroy(gameObject);

			}
		}
		else
		{
			if (--timeLife <= 0)
			{
				GameParam.SleepFire *= 2.5f;

				Destroy(gameObject);

			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "bullet")
		{
			transform.position = new Vector3(transform.position.x + (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY, transform.position.y + (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX);
			if (--_life <= 0)
			{
				gameObject.transform.position = new Vector3(1000, 1000);//------------------
				GameParam.SleepFire /= 2.5f;
				_activateBonus = true;

			}
		}
	
	}
}
