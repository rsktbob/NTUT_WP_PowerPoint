using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class MoveCommand : ICommand
    {
        private Shapes _shapes;
        private int _index;
        private int _startPointX;
        private int _startPointY;
        private int _endPointX;
        private int _endPointY;

        public MoveCommand(Shapes shapes, int startPointX, int startPointY, int endPointX, int endPointY)
        {
            _shapes = shapes;
            _index = shapes.SelectedShapeIndex;
            _startPointX = startPointX;
            _startPointY = startPointY;
            _endPointX = endPointX;
            _endPointY = endPointY;
        }

        // Excute move command
        public void Execute()
        {
            _shapes.MoveShape(_index, _endPointX, _endPointY);
        }

        // Unexecute move comand
        public void ReverseExecute()
        {
            _shapes.MoveShape(_index, _startPointX, _startPointY);
        }
    }
}
