using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Contains basic line information such as the draw method
    /// </summary>
    public class Line : Shape
    {
        /// <summary>
        /// Creates a line with the inputs given
        /// </summary>
        /// <param name="color"> The colour of the line</param>
        /// <param name="x"> The X coordinate of the line's origin</param>
        /// <param name="y"> The Y coordinate of the line's origin</param>
        /// <param name="xend"> The X coordinate of the line's ending</param>
        /// <param name="yend"> The Y coordinate of the line's ending</param>
        public Line(Color color, double x, double y, double xend, double yend) : base(color)
        {
            X = x;
            Y = y;
            Xend = xend;
            Yend = yend;
        }

        /// <summary>
        /// Default line that is black, origin at 0,0 and ends at 100,100
        /// </summary>
        public Line() : this(Color.Black, 0, 0, 100, 100) { }

        /// <summary>
        /// Draws line 
        /// </summary>
        public override void Draw()
        {
            if (Selected) 
            { 
                Draw_Outline(); 
            }
            SplashKit.DrawLine(SetColor, X, Y, Xend, Yend);           
        }

        /// <summary>
        /// Draws outline of the line
        /// </summary>
        public override void Draw_Outline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, Xend, Yend, 5);
        }

        /// <summary>
        /// Abstract "Is At" function which tells if the shape is at the given point
        /// </summary>
        /// <param name="input"> The input point that is being checked</param>
        /// <returns>A boolean value representing whether the shape is at the given point</returns>
        public override bool IsAt(Point2D input)
        {
            if(SplashKit.PointOnLine(input, SplashKit.LineFrom(X,Y, Xend, Yend), 10))
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Rewrites all the fields of the line
        /// </summary>
        /// <param name="color"> The colour of the line</param>
        /// <param name="x"> The X coordinate of the line's origin</param>
        /// <param name="y"> The Y coordinate of the line's origin</param>
        /// <param name="xend"> The X coordinate of the line's ending</param>
        /// <param name="yend"> The Y coordinate of the line's ending</param>
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
