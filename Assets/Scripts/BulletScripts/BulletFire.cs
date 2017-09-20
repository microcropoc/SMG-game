using UnityEngine;
using System.Collections;


public class BulletFire : MonoBehaviour {

	public GameObject BulletDestroy;
	private short _time = 38;
	Vector2 PosBullet = new Vector3();
	Vector2 PosCell = new Vector3();
	Vector2 BulPosSetca;
	float X, Y;



	void OnEnable()
	{
		_time = 38;
		Start1();

	}
	void Start1 () {
		PosBullet = Camera.main.WorldToScreenPoint(transform.position);

        #region forTouch

        //if (Input.touchCount > 0)
        //    PosCell = Input.touches[0].position;
        //else
        //    GameParam.StackBulletForGun.Push(gameObject);

        #endregion

        #region forMouse

        //PosCell = Input.mousePosition;

        #endregion

        if (GameParam.GunPosition != null)
        {
            PosCell = GameParam.GunPosition;
        }
        else
        {
            GameParam.StackBulletForGun.Push(gameObject);
        }
        switch (Random.Range(0, 4))
		{
			case 0:
			case 1:
				PosCell.x += GameParam.RazbrosFactor * Random.Range(0, GameParam.Razbros);
				PosCell.y += GameParam.RazbrosFactor * Random.Range(0, GameParam.Razbros);
				break;
			case 2:
			case 3:
				PosCell.x -= GameParam.RazbrosFactor * Random.Range(0, GameParam.Razbros);
				PosCell.y -= GameParam.RazbrosFactor * Random.Range(0, GameParam.Razbros);
				break;
		}

		BulPosSetca = PosBullet - PosCell;
		BulPosSetca.Normalize();
		X = BulPosSetca.x;
		Y = BulPosSetca.y;
		BulPosSetca = transform.position;
        this.transform.rotation = Quaternion.AngleAxis((Mathf.Atan2(Y, X) * Mathf.Rad2Deg)-180, Vector3.forward);
		//Destroy(gameObject, 1f); 
	
	}

	void Update()
	{
		transform.position = BulPosSetca;
	}
	
	void FixedUpdate () {

		if (--_time<0)
			GameParam.StackBulletForGun.Push(gameObject);

			BulPosSetca.y += GameParam.BulletSpeed * -X;
			BulPosSetca.x += GameParam.BulletSpeed * Y;
			
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (gameObject.activeSelf)
		if ((col.gameObject.tag != "Grass") && (col.gameObject.tag != "ezh") && (col.gameObject.tag != "Gilza"))
		{
			GameParam.ImpulsBulletX = X;
			GameParam.ImpulsBulletY = Y;
			Instantiate(BulletDestroy, transform.position, transform.rotation);


            GameParam.StackBulletForGun.Push(gameObject);
			//Destroy(gameObject);
		}
		
	}
}
