using UnityEngine;
using System.Collections;

public class DesertPanzer : MonoBehaviour {

	#region Bonuse
	public GameObject FastBullet;
	public byte verFastBullet = 16;
	public GameObject IceGun;
	public byte verIceGun = 8;
	#endregion
	// Use this for initialization
	#region VARIABLE
	public GameObject DesertPanzer_obj;
	public GameObject DesertPanzGun;
	public GameObject DesertPanzGunPrice;
	public GameObject PanzerDestroy_obj;
	public GameObject PanzerTrack;
	public GameObject PointPanzerTrack;
	public ParticleSystem PartSys;
	#region Normal_look
	public GameObject PunzerPointCenter;
	public GameObject PunzerPointLook;

	#endregion

	//public static float speed = 0.1f;

	private GameClasses.PanzerMove DesertPanzerMover;

	#endregion

	// Use this for initializprivaation
	#region FUNCTION

	void Awake()
	{
		#region InitPanzer
		DesertPanzerMover = new GameClasses.PanzerMove(DesertPanzer_obj, PunzerPointCenter, PunzerPointLook, PanzerTrack, PointPanzerTrack, GameParam.PointEnd, DesertPanzGun, DesertPanzGunPrice, PartSys);
		DesertPanzerMover.health = 3;
		DesertPanzerMover.speed += 0.05f;
		DesertPanzerMover.CountMoveDown = 19;
		DesertPanzerMover.constCountMoveDown = 19;
		#endregion
	}

	void Start()
	{
		StartCoroutine(DesertPanzerMover.InstantinateTrack());
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		DesertPanzerMover.PanzerAction();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		switch (col.gameObject.tag)
		{
			case "bullet":
				#region Bullet
			GameParam.ScoredSMG += 5;

			DesertPanzerMover.Position.y += (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX;
			DesertPanzerMover.Position.x += (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY;
		   
			switch (Random.Range(0, 2))
			{
				case 0:
					DesertPanzerMover.RotateLeftGun(15);
					break;
				case 1:
					DesertPanzerMover.RotateRightGun(15);
					break;

			}


			//
			if (--DesertPanzerMover.health <= 0)
			{

				Instantiate(PanzerDestroy_obj, DesertPanzer_obj.transform.position, PanzerDestroy_obj.transform.rotation);

				#region RandomRenderBonuse
                if (Random.Range(0, verFastBullet) == verFastBullet/2)
				{
					Instantiate(FastBullet, transform.position, transform.rotation);
				}

                if (Random.Range(0, verIceGun) == verIceGun / 2)
				{
					Instantiate(IceGun, transform.position, transform.rotation);
				}
				#endregion
				Destroy(DesertPanzer_obj);

				// Handheld.Vibrate();
				GameParam.ScoredSMG += 35;

			}
			if (DesertPanzerMover.health == 1)
			{
				DesertPanzerMover.PanzerBurn();

			}
		#endregion
				break;
			case "ezh":
				#region Ezh
				Instantiate(PanzerDestroy_obj, DesertPanzer_obj.transform.position, PanzerDestroy_obj.transform.rotation);
				Destroy(DesertPanzer_obj);
				#endregion
				break;
			case "Cactus":
			case "panzer":
				#region Cactus
				if (DesertPanzerMover.StabilityAngles(10))
				{
					if (DesertPanzerMover.Angles.z == 90 || DesertPanzerMover.Angles.z == 270)
					{

						#region Random_Move_Palm
						switch (Random.Range(0, 2))
						{
							case 0:
								DesertPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
								break;
							case 1:
								DesertPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
								//   chechRight=true;
								// CountRotation = 16;
								break;
							default:
								DesertPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
								break;
						}

						#endregion
					}
					else
						if (DesertPanzerMover.Angles.z == 0)
						{
							DesertPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
						}
						else
							if (DesertPanzerMover.Angles.z == 180)
							{
								DesertPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
							}
				}
				#endregion
				break;
		}
	}
	#endregion

}
