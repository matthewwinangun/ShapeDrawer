using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;
        public int Width 
        { 
            get { return _width; } 
            set { _width = value; } 
        }
        public int Height 
        { 
            get { return _height; } 
            set { _height = value; } 
        }

        public Rectangle(Color c, double x, double y, double xend, double yend) : base(c)
        {
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
            Width = (int)(xend - x);
            Height = (int)(yend - y);
        }
        public Rectangle(): this(Color.Green, 0, 0, 100, 100) { }

        public override void Draw()
        {
            if (Selected) 
            { 
                Draw_Outline(); 
            }
            SplashKit.FillRectangle(SetColor, X, Y, Width, Height);
        }

        public override void Draw_Outline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override bool IsAt(Point2D input)
        {
            if (input.X >= X && input.X <= X + Width && input.Y > Y && input.Y <= Y + Height)
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
            Width = (int)(xend - x);
            Height = (int)(yend - y);
            
        }

    }
}
