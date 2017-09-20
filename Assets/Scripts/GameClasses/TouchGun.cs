

namespace GameClasses  {

    using UnityEngine;
    using System.Collections;
    using System;

    // Use this for initialization

    public class TouchGun : MonoBehaviour
    {
        public GameObject Gun;
        public Vector2 ScreenPosGun;
        public float RadiusMove;
        public float RadiusFire;
        public GameObject Bullet;
        public GameObject GunPrice;
        public ParticleSystem FirePartSys;

        Vector3 BulletPosition;
       

        public TouchGun(GameObject Gun, GameObject GunPrice, GameObject Bullet,ParticleSystem Fire ,Vector2 ScreenPosGun, float RadiusMove, float RadiusFire)
        {
            this.Gun = Gun;
            this.ScreenPosGun = ScreenPosGun;
            this.RadiusMove = RadiusMove;
            this.RadiusFire = RadiusFire;
            this.Bullet = Bullet;
            this.GunPrice = GunPrice;
            this.FirePartSys = Fire;
       
        }

        void Move()
        {
            #region forTouch

            Vector2 dir = ScreenPosGun - Input.touches[0].position;

            #endregion

            #region forMouse

            //Vector2 dir = ScreenPosGun - new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            #endregion
            
            dir.Normalize();

            float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//Mathf.PI;
            Gun.transform.rotation = Quaternion.AngleAxis(rot - 180, Vector3.forward);
        }

       

        public void Fire()
        {
            FirePartSys.Play();
            GameParam.StackBulletForGun.Pop(Bullet, GunPrice.transform.position, Gun.transform.rotation);
        }

        

        public bool Start()
        {
            #region forTouch

            if (Input.touchCount < 1)
            {
                // Debug.Log("TouchGun.Start Error");
                return false;
            }

            if ((Math.Sqrt(Math.Pow((Input.touches[0].position.x - ScreenPosGun.x), 2) + Math.Pow((Input.touches[0].position.y - ScreenPosGun.y), 2)) <= RadiusMove) && (Math.Sqrt(Math.Pow((Input.touches[0].position.x - ScreenPosGun.x), 2) + Math.Pow((Input.touches[0].position.y - ScreenPosGun.y), 2)) >= RadiusFire))
            {
                Move();
                // Fire();
                //   Debug.Log("TouchGun.Start Fire");
                return true;

            }
            else
                if (Math.Sqrt(Math.Pow((Input.touches[0].position.x - ScreenPosGun.x), 2) + Math.Pow((Input.touches[0].position.y - ScreenPosGun.y), 2)) <= RadiusFire)
                {
                    Move();
                    return false;
                }
            return false;


            #endregion

            #region forMouse

            //if ((Math.Sqrt(Math.Pow((Input.mousePosition.x - ScreenPosGun.x), 2) + Math.Pow((Input.mousePosition.y - ScreenPosGun.y), 2)) <= RadiusMove) && (Math.Sqrt(Math.Pow((Input.mousePosition.x - ScreenPosGun.x), 2) + Math.Pow((Input.mousePosition.y - ScreenPosGun.y), 2)) >= RadiusFire))
            //{
            //    Move();
            //    // Fire();
            //    return true;

            //}
            //else
            //    if (Math.Sqrt(Math.Pow((Input.mousePosition.x - ScreenPosGun.x), 2) + Math.Pow((Input.mousePosition.y - ScreenPosGun.y), 2)) <= RadiusFire)
            //    {
            //        Move();
            //        return false;
            //    }
            //return false;

            #endregion
        }

    }

   
}
