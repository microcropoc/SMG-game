using UnityEngine;
using System.Collections;
public class Panzer : MonoBehaviour
{

    #region Bonuse
    public GameObject FastBullet;
    public byte verFastBullet = 15;
    public GameObject IceGun;
    public byte verIceGun = 10;
    #endregion

    //  public Vector3 Position;
    #region VARIABLE
    public GameObject Panzer_obj;
    public GameObject PanzGun;
    public GameObject PanzGunPrice;
    public GameObject PanzerDestroy_obj;
    public GameObject PanzerTrack;
    public GameObject PointPanzerTrack;
    public ParticleSystem PartSys;
    #region Normal_look

    public GameObject PunzerPointCenter;
    public GameObject PunzerPointLook;
    
    #endregion
  
    //public static float speed = 0.1f;

    private GameClasses.PanzerMove PanzerMover;
    
    #endregion

    // Use this for initializprivaation
    #region FUNCTION

    void Awake()
    {
        #region InitPanzer
        PanzerMover = new GameClasses.PanzerMove(Panzer_obj, PunzerPointCenter, PunzerPointLook, PanzerTrack, PointPanzerTrack, GameParam.PointEnd, PanzGun, PanzGunPrice, PartSys);
        PanzerMover.health = 4;
        PanzerMover.speed += 0.022f;
        PanzerMover.CountMoveDown = 23;
        PanzerMover.constCountMoveDown = 23; ;
        #endregion
    }
    void Start()
    {
        StartCoroutine(PanzerMover.InstantinateTrack());     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PanzerMover.PanzerAction();
    }


    int timePanzerStay=0;

    void OnTriggerStay2D(Collider2D col)
    {
        //if(col.gameObject.tag=="panzer")
        //{
        //    if(timePanzerStay++>1)
        //    {
        //        timePanzerStay = 0;
        //        if (PanzerMover.StabilityAngles(10))
        //        {
        //            if (PanzerMover.Angles.z == 90 || PanzerMover.Angles.z == 270)
        //            {

        //                #region Random_Move_Palm
        //                switch (Random.Range(0, 2))
        //                {
        //                    case 0:
        //                        PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
        //                        break;
        //                    case 1:
        //                        PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
        //                        //   chechRight=true;
        //                        // CountRotation = 16;
        //                        break;
        //                    default:
        //                        PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
        //                        break;
        //                }

        //                #endregion
        //            }
        //            else
        //                if (PanzerMover.Angles.z == 0)
        //                {
        //                    PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
        //                }
        //                else
        //                    if (PanzerMover.Angles.z == 180)
        //                    {
        //                        PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
        //                    }
        //        }
        //    }
        //}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Grass":
                #region Grass
                Destroy(col.gameObject);
                #endregion
                break;

            case "bullet":
                #region Bullet
                GameParam.ScoredSMG += 5;
                PanzerMover.Position.y += (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX;
                PanzerMover.Position.x += (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY;
                //
                switch (Random.Range(0, 2))
                {
                    case 0:
                        PanzerMover.RotateLeftGun(15);
                        break;
                    case 1:
                        PanzerMover.RotateRightGun(15);
                        break;
                }
                if (--PanzerMover.health<=0)
                {
               
                    Instantiate(PanzerDestroy_obj, Panzer_obj.transform.position, PanzerDestroy_obj.transform.rotation);
                    if (Random.Range(0, verFastBullet) == verFastBullet/2)
                    {
                        Instantiate(FastBullet,transform.position,transform.rotation);
                    }

                    if (Random.Range(0, verIceGun) == verIceGun/2)
                    {
                        Instantiate(IceGun, transform.position, transform.rotation);
                    }
                    Destroy(Panzer_obj);
        
                       // Handheld.Vibrate();
                    GameParam.ScoredSMG += 35;

                }
                if (PanzerMover.health == 1)
                   PanzerMover.PanzerBurn();
                #endregion
                break;

            case "ezh":
                #region Ezh
                Instantiate(PanzerDestroy_obj, Panzer_obj.transform.position, PanzerDestroy_obj.transform.rotation);
                Destroy(Panzer_obj);
                #endregion
                break;

            case "palm":
            case "panzer":
                #region Palm
                if (col.gameObject.tag == "palm" || col.gameObject.tag == gameObject.tag)
                {
                  //  timePanzerStay = 0;
                    if (PanzerMover.StabilityAngles(10))
                    {
                        if (PanzerMover.Angles.z == 90 || PanzerMover.Angles.z == 270)
                        {

                            #region Random_Move_Palm
                            switch (Random.Range(0, 2))
                            {
                                case 0:
                                    PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                    break;
                                case 1:
                                    PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                                    //   chechRight=true;
                                    // CountRotation = 16;
                                    break;
                                default:
                                    PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                    break;
                            }

                            #endregion
                        }
                        else
                            if (PanzerMover.Angles.z == 0)
                            {
                                PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                            }
                            else
                                if (PanzerMover.Angles.z == 180)
                                {
                                    PanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                }
                    }
                }
                #endregion
                break;
        }
        
    }

    #endregion


}
