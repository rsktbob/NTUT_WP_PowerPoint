using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class ScaleCommand : ICommand
    {
        private Shapes _shapes;
        private int _index;
        private int _startPointX;
        private int _startPointY;
        private int _endPointX;
        private int _endPointY;

        public ScaleCommand(Shapes shapes, int startPointX, int startPointY, int endPointX, int endPointY)
        {
            _shapes = shapes;
            _index = shapes.SelectedShapeIndex;
            _startPointX = startPointX;
            _startPointY = startPointY;
            _endPointX = endPointX;
            _endPointY = endPointY;
        }

        // Execute scale shape command
        public void Execute()
        {
            _shapes.ScaleShape(_index, _endPointX, _endPointY);
        }

        // Reverse execute scale shape command
        public void ReverseExecute()
        {
            _shapes.ScaleShape(_index, _startPointX, _startPointY);
        }
    }
}
