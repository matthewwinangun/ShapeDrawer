using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Draws Shapes by checking the selected shape + colour from gui, and the mouse position to create a new shape and draw
    /// </summary>
    public class DrawShape : Command
    {
        private double _originX;
        private double _originY;
        private bool _clickdown = true;
        private Rectangle _preRectangle = new Rectangle();
        private Line _preLine = new Line();
        private Circle _preCircle = new Circle();

        private Shape _preshape;

        /// <summary>
        /// Executes the Draw Shape command. 
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
                if (gui.SelectedShape == Gui.ShapeType.Rectangle)
                {
                    _preshape = _preRectangle;              
                }
                else if (gui.SelectedShape == Gui.ShapeType.Line)
                {
                    _preshape = _preLine;
                }
                else 
                {
                    _preshape = _preCircle;
                }

                _preshape.Set(gui.SelectedColor, _originX, _originY, SplashKit.MouseX(), SplashKit.MouseY());
                _preshape.Draw();
                _clickdown = false;
            }

            //adding a new shape to list
            if (SplashKit.MouseUp(MouseButton.LeftButton) && _clickdown == false)
            {
                Shape newshape;
                if (gui.SelectedShape == Gui.ShapeType.Rectangle)
                {
                    newshape = new Rectangle();
                }
                else if (gui.SelectedShape == Gui.ShapeType.Line)
                {
                    newshape = new Line();
                }
                else if (gui.SelectedShape == Gui.ShapeType.Circle)
                {
                    newshape = new Circle();
                }
                else
                {
                    newshape = new Rectangle();
                }

                newshape.Set(_preshape.SetColor, _preshape.X, _preshape.Y, _preshape.Xend, _preshape.Yend);
                gui.Add_Shape(newshape);
                _clickdown = true;
            }
        }
    }
}
