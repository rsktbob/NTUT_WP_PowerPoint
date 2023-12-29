using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class AddCommand : ICommand
    {
        private Shapes _shapes;
        private Shape _shape;

        public AddCommand(Shapes shapes, string shapeType, int pointX1, int pointY1, int pointX2, int pointY2)
        {
            Factory factory = new Factory(shapeType);
            _shapes = shapes;
            _shape = factory.CreateShape(pointX1, pointY1, pointX2, pointY2);
        }

        // Execute add shape command
        public void Execute()
        {
            _shapes.AddShape(_shape);
        }

        // Reverse execute add shape command
        public void ReverseExecute()
        {
            _shapes.PopShape();
        }
    }
}
