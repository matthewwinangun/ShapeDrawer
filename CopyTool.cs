using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Copies all selected shapes and moves them to a selected position relative to their original position.
    /// </summary>
    public class CopyTool : Command
    {
        private double _originX;
        private double _originY;
        private double _x;
        private double _y;
        private bool _clickdown = true;
        private Line _line = new Line();

        /// <summary>
        /// Executes the copy command
        /// </summary>
        /// <param name="gui"> The GUI input for the command</param>
        public void Execute(Gui gui)
        {
            //setting origin
            if (SplashKit.MouseUp(MouseButton.LeftButton))
            {
                _originX = SplashKit.MouseX();
                _originY = SplashKit.MouseY();
            }

            //drawing preview
            if (SplashKit.MouseDown(MouseButton.LeftButton) && SplashKit.MouseX() > 200)
            {
                _line.Set(Color.BrightGreen, _originX, _originY, (int)SplashKit.MouseX(), (int)SplashKit.MouseY());
                _line.Draw();
                _x = SplashKit.MouseX() - _originX;
                _y = SplashKit.MouseY() - _originY;
                _clickdown = false;
            }

            if (SplashKit.MouseUp(MouseButton.LeftButton) && _clickdown == false)
            {
                _clickdown = true;

                foreach (Shape shape in gui.SelectedShapes)
                {
                    Shape newshape;

                    if (shape is Rectangle)
                    {
                        newshape = new Rectangle();
                    }
                    else if (shape is Line)
                    {
                        newshape = new Line();
                    }
                    else if (shape is Circle )
                    {
                        newshape = new Circle();
                    }
                    else
                    {
                        newshape = new Rectangle();
                    }

                    newshape.Set(shape.SetColor, shape.X + _x, shape.Y + _y, shape.Xend + _x, shape.Yend + _y);

                    gui.Add_Shape(newshape);
                }
            }


        }
    }
}
