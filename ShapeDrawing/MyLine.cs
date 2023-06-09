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
    public class MyLine: Shape
    {
        private float _endX, _endY;

        public MyLine( float startX, float startY, Color color)
        {
            Color = color;
            X = startX;
            Y = startY;
            EndX = 100;
            EndY = 100;
        }

        public MyLine(): this(0,0,Color.Black)
        {
            
        }

        public float EndX 
        { 
            get { return _endX; } 
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }


        public override void Draw()
        {
            SplashKit.DrawLine
                (
                    Color, X, Y, EndX, EndY
                );
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            
            if (SplashKit.PointOnLine(pt, SplashKit.LineFrom(X,Y,EndX,EndY) ))
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
                    X ,
                    Y ,
                    5 
                );
            SplashKit.DrawCircle
                (
                    Color.Black,
                    EndX,
                    EndY,
                    5
                );
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
