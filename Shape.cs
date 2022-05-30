using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Shape class that contains all basic information shapes have, including origin / ending coords, whether selected, colour and draw methods
    /// </summary>
    public abstract class Shape
    {
        private Color _color;
        private double _x;
        private double _y;
        private double _xend;
        private double _yend;
        private bool _selected = false;

        public Shape() : this(Color.Yellow)
        {

        }

        public Shape(Color c)
        {
            _color = c;
            _x = 0;
            _y = 0;
        }

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
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>
        /// Draws the shape, specific method is pushed onto the child shape
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Draws the shape outline, specific method is pushed onto the child shape
        /// </summary>
        public abstract void Draw_Outline();
       
        /// <summary>
        /// Rewrites the shape's fields based on the inputs
        /// </summary>
        public abstract void Set(Color color, double x, double y, double xend, double yend);
        
        /// <summary>
        /// Abstract "Is At" function which tells if the shape is at the given point
        /// </summary>
        /// <param name="input"> The input point that is being checked</param>
        /// <returns>A boolean value representing whether the shape is at the given point</returns>
        public abstract bool IsAt(Point2D input);
    }
}
