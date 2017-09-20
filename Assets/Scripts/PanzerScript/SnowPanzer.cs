using UnityEngine;
using System.Collections;
public class SnowPanzer : MonoBehaviour
{
    #region Bonuse
    public GameObject FastBullet;
    public byte verFastBullet = 10;
    public GameObject IceGun;
    public byte verIceGun = 8;
    #endregion

    //  public Vector3 Position;
    #region VARIABLE
    public GameObject SnowPanz;
    public GameObject SnowPanzGun;
    public GameObject SnowPanzGunPrice;
    public GameObject SnowPanzerDestroy_obj;
    public GameObject SnowPanzerTrack;
    public GameObject SnowPointPanzerTrack;
    public ParticleSystem SnowPartSys;
    #region Normal_look
    public GameObject SnowPunzerPointCenter;
    public GameObject SnowPunzerPointLook;

    #endregion
    private GameClasses.PanzerMove SnowPanzerMover;

    #endregion

    // Use this for initializprivaation
    #region FUNCTION

    void Awake()
    {
        SnowPanzerMover = new GameClasses.PanzerMove(SnowPanz, SnowPunzerPointCenter, SnowPunzerPointLook, SnowPanzerTrack, SnowPointPanzerTrack, GameParam.PointEnd, SnowPanzGun, SnowPanzGunPrice, SnowPartSys) { health = 6 };
    }

    void Start()
    {
        StartCoroutine(SnowPanzerMover.InstantinateTrack());
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        SnowPanzerMover.PanzerAction();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {
            case "bullet":
                #region Bullet
                GameParam.ScoredSMG += 5;
                    SnowPanzerMover.Position.y += (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX;
                    SnowPanzerMover.Position.x += (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY;


                    ////audio------------
                    //(this.GetComponent<AudioSource>() as AudioSource).Play();

                    ////-----------------

                    //
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            SnowPanzerMover.RotateLeftGun(15);
                            break;
                        case 1:
                            SnowPanzerMover.RotateRightGun(15);
                            break;

                    }
                    if (--SnowPanzerMover.health <= 0)
                    {

                        Instantiate(SnowPanzerDestroy_obj, SnowPanz.transform.position, SnowPanzerDestroy_obj.transform.rotation);
                        #region RandomRenderBonuse
                        if (Random.Range(0, verFastBullet) == verFastBullet / 2)
                        {
                            Instantiate(FastBullet, transform.position, transform.rotation);
                        }

                        if (Random.Range(0, verIceGun) == verIceGun / 2)
                        {
                            Instantiate(IceGun, transform.position, transform.rotation);
                        }
                        #endregion
                        Destroy(SnowPanz);
                        GameParam.ScoredSMG += 35;

                    }
                    if (SnowPanzerMover.health == 1)
                    {
                        SnowPanzerMover.PanzerBurn();

                    }
                #endregion
                break;

            case "ezh":
                #region Ezh
                Instantiate(SnowPanzerDestroy_obj, SnowPanz.transform.position, SnowPanzerDestroy_obj.transform.rotation);
                Destroy(SnowPanz);
#endregion
                break;
            case "Elka":
            case "panzer":
                #region Elka
                if (SnowPanzerMover.StabilityAngles(10))
                {
                    if (SnowPanzerMover.Angles.z == 90 || SnowPanzerMover.Angles.z == 270)
                    {

                        #region Random_Move_Palm
                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                SnowPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                break;
                            case 1:
                                SnowPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                                //   chechRight=true;
                                // CountRotation = 16;
                                break;
                            default:
                                SnowPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                break;
                        }

                        #endregion
                    }
                    else
                        if (SnowPanzerMover.Angles.z == 0)
                        {
                            SnowPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                        }
                        else
                            if (SnowPanzerMover.Angles.z == 180)
                            {
                                SnowPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                            }
                }
                #endregion  
                break;
        }
       
    }
    #endregion

}