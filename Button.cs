using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Button
    {
        private bool _selected = false;
        private Command _command;
        private int _x = 0;
        private int _y = 0;
        private string _text = "";   
        private Color _color = Color.Gray;
        private Gui.ShapeType _selectedShape = new Gui.ShapeType();


        public bool Selected 
        {
            get { return _selected; } 
            set { _selected = value; }
        }
        public Color SetColor
        {
            get { return _color; }
        }
        public Gui.ShapeType ShapeType
        {
            get { return _selectedShape; }
        }

        public Command Command
        {
            get { return _command; }
        }

        public Button(Command command, Color color, Gui.ShapeType shape, int x, int y, string text)
        {
            _command = command;
            _color = color;
            _selectedShape = shape;
            _x = x;
            _y = y;
            _text = text;
        }

        public Button(Command command, int x, int y, string text) : this(command, Color.Gray, Gui.ShapeType.None, x, y, text) { }
        public Button(Color color, int x, int y, string text) : this(null, color, Gui.ShapeType.None, x, y, text) { }
        public Button(Gui.ShapeType shape, int x, int y, string text) : this(null, Color.Gray, shape, x, y, text) { }



        public bool Check()
        {
            if (SplashKit.MouseX() >= _x && SplashKit.MouseX() <= _x + 100 && SplashKit.MouseY() > _y && SplashKit.MouseY() <= _y + 50)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw()
        {

            if (Selected)
            {
                SplashKit.FillRectangle(Color.BrightGreen, _x, _y, 100, 50);
            }
            else if (Check())
            {
                SplashKit.FillRectangle(Color.Black, _x, _y, 100, 50);
            }
            else
            {
                SplashKit.FillRectangle(Color.LightGray, _x, _y, 100, 50);
            }
            SplashKit.FillRectangle(_color, _x + 2, _y + 2, 96, 46);
            SplashKit.DrawText(_text, Color.Black, "NormalFont", 5, _x + 10, _y + 20);
        }
    }
}
