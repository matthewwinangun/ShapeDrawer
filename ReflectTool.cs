using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class ReflectTool : Command
    {
        private double _originX;
        private double _originY;
        private bool _clickdown = true;
        private Line _line = new Line();

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
                _clickdown = false;
            }

            if (SplashKit.MouseUp(MouseButton.LeftButton) && _clickdown == false)
            {
                _clickdown = true;

                foreach (Shape shape in gui.SelectedShapes)
                {
                    Shape newshape;
                    Point2D p1 = new Point2D();
                    p1.X = shape.X;
                    p1.Y = shape.Y;
                    Point2D p2 = new Point2D();
                    p2.X = shape.Xend;
                    p2.Y = shape.Yend;
                    Point2D m1 = mirror(p1, _line.X, _line.Y, _line.Xend, _line.Yend);
                    Point2D m2 = mirror(p2, _line.X, _line.Y, _line.Xend, _line.Yend);

                    if (shape is Rectangle)
                    {
                        double w = m1.X - m2.X;
                        double h = m1.Y - m2.Y;
                        m1.X -= w;
                        m1.Y -= h;
                        m2.X += w;
                        m2.Y += h;

                        newshape = new Rectangle();                      
                    }
                    else if (shape is Line)
                    {
                        newshape = new Line();
                    }
                    else if (shape is Circle)
                    {
                        newshape = new Circle();
                    }
                    else
                    {
                        newshape = new Rectangle();
                    }

                    newshape.Set(shape.SetColor, m1.X, m1.Y, m2.X, m2.Y);
                    gui.Add_Shape(newshape);
                }
            }
        }

        private Point2D mirror(Point2D p, double x0, double y0, double x1, double y1)
        {
            double dx, dy, a, b;
            double x2, y2;
            Point2D p1 = new Point2D();

            dx = (x1 - x0);
            dy = (y1 - y0);

            a = (dx * dx - dy * dy) / (dx * dx + dy * dy);
            b = 2 * dx * dy / (dx * dx + dy * dy);

            x2 = (a * (p.X - x0) + b * (p.Y - y0) + x0);
            y2 = (b * (p.X - x0) - a * (p.Y - y0) + y0);

            p1.X = x2;
            p1.Y = y2;

            return p1;
        }
    }
}
