using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    //#region pause

    //public bool paused;

    //public GameObject PausePanel;

    //#endregion

    #region GameObject
    public GameObject Gilza_obj;
	public GameObject GunShutterEnd;
	public GameObject GunShutterFir;
	public GameObject GunXYFirePos;
	public GameObject GunXYMovePos;
	public GameObject Stational;
	public GameObject Bullet;
	public GameObject PanzerTrack;
	public GameObject GunPrice;
	public ParticleSystem FirePartSys;
    GameClasses.TouchGun SMG;
    //forAudioSourse
    GameObject AudioGunShot;
	#endregion

	bool CheckMous = false;
	bool CheckFire = false;

    #region AudioSourse
    AudioSource audioShot;
    #endregion

    #region Sleep_Fire
    float SleepFire;
	#endregion

	// Use this for initialization
	void Awake()
	{

		GameParam.init(Application.loadedLevelName);
		SleepFire = GameParam.SleepFire;

      

		#region InitializationPointEnd
		GameParam.PointEnd = GameObject.Find("Point_End").transform.position.y;
		#endregion

        #region InitializationAudioGunShot
        this.AudioGunShot = GameObject.Find("AudioGunShot")==null? this.gameObject:GameObject.Find("AudioGunShot");
        #endregion

		#region initStackObject
		GameParam.StackPanzerTrackForTanks.init(250);
        GameParam.StackBulletForGun.init(50);
		for (int i = 0; i < 100; i++)
			Instantiate(PanzerTrack);
		for (int i = 0; i < 50; i++)
			Instantiate(Bullet,new Vector2(1000,1000),Quaternion.identity);
		#endregion
	}

	
	void Start ()
	{
       // Input.multiTouchEnabled = false;
        //звук выстрела
        audioShot = (AudioGunShot.GetComponent<AudioSource>() as AudioSource);

		double GunXYMovePosF = MathSMG.getRadius(transform.position,GunXYMovePos.transform.position);
		double GunXYFirePosF = MathSMG.getRadius(transform.position, GunXYFirePos.transform.position);
		SMG = new GameClasses.TouchGun(gameObject,GunPrice, Bullet,FirePartSys, Camera.main.WorldToScreenPoint(transform.position),(float) GunXYMovePosF,(float) GunXYFirePosF);


        //#if UNITY_EDITOR
        //        Debug.Log("Unity Editor");
        //#endif

        //#if UNITY_ANDROID
				
        //#endif

              //  Debug.Log("Android");
              //  Debug.Log("Android Touch 0 ");
        //#region forPause

        //PausePanel.SetActive(paused);

        //#endregion

        #region InitializationGunPosition
        GameParam.GunPosition = new Vector2(Camera.main.WorldToScreenPoint(this.gameObject.transform.position).x, Camera.main.WorldToScreenPoint(this.gameObject.transform.position).y);
        #endregion

    }

   
	
	// Update is called once per frame
	void Update()
	{
		if(GameParam.IsPaused)
        {
            return;
        }

        #region OnMouseClickOrNotClick

        //if (Input.GetMouseButtonDown(0))
        //{
        //    CheckMous = true;
        //    CheckFire = SMG.Start();

        //}



        //if (Input.GetMouseButtonUp(0))
        //{
        //    CheckMous = false;
        //    //CheckFire = false;
        //}
        //if (CheckMous) CheckFire = SMG.Start();
        //// SMG.Start();

        #endregion

        #region forTouch

        CheckFire = SMG.Start();

        #endregion

      



    }
   
	void FixedUpdate()
	{
		
		
		if (CheckFire)
		{
				if (--SleepFire <= 0)
				{
					
					GameParam.Razbros+=15;
					SMG.Fire();
                    if(GameParam.IsSongActive)
					audioShot.Play();
					GilzaMove.PosGilza = Camera.main.ScreenToWorldPoint(GunShutterEnd.transform.position);
					GilzaMove.PosCell = Camera.main.ScreenToWorldPoint(GunShutterFir.transform.position);
					Instantiate(Gilza_obj, GunShutterEnd.transform.position, GunShutterEnd.transform.rotation);
					SleepFire = GameParam.SleepFire;

                }
                #region forTouch

                CheckFire = SMG.Start();

                #endregion

                #region forMouse

                //CheckFire = CheckMous && SMG.Start();

                #endregion

		}
		else {
			if (GameParam.Razbros > 0)
				GameParam.Razbros -= 15;
		}
			
	   
		   
		}

}
