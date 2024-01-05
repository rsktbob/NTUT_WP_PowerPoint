using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Power_Point
{
    public class ShapeEventArguments : EventArgs
    {
        public Point Point1 
        { 
            get; 
        }
        public Point Point2 
        { 
            get; 
        }
        public string ShapeType 
        { 
            get; 
        }

        public ShapeEventArguments(string shapeType, Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
            ShapeType = shapeType;
        }
    }

}
