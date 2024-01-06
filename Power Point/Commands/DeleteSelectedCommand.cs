using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DeleteSelectedCommand : ICommand
    {
        private Shapes _shapes;
        private Shape _shape;
        private int _index;

        public DeleteSelectedCommand(Shapes shapes)
        {
            _shapes = shapes;
            _index = shapes.SelectedShapeIndex;
            _shape = _shapes.ShapeManager[_index];
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
