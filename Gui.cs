using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Gui
    {      
        public enum ShapeType
        {
            Rectangle,
            Circle,
            Line,
            None
        }

        public readonly List<Shape> Shapes = new List<Shape>();
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in Shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        private List<Button> _toolsList = new List<Button>();
        private List<Button> _palatte = new List<Button>();
        private List<Button> _shapeList = new List<Button>();

        private Button _selectedTool;
        private Color _color = Color.Blue;
        private ShapeType _selectedShape = ShapeType.Rectangle;

        public Color SelectedColor
        {
            get { return _color; }
        }
        public Button SelectedTool
        {
            get { return _selectedTool; }
        }
        public ShapeType SelectedShape
        {
            get { return _selectedShape; }
        }

        public Gui(Button tool, Button shape, Button color)
        {
            SetDefaults(tool, shape, color);
        }
        
        public void Draw()
        {   
            //Tools
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.MouseX() >= 0 && SplashKit.MouseX() <= 200 && SplashKit.MouseY() > 0 && SplashKit.MouseY() < 150)
            {
                foreach(Button button in _toolsList)
                {
                    if(button.Check())
                    {
                        button.Selected = true;
                        _selectedTool = button;
                    }
                    else
                    {
                        button.Selected = false;   
                    }
                }
            }
            //shapes
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.MouseX() >= 0 && SplashKit.MouseX() <= 200 && SplashKit.MouseY() > 200 && SplashKit.MouseY() < 300)
            {
                foreach (Button button in _shapeList)
                {
                    if (button.Check())
                    {
                        button.Selected = true;
                        _selectedShape = button.ShapeType;
                    }
                    else
                    {
                        button.Selected = false;
                    }
                }
            }
            //palatte
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && SplashKit.MouseX() >= 0 && SplashKit.MouseX() <= 200 && SplashKit.MouseY() > 350 && SplashKit.MouseY() < 450)
            {
                foreach (Button button in _palatte)
                {
                    if (button.Check())
                    {
                        button.Selected = true;
                        _color = button.SetColor;
                    }
                    else
                    {
                        button.Selected = false;
                    }
                }
            }
            
            //draw shapes
            foreach (Shape s in Shapes)
            {
                s.Draw();
            }
            //draw background
            SplashKit.FillRectangle(Color.Gray, 0, 0, 200, 600);      
            //Draw Tools
            foreach (Button button in _toolsList)
            {
                button.Draw();
            }
            //draw shape buttons
            foreach (Button button in _shapeList)
            {
                button.Draw();
            }
            //draw palatte
            foreach (Button button in _palatte)
            {
                button.Draw();
            }
        }

        public void AddButton(Button button)
        {
            if (button.Command != null)
            {
                _toolsList.Add(button);
            }
            else if (button.ShapeType != ShapeType.None)
            {
                _shapeList.Add(button);
            }
            else
            {
                _palatte.Add(button);
            }
        }
        public void Add_Shape(Shape input)
        {
            Shapes.Add(input);
        }
        public void Remove_Shape(Shape s)
        {
            Shapes.Remove(s);
        }
        public void SetDefaults(Button tool, Button shape, Button color)
        {
            _selectedTool = tool;
            tool.Selected = true;

            _color = color.SetColor;
            color.Selected = true;

            _selectedShape = shape.ShapeType;
            shape.Selected = true;
        }
        public void Execute()
        {
            SelectedTool.Command.Execute(this);                
        }
    }
}
