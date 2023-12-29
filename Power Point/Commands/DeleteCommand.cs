using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DeleteCommand : ICommand
    {
        private Shapes _shapes;
        private Shape _shape;
        private int _index;

        public DeleteCommand(Shapes shapes, int index)
        {
            _shapes = shapes;
            _index = index;
            _shape = _shapes.ShapeManager[index];
        }

        // Execute delete shape command
        public void Execute()
        {
            _shapes.DeleteShape(_index);
        }

        // Unexecute delete shape command
        public void ReverseExecute()
        {
            _shapes.InsertShape(_index, _shape);
        }
    }
}
