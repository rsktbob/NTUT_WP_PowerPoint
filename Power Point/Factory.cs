using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class Factory
    {
        private string _shapeType;

        public Factory(string shapeType)
        {
            _shapeType = shapeType;
        }

        // Create shape
        public Shape CreateShape(int pointX1, int pointY1, int pointX2, int pointY2)
        {
            switch (_shapeType)
            {
                case Symbol.LINE:
                    return new Line(pointX1, pointY1, pointX2, pointY2);
                case Symbol.RECTANGLE:
                    return new Rectangle(pointX1, pointY1, pointX2, pointY2);
                default:
                    return new Circle(pointX1, pointY1, pointX2, pointY2);
            }
        }
    }
}
