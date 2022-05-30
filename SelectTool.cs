using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Selects and deselects shapes that are left clicked on. Selects all shapes when button is right clicked. Deselect all shapes when right clicked outside of gui window.
    /// </summary>
    public class SelectTool : Command
    {
        /// <summary>
        /// Executes the Select command. 
        /// </summary>
        /// <param name="gui"> The GUI input for the command</param>
        public void Execute(Gui gui)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.MouseX() > 200)
            {
                foreach (Shape s in gui.Shapes)
                {
                    if (s.IsAt(SplashKit.MousePosition()))
                    {
                        s.Selected = !s.Selected;
                    }
                }
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton) && SplashKit.MouseX() > 200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    shape.Selected = false;
                }
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton) && SplashKit.MouseX() < 200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    shape.Selected = true;
                }
            }
        }
    }
}
