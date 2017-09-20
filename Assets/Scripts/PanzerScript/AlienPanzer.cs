using UnityEngine;
using System.Collections;

public class AlienPanzer : MonoBehaviour {


    #region Bonuse
    public GameObject FastBullet;
    public byte verFastBullet = 6;
    public GameObject IceGun;
    public byte verIceGun = 6;
    #endregion

    //  public Vector3 Position;
    #region VARIABLE
    public GameObject AlienPanz;
    public GameObject AlienPanzGun;
    public GameObject AlienPanzGunPrice;
    public GameObject AlienPanzerDestroy_obj;
    public GameObject AlienPanzerTrack;
    public GameObject AlienPointPanzerTrack;
    public ParticleSystem SnowPartSys;
    #region Normal_look
    public GameObject AlienPunzerPointCenter;
    public GameObject AlienPunzerPointLook;

    #endregion
    private GameClasses.PanzerMove AlienPanzerMover;

    #endregion

    // Use this for initializprivaation
    #region FUNCTION

    void Awake()
    {
        AlienPanzerMover = new GameClasses.PanzerMove(AlienPanz, AlienPunzerPointCenter, AlienPunzerPointLook, AlienPanzerTrack, AlienPointPanzerTrack, GameParam.PointEnd, AlienPanzGun, AlienPanzGunPrice, SnowPartSys) { health = 3 };
        AlienPanzerMover.speed += 0.045f;

    }

    void Start()
    {
        StartCoroutine(AlienPanzerMover.InstantinateTrack());
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        AlienPanzerMover.PanzerAction();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {
            case "bullet":
                #region Bullet
                GameParam.ScoredSMG += 5;
                    AlienPanzerMover.Position.y += (GameParam.BulletSpeed / 2) * -GameParam.ImpulsBulletX;
                    AlienPanzerMover.Position.x += (GameParam.BulletSpeed / 2) * GameParam.ImpulsBulletY;
                    //
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            AlienPanzerMover.RotateLeftGun(15);
                            break;
                        case 1:
                            AlienPanzerMover.RotateRightGun(15);
                            break;

                    }
                    if (--AlienPanzerMover.health <= 0)
                    {

                        Instantiate(AlienPanzerDestroy_obj, AlienPanz.transform.position, AlienPanzerDestroy_obj.transform.rotation);
                        #region RandomRenderBonuse
                        if (Random.Range(0, verFastBullet) == verFastBullet/2)
                        {
                            Instantiate(FastBullet, transform.position, transform.rotation);
                        }

                        if (Random.Range(0, verIceGun) == verIceGun/2)
                        {
                            Instantiate(IceGun, transform.position, transform.rotation);
                        }
                        #endregion
                        Destroy(AlienPanz);
                        GameParam.ScoredSMG += 35;

                    }
                    if (AlienPanzerMover.health == 1)
                    {
                        AlienPanzerMover.PanzerBurn();

                    }
                #endregion
                break;

            case "ezh":
                #region Ezh
                Instantiate(AlienPanzerDestroy_obj, AlienPanz.transform.position, AlienPanzerDestroy_obj.transform.rotation);
                Destroy(AlienPanz);
                #endregion
                break;
            case "Chip":
            case "panzer":
                #region Elka
                if (AlienPanzerMover.StabilityAngles(10))
                {
                    if (AlienPanzerMover.Angles.z == 90 || AlienPanzerMover.Angles.z == 270)
                    {
                        #region Random_Move_Palm
                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                AlienPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                break;
                            case 1:
                                AlienPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                                //   chechRight=true;
                                // CountRotation = 16;
                                break;
                            default:
                                AlienPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                                break;
                        }

                        #endregion
                    }
                    else
                        if (AlienPanzerMover.Angles.z == 0)
                        {
                            AlienPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Right;
                        }
                        else
                            if (AlienPanzerMover.Angles.z == 180)
                            {
                                AlienPanzerMover.Select = GameClasses.PanzerMove.SelectMove.Left;
                            }
                }
                #endregion  
                break;
        }
       
    }
    #endregion

}

