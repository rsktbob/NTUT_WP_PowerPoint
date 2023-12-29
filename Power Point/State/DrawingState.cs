using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DrawingState : IState
    {
        private Model _model;
        private bool _isPressed = false;
        private Shapes _shapes;
        private Shape _hint;

        public DrawingState(Model model, Shapes shapes, Shape hint)
        {
            _model = model;
            _shapes = shapes;
            _hint = hint;
        }

        // Mouse move
        public void HandleMouseMove(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint.PointX2 = (int)pointX;
                _hint.PointY2 = (int)pointY;
            }
        }

        // Mouse Down
        public void HandleMouseDown(double pointX, double pointY)
        {
            InitializeHintShapePosition(pointX, pointY);
            _isPressed = true;
        }

        // Mouse Release
        public void HandleMouseUp(double pointX, double pointY)
        {
            if (_isPressed)
            {
                Shape hint = new Factory(_hint.ShapeName).CreateShape(0, 0, 0, 0);
                hint.PointX1 = _hint.PointX1;
                hint.PointY1 = _hint.PointY1;
                hint.PointX2 = (int)pointX;
                hint.PointY2 = (int)pointY;
                _model.PushDrawCommand(hint);
                _hint = null;
                _isPressed = false;
            }
        }

        // Init hint shape position
        private void InitializeHintShapePosition(double pointX, double pointY)
        {
            _hint.PointX1 = (int)pointX;
            _hint.PointY1 = (int)pointY;
            _hint.PointX2 = (int)pointX;
            _hint.PointY2 = (int)pointY;
        }
    }
}
