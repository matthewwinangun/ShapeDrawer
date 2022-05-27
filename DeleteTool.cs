using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class DeleteTool : Command
    {
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
