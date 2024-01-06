using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Power_Point
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        private Shape _hint;
        private Pages _pages;
        private CommandManager _commandManager;
        IState _state;

        public BindingList<Shape> CurrentShapeManager
        {
            get
            {
                return _pages.CurrentShapeManager;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return _pages.CurrentPageIndex;
            }
        }

        public int CurrentPageSelectedShapeIndex
        {
            get
            {
                return _pages.CurrentPageSelectedShapeIndex;
            }
        }

        public ModelChangedEventHandler ModelChanged
        {
            get; set;
        }

        public bool IsScaling
        {
            get
            {
                return _state is PointState && ((PointState)_state).IsScaling;
            }
        }

        // Get redo enable
        public bool RedoEnable
        {
            get
            {
                return _commandManager.RedoEnable;
            }
        }

        public bool UndoEnable
        {
            get
            {
                return _commandManager.UndoEnable;
            }
        }

        private double CanvasRatio
        {
            get
            {
                return (double)CanvasSize.Width / Symbol.CANVAS_WIDTH;
            }
        }

        private double PageRatio
        {
            get
            {
                return (double)PageSize.Width / Symbol.CANVAS_WIDTH;
            }
        }

        public Pages AllPages
        {
            get
            {
                return _pages;
            }
        }

        public Size CanvasSize
        {
            get; set;
        }

        public Size PageSize
        {
            get; set;
        }

        public Model()
        {
            _pages = new Pages();
            _state = new PointState(this, _pages.CurrentShapes);
            _commandManager = new CommandManager();
        }

        // push add shape command
        public void PushAddCommand(string shapeType, Point point1, Point point2)
        {
            ICommand command = new AddCommand(_pages.CurrentShapes, shapeType, point1.X, point1.Y, point2.X, point2.Y);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // push delete shape command
        public void PushDeleteCommand(int index)
        {
            ICommand command = new DeleteCommand(_pages.CurrentShapes, index);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push delete selected shape command
        public void PushDeleteSelectedCommand()
        {
            ICommand command = new DeleteSelectedCommand(_pages.CurrentShapes);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push draw shape command
        public void PushDrawCommand(Shape shape)
        {
            ICommand command = new DrawCommand(_pages.CurrentShapes, shape);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push move shape command
        public void PushMoveCommand(int startPointX, int startPointY, int endPointX, int endPointY)
        {
            if (startPointX == endPointX || startPointY == endPointY)
                return;
            ICommand command = new MoveCommand(_pages.CurrentShapes, startPointX, startPointY, endPointX, endPointY);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push scale shape command
        public void PushScaleCommand(int startPointX, int startPointY, int endPointX, int endPointY)
        {
            if (startPointX == endPointX && startPointY == endPointY)
                return;
            ICommand command = new ScaleCommand(_pages.CurrentShapes, startPointX, startPointY, endPointX, endPointY);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push insert page command
        public void PushInsertPageCommand()
        {
            ICommand command = new InsertPageCommand(_pages);
            _commandManager.ExecuteCommand(command);
            NotifyModelChanged();
        }

        // Push delete current page command
        public void PushDeleteCurrentPageCommand()
        {
            if (_pages.CurrentPageIndex != -1)
            {
                ICommand command = new DeletePageCommand(_pages);
                _commandManager.ExecuteCommand(command);
                NotifyModelChanged();
            }
        }

        // Draw canvas
        public void DrawCanvas(IGraphics graphics)
        {
            if (Symbol.CANVAS_WIDTH != 0)
            {
                _pages.CurrentShapes.Draw(graphics, CanvasRatio);
                if (_hint != null)
                    _hint.Draw(graphics, CanvasRatio);
            }
        }

        // Draw small canvas
        public void DrawPage(int index, IGraphics graphics)
        {
            if (Symbol.CANVAS_WIDTH != 0)
            {
                _pages.PageManager[index].Draw(graphics, PageRatio);
                if (_hint != null && index == _pages.CurrentPageIndex)
                    _hint.Draw(graphics, PageRatio);
            }
        }

        // Set paint state
        public void SetState(string action)
        {
            switch (action)
            {
                case Symbol.LINE:
                    _hint = new Line(0, 0, 0, 0);
                    break;
                case Symbol.RECTANGLE:
                    _hint = new Rectangle(0, 0, 0, 0);
                    break;
                case Symbol.CIRCLE:
                    _hint = new Circle(0, 0, 0, 0);
                    break;
                default:
                    _state = new PointState(this, _pages.CurrentShapes);
                    return;
            }
            _state = new DrawingState(this, _pages.CurrentShapes, _hint);
        }

        // Handle pointer pressed
        public void HandlePointerPressed(double pointX, double pointY)
        {
            if (pointX >= 0 && pointY >= 0)
            {
                _state.HandleMouseDown(pointX / CanvasRatio, pointY / CanvasRatio);
                NotifyModelChanged();
            }
        }

        // Handle pointer moved
        public void HandlePointerMoved(double pointX, double pointY)
        {
            _state.HandleMouseMove(pointX / CanvasRatio, pointY / CanvasRatio);
            NotifyModelChanged();
        }

        // Handle pointer released
        public void HandlePointerReleased(double pointX, double pointY)
        {
            _state.HandleMouseUp(pointX / CanvasRatio, pointY / CanvasRatio);
            _hint = null;
            _state = new PointState(this, _pages.CurrentShapes);
            NotifyModelChanged();
        }

        // Notify model changed
        private void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        // Press delete
        public void PressDelete()
        {
            if (CurrentPageSelectedShapeIndex != -1)
                PushDeleteSelectedCommand();
            else if (CurrentPageIndex != -1 && _pages.PageCount != 1)
                PushDeleteCurrentPageCommand();
        }

        // Set current page index
        public void SetCurrentPageIndex(int index)
        {
            _pages.SetCurrentPageIndex(index);
            _state = _state is PointState ? new PointState(this, _pages.CurrentShapes) : _state;
            NotifyModelChanged();
        }

        // Load file data
        public void LoadFileData(List<List<Shape>> fileData)
        {
            _commandManager.Clear();
            _pages.LoadFileData(fileData);
            NotifyModelChanged();
        }
    }
}
