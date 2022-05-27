using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            DrawShape _drawshapeCommand = new DrawShape();
            SelectTool _selectCommand = new SelectTool();
            DeleteTool _deleteCommand = new DeleteTool();
            MoveTool _moveCommand = new MoveTool();
            CopyTool _copyCommand = new CopyTool();
            ReflectTool _reflectCommand = new ReflectTool();

            Button _drawTool = new Button(_drawshapeCommand, 0, 0, "draw");
            Button _selectTool = new Button(_selectCommand, 100, 0, "Select");
            Button _deleteTool = new Button(_deleteCommand, 0, 50, "delete");
            Button _moveTool = new Button(_moveCommand, 100, 50, "move");
            Button _copyTool = new Button(_copyCommand, 0, 100, "copy");
            Button _reflectTool = new Button(_reflectCommand, 100, 100, "reflect");

            Button _circle = new Button(Gui.ShapeType.Circle, 0, 200, "circle");
            Button _rectangle = new Button(Gui.ShapeType.Rectangle, 100, 200, "rectangle");
            Button _line = new Button(Gui.ShapeType.Line, 0, 250, "line");

            Button _blue = new Button(Color.Blue, 0, 350, "");
            Button _red = new Button(Color.Red, 100, 350, "");
            Button _green = new Button(Color.Green, 0, 400, "");
            Button _yellow = new Button(Color.Yellow, 100, 400, "");

            Gui gui = new Gui(_drawTool, _rectangle, _blue);

            //Adding buttons and commands
            gui.AddButton(_drawTool);
            gui.AddButton(_selectTool);
            gui.AddButton(_deleteTool);
            gui.AddButton(_moveTool);
            gui.AddButton(_copyTool);
            gui.AddButton(_reflectTool);

            gui.AddButton(_circle);
            gui.AddButton(_rectangle);
            gui.AddButton(_line);

            gui.AddButton(_blue);
            gui.AddButton(_red);
            gui.AddButton(_green);
            gui.AddButton(_yellow);

            // set defaults
            //gui.SetDefaults(_drawTool, _rectangle, _blue);



            new Window("Shape Drawer", 1200, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);
                
                gui.Execute();
                gui.Draw();

                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}
