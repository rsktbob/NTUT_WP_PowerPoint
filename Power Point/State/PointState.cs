using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class PointState : IState
    {
        private Model _model;
        private Shapes _shapes;
        private bool _isPressed = false;
        private bool _isScaling = false;
        private int _recordPointX;
        private int _recordPointY;
        private int _recordShapePointX1;
        private int _recordShapePointY1;
        private int _recordShapePointX2;
        private int _recordShapePointY2;

        public PointState(Model model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        // Mouse move
        public void HandleMouseMove(double pointX, double pointY)
        {
            if (_isPressed)
            {
                MoveMouse(pointX, pointY);
            }
            else
            {
                _isScaling = _shapes.CheckPointEnterSelectedShapeCorner(pointX, pointY);
            }
        }

        // Mouse Down
        public void HandleMouseDown(double pointX, double pointY)
        {
            if (_isScaling)
            {
                RecordSelectedShapePosition(pointX, pointY);
                _isPressed = true;
            }
            else
            {
                CheckPointPressInShapes(pointX, pointY);
            }
        }

        // Mouse Up
        public void HandleMouseUp(double pointX, double pointY)
        {
            HandleMouseMove(pointX, pointY);
            if (_isPressed)
            {
                Shape shape = _shapes.ShapeManager[SelectedIndex];
                if (_isScaling)
                {
                    _model.PushScaleCommand(_recordShapePointX2, _recordShapePointY2, shape.PointX2, shape.PointY2);
                }
                else
                {
                    _model.PushMoveCommand(_recordShapePointX1, _recordShapePointY1, shape.PointX1, shape.PointY1);
                }
            }
            _isPressed = false;
        }

        // Record shape
        private void RecordSelectedShapePosition(double pointX, double pointY)
        {
            _recordPointX = (int)pointX;
            _recordPointY = (int)pointY;
            _recordShapePointX1 = _shapes.ShapeManager[SelectedIndex].PointX1;
            _recordShapePointY1 = _shapes.ShapeManager[SelectedIndex].PointY1;
            _recordShapePointX2 = _shapes.ShapeManager[SelectedIndex].PointX2;
            _recordShapePointY2 = _shapes.ShapeManager[SelectedIndex].PointY2;
            
        }

        // Mouse judge how to move
        private void MoveMouse(double pointX, double pointY)
        {
            if (_isScaling)
            {
                _shapes.ShapeManager[SelectedIndex].Scale((int)pointX, (int)pointY);
            }
            else
            {
                int width = (int)(pointX - _recordPointX);
                int height = (int)(pointY - _recordPointY);
                _shapes.ShapeManager[SelectedIndex].PointX1 = _recordShapePointX1 + width;
                _shapes.ShapeManager[SelectedIndex].PointY1 = _recordShapePointY1 + height;

                _shapes.ShapeManager[SelectedIndex].PointX2 = _recordShapePointX2 + width;
                _shapes.ShapeManager[SelectedIndex].PointY2 = _recordShapePointY2 + height;
            }
        }

        // Check point press in Shapes
        private void CheckPointPressInShapes(double pointX, double pointY)
        {
            _shapes.CheckPointPressInShapes(pointX, pointY);
            if (SelectedIndex != -1)
            {
                _recordPointX = (int)pointX;
                _recordPointY = (int)pointY;
                _isPressed = true;
                RecordSelectedShapePosition(pointX, pointY);
            }
        }

        // Get isScaling
        public bool IsScaling
        {
            get
            {
                return _isScaling;
            }
        }

        // Get selected index
        public int SelectedIndex
        {
            get
            {
                return _shapes.SelectedShapeIndex;
            }
        }
    }
}
