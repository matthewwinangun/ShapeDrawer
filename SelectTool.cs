using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class SelectTool : Command
    {
        //private int _originX;
        //private int _originY;

        public void Execute(Gui gui)
        {
            //if (SplashKit.MouseUp(MouseButton.LeftButton))
            //{
            //    _originX = (int)SplashKit.MouseX();
            //    _originY = (int)SplashKit.MouseY();
            //}

            //if (SplashKit.MouseDown(MouseButton.LeftButton))
            //{
            //    SplashKit.DrawRectangle(Color.Black, _originX, _originY, SplashKit.MouseX() - _originX, SplashKit.MouseY() - _originY);          
                               
            //    //foreach(Shape shape in gui.Shapes)
            //    //{
            //    //    if (shape.IsAt())
            //    //    {

            //    //    }
            //    //}

            //    //gui.SelectShapesAt(SplashKit.MousePosition());
            //}



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

            if (SplashKit.MouseClicked(MouseButton.RightButton) && SplashKit.MouseX() < 200)
            {
                foreach (Shape shape in gui.Shapes.ToList())
                {
                    shape.Selected = false;
                }
            }
        }
    }
}
