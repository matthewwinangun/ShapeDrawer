using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    /// <summary>
    /// Links the Buttons with the commands and draws based on the button inputs
    /// </summary>
    public class Gui
    {      
        /// <summary>
        /// An Enumeration of all of the shape types
        /// </summary>
        public enum ShapeType
        {
            Rectangle,
            Circle,
            Line,
            None
        }

        /// <summary>
        /// A list containing all shapes to be drawn
        /// </summary>
        public readonly List<Shape> Shapes = new List<Shape>();

        /// <summary>
        /// A list containing all of the selected shapes
        /// </summary>
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

        /// <summary>
        /// A list of all of the tools in the GUI
        /// </summary>
        private List<Button> _toolsList = new List<Button>();

        /// <summary>
        /// A list of all of the colours in the GUI
        /// </summary>
        private List<Button> _palatte = new List<Button>();

        /// <summary>
        /// A list of all of the shapes in the GUI
        /// </summary>
        private List<Button> _shapeList = new List<Button>();

        private Button _selectedTool;
        private Color _color;
        private ShapeType _selectedShape;

        /// <summary>
        /// Creates a GUI with the defaults set by the given inputs
        /// </summary>
        /// <param name="tool">Default tool</param>
        /// <param name="shape">Default shape</param>
        /// <param name="color">Default colour</param>
        public Gui(Button tool, Button shape, Button color)
        {
            SetDefaults(tool, shape, color);
        }

        /// <summary>
        /// Returns the selected colour
        /// </summary>
        public Color SelectedColor
        {
            get { return _color; }
        }

        /// <summary>
        /// Returns the selected tool
        /// </summary>
        public Button SelectedTool
        {
            get { return _selectedTool; }
        }

        /// <summary>
        /// Returns the selected shape
        /// </summary>
        public ShapeType SelectedShape
        {
            get { return _selectedShape; }
        }

        /// <summary>
        /// Draws the GUI and shapes
        /// </summary>
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

        /// <summary>
        /// Adds a button to the GUI
        /// </summary>
        /// <param name="button">The button to be added to the GUI</param>
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

        /// <summary>
        /// Adds an input shape from the main "Shapes" list
        /// </summary>
        /// <param name="s">The input shape to be added</param>
        public void Add_Shape(Shape input)
        {
            Shapes.Add(input);
        }

        /// <summary>
        /// Removes an input shape from the main "Shapes" list
        /// </summary>
        /// <param name="s">The input shape to be removed</param>
        public void Remove_Shape(Shape s)
        {
            Shapes.Remove(s);
        }

        /// <summary>
        /// Sets the default tool, shape and color
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="shape"></param>
        /// <param name="color"></param>
        public void SetDefaults(Button tool, Button shape, Button color)
        {
            _selectedTool = tool;
            tool.Selected = true;

            _color = color.SetColor;
            color.Selected = true;

            _selectedShape = shape.ShapeType;
            shape.Selected = true;
        }
        
        /// <summary>
        /// Executes the selected commands
        /// </summary>
        public void Execute()
        {
            SelectedTool.Command.Execute(this);                
        }
    }
}
