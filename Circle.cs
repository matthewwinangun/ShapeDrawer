using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Contains basic circle information such as the draw method and radius
    /// </summary>
    public class Circle : Shape
    {
        private int _radius;

        /// <summary>
        /// Creates a circle with the inputs given
        /// </summary>
        /// <param name="c"> The colour of the circle</param>
        /// <param name="x"> The X coordinate of the circle's origin</param>
        /// <param name="y"> The Y coordinate of the circle's origin</param>
        /// <param name="xend"> The X coordinate of the circle's ending</param>
        /// <param name="yend"> The Y coordinate of the circle's ending</param>
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

        /// <summary>
        /// Default circle that is blue, radius of 50 and center positioned at 50,50
        /// </summary>
        public Circle(): this(Color.Blue, 0, 0, 100, 100) { }

        /// <summary>
        /// returns the calculated radius
        /// </summary>
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// Draws circle
        /// </summary>
        public override void Draw()
        {
            if (Selected)
            {
                Draw_Outline();
            }
            SplashKit.FillCircle(SetColor, X, Y, Radius); 
        }

        /// <summary>
        /// Draws outline of the circle
        /// </summary>
        public override void Draw_Outline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        /// <summary>
        /// Abstract "Is At" function which tells if the shape is at the given point
        /// </summary>
        /// <param name="input"> The input point that is being checked</param>
        /// <returns>A boolean value representing whether the shape is at the given point</returns>
        public override bool IsAt(Point2D input)
        {
            if (SplashKit.PointInCircle(input, SplashKit.CircleAt(X, Y, _radius)))
            {
                return true;
            }
                return false;
        }
        
        /// <summary>
        /// Rewrites all the fields of the circle
        /// </summary>
        /// <param name="c"> The colour of the circle</param>
        /// <param name="x"> The X coordinate of the circle's origin</param>
        /// <param name="y"> The Y coordinate of the circle's origin</param>
        /// <param name="xend"> The X coordinate of the circle's ending</param>
        /// <param name="yend"> The Y coordinate of the circle's ending</param>
        public override void Set(Color c, double x, double y, double xend, double yend)
        {
            Point2D p1;
            p1.X = x;
            p1.Y = y;
            Point2D p2;
            p2.X = xend;
            p2.Y = yend;

            SetColor = c;
            Radius = (int)SplashKit.PointPointDistance(p1, p2);
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
        }
    }
}
