using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawing
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;

        }

        public Drawing() : this(Color.White)
        {
            
            
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public Color Background
        {
            get 
            { 
                return _background; 
            }
            set 
            { 
                _background = value; 
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                    s.Selected = true;
                else
                {
                    s.Selected = false;
                }
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }

        public void RemoveShape(Shape s)
        {

            _shapes.Remove(s);
        }

        public void Save(string filename)
        {
            StreamWriter writer;
            

            writer = new StreamWriter(filename);
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            foreach(Shape s in _shapes)
            {
                s.SaveTo(writer);
            }

            writer.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();
            Shape s;
            String kind;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }


                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally 
            { 
                reader.Close(); 
            }
            
        }
        
    }
}
