using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Circle : Shape
    {
        private int _radius;

        public int Radius
        {
            get { return _radius; }  
            set { _radius = value; }           
        }

        public Circle(Color c, double x, double y, double xend, double yend) : base (c)
        {
            Point2D p1;
            p1.X = x;
            p1.Y = y;
            Point2D p2;
            p2.X = xend;
            p2.Y = yend;

            Radius = (int)SplashKit.PointPointDistance(p1, p2);
            X = y;
            Y = x;
            Xend = xend;
            Yend = yend;
        }

        public Circle(): this(Color.Blue, 0, 0, 100, 100) { }

        public override void Draw()
        {
            if (Selected)
            {
                Draw_Outline();
            }
            SplashKit.FillCircle(SetColor, X, Y, Radius); 
        }

        public override void Draw_Outline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D input)
        {
            if (SplashKit.PointInCircle(input, SplashKit.CircleAt(X, Y, _radius)))
            {
                return true;
            }
                return false;
        }

        public override void Set(Color color, double x, double y, double xend, double yend)
        {
            Point2D p1;
            p1.X = x;
            p1.Y = y;
            Point2D p2;
            p2.X = xend;
            p2.Y = yend;

            SetColor = color;
            Radius = (int)SplashKit.PointPointDistance(p1, p2);
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
        }


    }
}
