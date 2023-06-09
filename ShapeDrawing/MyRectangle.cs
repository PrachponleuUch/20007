using SplashKitSDK;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawing
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {

        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public override void Draw()
        {
            SplashKit.FillRectangle
                (
                    Color, X, Y, Width, Height
                );
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            if (pt.X < X || pt.X > X + Width || pt.Y < Y || pt.Y > Y + Height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle
                (
                    Color.Black,
                    X - 2,
                    Y - 2,
                    Width + 4,
                    Height + 4
                );
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }

        
    

    }
}
