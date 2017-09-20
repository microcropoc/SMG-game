    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    class MathSMG
    {
        public static double getRadius(Vector3 First, Vector3 End)
        {


            return Math.Sqrt(Math.Pow((Camera.main.WorldToScreenPoint(First).x - Camera.main.WorldToScreenPoint(End).x), 2) + Math.Pow((Camera.main.WorldToScreenPoint(First).y - Camera.main.WorldToScreenPoint(End).y), 2));
        }

        public static double getRadius(Vector2 First, Vector2 End)
        {


            return Math.Sqrt(Math.Pow((Camera.main.WorldToScreenPoint(First).x - Camera.main.WorldToScreenPoint(End).x), 2) + Math.Pow((Camera.main.WorldToScreenPoint(First).y - Camera.main.WorldToScreenPoint(End).y), 2));
        }
    }

