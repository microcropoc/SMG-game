namespace GameClasses  {

    using UnityEngine;
    using System.Collections;
    using System;

    public class PanzerMove : MonoBehaviour
    {
        #region VARIABLE
        #region ObjPanzerGun
        private GameObject Panzer;
        private GameObject PanzerCenter;
        private GameObject PanzerLook;
        private GameObject Gun;
        private GameObject GunPrice;
        private ParticleSystem PartSys;
        #endregion
        #region panzerTrack
        private GameObject PanzerTrack;
        private GameObject PointPanzerTrack;
        int InstTrackCounter = 3;
        #endregion

        #region Properties_Panzer
        public Vector3 Position;
        public Vector3 Angles;
        private float NormalX, NormalY;
        public int health = 3;
        public float speed = 0.1f;
        public int rotationCounter = 0;
        public float PointEnd;
        #endregion

        #region Control_Rotation
        public enum SelectMove { Move, Right, Left, Around };
        public SelectMove Select;
        public int CountRotation = 8;
        public int CountMoveDown = 28;
        public int constCountRotation = 8;
        //  bool chechRight = false;
        public int constCountMoveDown = 28;

        #endregion

        #region Properties_Gun

        public Vector3 AnglesGun;

        #endregion



        #endregion




        #region CONSTRUCTION


        public PanzerMove(GameObject Panzer, GameObject PanzerCenter, GameObject PanzerLook, GameObject PanzerTrack, GameObject PointPanzerTrack, float PointEnd, GameObject Gun, GameObject GunPrice, ParticleSystem PartSys)
        {
            this.Position = Panzer.transform.position;
            this.Angles = Panzer.transform.eulerAngles;
            this.Panzer = Panzer;
            this.PanzerCenter = PanzerCenter;
            this.PanzerLook = PanzerLook;
            this.PanzerTrack = PanzerTrack;
            this.PointPanzerTrack = PointPanzerTrack;
            this.PointEnd = PointEnd;
            this.Gun = Gun;
            this.GunPrice = GunPrice;
            this.AnglesGun = Gun.transform.eulerAngles;
            this.PartSys = PartSys;
            Find_NormaliXY();
            //StartCorotine();

        }

        #endregion
        #region METHOD
        #region Find_NormalMethod
        public void Find_NormaliXY()
        {
            #region Find_Normal
            Vector3 NormalXY = -Camera.main.WorldToScreenPoint(PanzerCenter.transform.position) + Camera.main.WorldToScreenPoint(PanzerLook.transform.position);
            NormalXY.Normalize();
            NormalX = NormalXY.x;
            NormalY = NormalXY.y;
            // Debug.Log("Nor X=" + NorX + " Y=" + NorY);
            #endregion
        }
        #endregion
        #region MoveMethod


        public IEnumerator InstantinateTrack()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.06f);

                //InstantinatePanzerTrack();
                GameParam.StackPanzerTrackForTanks.Pop(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
                //  Instantiate(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
            }
        }

        public bool Move(int CountMove = 0)
        {  //Default Move (Angles.z=90)
            Position.y -= speed * NormalX;
            Position.x += speed * NormalY;
            Panzer.transform.position = Position;
            //  Instantiate(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
            if (CountMove <= 0)
            {
                return true;
            }
            return false;
            //-----------------------------------
        }
        #endregion
        #region RotationPanzerMethod
        public bool DefaultRotation(int AngleIncDec)
        {
            if (Angles.z > 90)
            {
                if (Mathf.Abs(Angles.z - 90) < AngleIncDec)
                {
                    Angles.z = 90;
                    return true;
                }
                else
                {
                    RotateLeft(AngleIncDec);
                    if (Angles.z == 90)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (Mathf.Abs(Angles.z - 90) < AngleIncDec)
                {
                    Angles.z = 90;
                    return true;
                }
                else
                {
                    RotateRight(AngleIncDec);
                    if (Angles.z == 90)
                        return true;
                    else
                        return false;
                }
            }

        }

        

        public bool RotateRight(int AngleInc, int CountRotation = 0)
        {//Rotate (Angles.z+=10)
            Angles.z += AngleInc;
            Panzer.transform.eulerAngles = Angles;
            GameParam.StackPanzerTrackForTanks.Pop(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
          //  Instantiate(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);

            if (CountRotation <= 0)
            {
                Find_NormaliXY();
                return true;
            }
            else
                return false;
            //-------------------------------  
        }
        public bool RotateLeft(int AngleDec, int CountRotation = 0)
        {//Rotate (Angles.z-=10)
            Angles.z -= AngleDec;
            Panzer.transform.eulerAngles = Angles;
            GameParam.StackPanzerTrackForTanks.Pop(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
           // Instantiate(PanzerTrack, PointPanzerTrack.transform.position, PointPanzerTrack.transform.rotation);
         
            if (CountRotation <= 0)
            {
                Find_NormaliXY();
                return true;
            }
            else
                return false;
            //-------------------------------  
        }
        public bool StabilityAngles(int AngleIncDec)
        {
            if (Angles.z != 90 && Angles.z != 180 && Angles.z != 0 && Angles.z != 360)
            {
                #region 180
                if (Angles.z <= 225 && Angles.z > 135)
                {
                    if (Angles.z > 180)
                    {
                        if (Mathf.Abs(Angles.z - 180) < AngleIncDec)
                        {
                            Angles.z = 180;
                            return true;
                        }
                        else
                        {
                            RotateLeft(AngleIncDec);
                            if (Angles.z == 180)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Mathf.Abs(Angles.z - 180) < AngleIncDec)
                        {
                            Angles.z = 180;
                            return true;
                        }
                        else
                        {
                            RotateRight(AngleIncDec);
                            if (Angles.z == 180)
                                return true;
                            else
                                return false;
                        }
                    }

                }
                #endregion
                #region 90
                if (Angles.z <= 135 && Angles.z >= 45)
                {
                    if (Angles.z > 90)
                    {
                        if (Mathf.Abs(Angles.z - 90) < AngleIncDec)
                        {
                            Angles.z = 90;
                            return true;
                        }
                        else
                        {
                            RotateLeft(AngleIncDec);
                            if (Angles.z == 90)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Mathf.Abs(Angles.z - 90) < AngleIncDec)
                        {
                            Angles.z = 90;
                            return true;
                        }
                        else
                        {
                            RotateRight(AngleIncDec);
                            if (Angles.z == 90)
                                return true;
                            else
                                return false;
                        }
                    }

                }
                #endregion
                #region 0/360
                if (Angles.z < 45 || Angles.z >= 315)
                {
                    if (Angles.z > 0 && Angles.z < 315)
                    {
                        if (Angles.z < AngleIncDec)
                        {
                            Angles.z = 0;
                            return true;
                        }
                        else
                        {
                            RotateLeft(AngleIncDec);
                            if (Angles.z == 90)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Mathf.Abs(Angles.z - 360) < AngleIncDec)
                        {
                            Angles.z = 0;
                            return true;
                        }
                        else
                        {
                            RotateRight(AngleIncDec);
                            if (Angles.z == 0)
                                return true;
                            else
                                return false;
                        }
                    }

                }
                #endregion
                #region 270
                if (Angles.z < 315 && Angles.z > 225)
                {
                    if (Angles.z > 270)
                    {
                        if (Mathf.Abs(Angles.z - 270) < AngleIncDec)
                        {
                            Angles.z = 270;
                            return true;
                        }
                        else
                        {
                            RotateLeft(AngleIncDec);
                            if (Angles.z == 270)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Mathf.Abs(Angles.z - 270) < AngleIncDec)
                        {
                            Angles.z = 270;
                            return true;
                        }
                        else
                        {
                            RotateRight(AngleIncDec);
                            if (Angles.z == 270)
                                return true;
                            else
                                return false;
                        }
                    }

                }
                #endregion

            }
            return true;
        }
        #endregion
        #region RotationGunMethod

        public bool RotateRightGun(int AngleInc, int CountRotation = 0)
        {//Rotate (Angles.z+=10)
            AnglesGun.z += AngleInc;
            Gun.transform.eulerAngles = AnglesGun;
            if (CountRotation <= 0)
            {
                return true;
            }
            else
                return false;
            //-------------------------------  
        }
        public bool RotateLeftGun(int AngleDec, int CountRotation = 0)
        {//Rotate (Angles.z-=10)
            AnglesGun.z -= AngleDec;
            Gun.transform.eulerAngles = AnglesGun;
            if (CountRotation <= 0)
            {
                return true;
            }
            else
                return false;
            //-------------------------------   
        }
        public bool StabilityTargetAngleGun(int AngleIncDec)
        {
            if (AnglesGun.z != 0 || AnglesGun.z != 360)
            {
                Debug.Log("Stability Gun Angle "+AnglesGun.z);
                #region 0/360
                if (AnglesGun.z < 45 || AnglesGun.z >= 315)
                {
                    if (AnglesGun.z > 0 && AnglesGun.z < 315)
                    {
                        if (AnglesGun.z < AngleIncDec)
                        {
                            AnglesGun.z = 0;
                            return true;
                        }
                        else
                        {
                            RotateLeftGun(AngleIncDec);
                            if (AnglesGun.z == 90)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Mathf.Abs(Angles.z - 360) < AngleIncDec)
                        {
                            AnglesGun.z = 0;
                            return true;
                        }
                        else
                        {
                            RotateRightGun(AngleIncDec);
                            if (AnglesGun.z == 0)
                                return true;
                            else
                                return false;
                        }
                    }

                }
                #endregion
            }
            return true;
        }
        #endregion


        #region RunPanzer
        public void PanzerAction()
        {
            #region SelectActionPanzer
            switch (Select)
            {
                case SelectMove.Move:
                    #region Move
                    if (StabilityAngles(10))
                    {

                        #region MovePazer90
                        if (Angles.z == 90)
                        {


                            Move();
                            #region PointEnd
                            if (Position.y <= PointEnd)
                            {
                                // 
                                GameParam.LifeSMG -= 1;
                                Destroy(Panzer);
                            }
                            #endregion
                        }
                        else
                        #endregion
                            #region MovePanzer180
                            if (Angles.z == 180)
                            {
                                if (Move(CountMoveDown))
                                {
                                    CountMoveDown = constCountMoveDown;
                                    Select = SelectMove.Left;
                                }
                                else
                                {
                                    CountMoveDown--;
                                }
                            }

                            else
                            #endregion
                                #region MovePanzer0
                                if (Angles.z == 0)
                                {

                                    if (Move(CountMoveDown))
                                    {
                                        CountMoveDown = constCountMoveDown;
                                        Select = SelectMove.Right;
                                    }
                                    else
                                    {
                                        CountMoveDown--;
                                    }
                                }
                                else
                                #endregion
                                    #region MovePanzer270
                                    if (Angles.z == 0)
                                    {
                                        if (Move(CountMoveDown))
                                        {
                                            CountMoveDown = constCountMoveDown;
                                            Select = SelectMove.Left;
                                            CountRotation = 16;
                                        }
                                        else
                                        {
                                            CountMoveDown--;
                                        }
                                    }

                                    #endregion
                    }
                    #endregion
                    break;
                case SelectMove.Right:
                    #region RightRotation
                    if (RotateRight(10, CountRotation))
                    {
                        CountRotation = constCountRotation;
                        Select = 0;
                    }
                    else
                    {
                        CountRotation--;
                    }
                    #endregion
                    break;
                case SelectMove.Left:
                    #region LeftRotation
                    if (RotateLeft(10, CountRotation))
                    {
                        CountRotation = constCountRotation;
                        Select = 0;
                    }
                    else
                    {
                        CountRotation--;
                    }
                    #endregion
                    break;
                case SelectMove.Around:


                    break;
            }
            #endregion
        }

        #endregion
        public void PanzerBurn()
        {
            PartSys.Play();
        }
        #endregion
    }

} // Use this for initialization