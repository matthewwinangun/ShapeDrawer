using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Deletes selected shapes if right clicked outside of gui window. Deletes all shapes if button is right clicked. Deletes all shapes that are left clicked on.
    /// </summary>
    public class DeleteTool : Command
    {

        /// <summary>
        /// Executes the delete command
        /// </summary>
        /// <param name="gui"> The GUI input for the command</param>
        public void Execute(Gui gui)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.MouseX() > 200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    if (shape.IsAt(SplashKit.MousePosition()))
                    {
                        gui.Remove_Shape(shape);
                    }
                }
            }
            if (SplashKit.MouseClicked(MouseButton.RightButton) && SplashKit.MouseX() < 200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    gui.Remove_Shape(shape);
                }
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton) && SplashKit.MouseX() >  200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    if (shape.Selected)
                    {
                        gui.Remove_Shape(shape);
                    }
                }
            }
        }
    }
}
