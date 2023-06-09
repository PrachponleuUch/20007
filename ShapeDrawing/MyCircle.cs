using SplashKitSDK;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShapeDrawing
{
    public class MyCircle: Shape
    {
        private int _radius;

        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {

        }

        public MyCircle(Color color, float x, float y, int radius)
        {
            Color = color;
            X = x;
            Y = y;
            _radius = radius;
        }

        public int Radius
        { 
            get { return _radius; } 
            set { _radius = value; }
        }


        public override void Draw()
        {
            SplashKit.FillCircle
                (
                    Color, X, Y, _radius
                );
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            if (pt.X < X || pt.X > X + _radius || pt.Y < Y || pt.Y > Y + _radius)
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
            SplashKit.DrawCircle
                (
                    Color.Black,
                    X - 2,
                    Y - 2,
                    _radius + 4
                    
                );
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
            

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
            
        }

    }
}
