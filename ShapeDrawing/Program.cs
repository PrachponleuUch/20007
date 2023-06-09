using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.IO;

namespace ShapeDrawing
{
    public class Program
    {
        public enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawing", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();

                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();



                    }
                    else
                    {
                        newShape = new MyLine();


                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    drawing.AddShape(newShape);


                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("C:\\Users\\ponle\\OneDrive\\Desktop\\2023\\SEM1CS\\20007\\W5\\5.3\\ShapeDrawing\\TestDrawing.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine($"Error Loading File: {e.Message}");
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapeAt(SplashKit.MousePosition());
                    
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) ||
                    SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape selectedShape in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(selectedShape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("C:\\Users\\ponle\\OneDrive\\Desktop\\2023\\SEM1CS\\20007\\W5\\5.3\\ShapeDrawing\\TestDrawing.txt");
                }

                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
