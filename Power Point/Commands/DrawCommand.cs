using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DrawCommand : ICommand
    {
        private Shapes _shapes;
        private Shape _shape;

        public DrawCommand(Shapes shapes, Shape shape)
        {
            _shapes = shapes;
            _shape = shape;
        }

        // Excute draw command
        public void Execute()
        {
            _shapes.AddShape(_shape);
        }

        // Unexecute draw command
        public void ReverseExecute()
        {
            _shapes.PopShape();
        }
    }
}
