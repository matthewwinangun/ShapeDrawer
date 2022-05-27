using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private double _x;
        private double _y;
        private double _xend;
        private double _yend;
        private bool _selected = false;

        public Color SetColor 
        { 
            get { return _color; } 
            set { _color = value; } 
        }
        public double X 
        { 
            get { return _x; } 
            set { _x = value; } 
        }
        public double Y 
        { 
            get { return _y; } 
            set { _y = value; } 
        }
        public double Xend
        {
            get { return _xend; }
            set { _xend = value; }
        }
        public double Yend
        {
            get { return _yend; }
            set { _yend = value; }
        }
        public bool Selected 
        { get { return _selected; } 
            set { _selected = value; } 
        }

        public Shape() : this(Color.Yellow)
        {

        }

        public Shape(Color c)
        {
            _color = c;
            _x = 0;
            _y = 0;
        }

        public abstract void Draw();
        public abstract void Draw_Outline();
        public abstract void Set(Color color, double x, double y, double xend, double yend);
        public abstract bool IsAt(Point2D input);
    }
}
