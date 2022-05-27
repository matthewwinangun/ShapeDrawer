using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Line : Shape
    {
        public Line(Color color, double x, double y, double xend, double yend) : base(color)
        {
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
        }

        public Line() : this(Color.Black, 0, 0, 400, 300) { }

        public Line(Color c) : this(c, 0, 0, 400, 300) { }

        public override void Draw()
        {
            if (Selected) 
            { 
                Draw_Outline(); 
            }
            SplashKit.DrawLine(SetColor, X, Y, Xend, Yend);           
        }

        public override void Draw_Outline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, Xend, Yend, 5);
        }

        public override bool IsAt(Point2D input)
        {
            if(SplashKit.PointOnLine(input, SplashKit.LineFrom(X,Y, Xend, Yend), 10))
            {
                return true;
            }
            return false;
        }

        public override void Set(Color color, double x, double y, double xend, double yend)
        {
            SetColor = color;
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
        }
    }
}
