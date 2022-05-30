using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    ///  Moves all selected shapes to a selected position relative to their original position.
    /// </summary>
    public class MoveTool : Command
    {
        private double _originX;
        private double _originY;
        private double _x;
        private double _y;
        private bool _clickdown = true;
        private Line _line = new Line();
        
        /// <summary>
        /// Executes the move Shape command. 
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
                    shape.X += _x;
                    shape.Y += _y;
                    shape.Xend += _x;
                    shape.Yend += _y;
                }               
            }
        }
    }
}
