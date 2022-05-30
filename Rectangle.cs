using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Contains basic rectangle information such as width, height and draw method
    /// </summary>
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;

        /// <summary>
        /// Creates a rectangle with the inputs given
        /// </summary>
        /// <param name="c"> The colour of the circle</param>
        /// <param name="x"> The X coordinate of the circle's origin</param>
        /// <param name="y"> The Y coordinate of the circle's origin</param>
        /// <param name="xend"> The X coordinate of the circle's ending</param>
        /// <param name="yend"> The Y coordinate of the circle's ending</param>
        public Rectangle(Color c, double x, double y, double xend, double yend) : base(c)
        {
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
            Width = (int)(xend - x);
            Height = (int)(yend - y);
        }

        /// <summary>
        /// Default rectangle that is blue, center positioned at 50,50 and a height / width of 100
        /// </summary>
        public Rectangle(): this(Color.Blue, 0, 0, 100, 100) { }

        /// <summary>
        /// Returns calculated width 
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Returns calculated height
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Draws rectangle
        /// </summary>
        public override void Draw()
        {
            if (Selected) 
            { 
                Draw_Outline(); 
            }
            SplashKit.FillRectangle(SetColor, X, Y, Width, Height);
        }

        /// <summary>
        /// Draws outline of rectangle
        /// </summary>
        public override void Draw_Outline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        /// <summary>
        /// Abstract "Is At" function which tells if the shape is at the given point
        /// </summary>
        /// <param name="input"> The input point that is being checked</param>
        /// <returns>A boolean value representing whether the shape is at the given point</returns>
        public override bool IsAt(Point2D input)
        {
            if (input.X >= X && input.X <= X + Width && input.Y > Y && input.Y <= Y + Height)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Rewrites all the fields of the circle
        /// </summary>
        /// <param name="c"> The colour of the rectangle</param>
        /// <param name="x"> The X coordinate of the rectangle's origin</param>
        /// <param name="y"> The Y coordinate of the rectangle's origin</param>
        /// <param name="xend"> The X coordinate of the rectangle's ending</param>
        /// <param name="yend"> The Y coordinate of the rectangle's ending</param>
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
