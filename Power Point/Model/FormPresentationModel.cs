using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Power_Point
{
    public class FormPresentationModel
    {
        private Model _model;
        private double _interval;
        
        public bool LineChecked
        {
            get; private set;
        }

        public bool RectangleChecked
        {
            get; private set;
        }

        public bool CircleChecked
        {
            get; private set;
        }

        public bool GeneralChecked
        {
            get
            {
                return !(CircleChecked || LineChecked || RectangleChecked);
            }
        }

        public bool PaintState
        {
            get
            {
                return CircleChecked || LineChecked || RectangleChecked;
            }
        }

        public Size CanvasSize
        {
            get; private set;
        }

        public Size PageSize
        {
            get; private set;
        }

        public int PagesCount
        {
            get
            {
                return _model.AllPages.PageCount;
            }
        }

        public Point CanvasPosition
        {
            get; private set;
        }

        public bool RedoEnable
        {
            get
            {
                return _model.RedoEnable;
            }
        }

        public bool UndoEnable
        {
            get
            {
                return _model.UndoEnable;
            }
        }

        public bool IsScaling
        {
            get
            {
                return _model.IsScaling;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return _model.AllPages.CurrentPageIndex;
            }
        }

        public BindingList<Shape> CurrentShapeManager
        {
            get
            {
                return _model.CurrentShapeManager;
            }
        }

        public List<Shapes> PageManager
        {
            get
            {
                return _model.AllPages.PageManager;
            }
        }

        public Model.ModelChangedEventHandler ModelChanged
        {
            get
            {
                return _model.ModelChanged;
            }
            set
            {
                _model.ModelChanged = value;
            }
        }

        public FormPresentationModel(Model model)
        {
            _model = model;
        }

        // Add shape
        public void AddShape(string shape, Point point1, Point point2)
        {
            _model.PushAddCommand(shape, point1, point2);
        }

        // Delete Shape
        public void DeleteShape(int index)
        {
            _model.PushDeleteCommand(index);
        }

        // Press delete
        public void PressDelete()
        {
            _model.PressDelete();
        }

        // Cancel all state
        private void CancelAllState()
        {
            LineChecked = false;
            RectangleChecked = false;
            CircleChecked = false;
        }

        // Set shape state
        public void SetState(string action)
        {
            CancelAllState();
            switch (action)
            {
                case Symbol.LINE:
                    LineChecked = true;
                    break;
                case Symbol.RECTANGLE:
                    RectangleChecked = true;
                    break;
                case Symbol.CIRCLE:
                    CircleChecked = true;
                    break;
            }
            _model.SetState(action);
        }

        // Handele point pressed
        public void HandlePointerPressed(double pointX, double pointY)
        {
            _model.HandlePointerPressed(pointX, pointY);
        }

        // Handele point moved
        public void HandlePointerMoved(double pointX, double pointY)
        {
            _model.HandlePointerMoved(pointX, pointY);
        }

        // Handele point released
        public void HandlePointerReleased(double pointX, double pointY)
        {
            _model.HandlePointerReleased(pointX, pointY);
            CancelAllState();
        }

        // Draw canvas
        public void DrawCanvas(IGraphics graphics)
        {
            _model.DrawCanvas(graphics);
        }

        // Draw page
        public void DrawPage(int currentIndex, IGraphics graphics)
        {
            _model.DrawPage(currentIndex, graphics);
        }

        // Undo
        public void Undo()
        {
            _model.Undo();
        }

        // Redo
        public void Redo()
        {
            _model.Redo();
        }

        // Update canvas size
        public void UpdateCanvasSize(int canvasBackgroundWidth, int canvasBackgroundHeight)
        {
            if (canvasBackgroundHeight >= canvasBackgroundWidth * Symbol.CANVAS_ASPECT_RATIO)
            {
                CanvasSize = new Size(canvasBackgroundWidth - Symbol.CANVAS_LOCATION * Symbol.TWO, (int)((canvasBackgroundWidth - Symbol.CANVAS_LOCATION * Symbol.TWO) * Symbol.CANVAS_ASPECT_RATIO));
                CanvasPosition = new Point(Symbol.CANVAS_LOCATION, (canvasBackgroundHeight - CanvasSize.Height) / Symbol.TWO);
            }
            else
            {
                CanvasSize = new Size((int)((canvasBackgroundHeight - Symbol.CANVAS_LOCATION * Symbol.TWO) / Symbol.CANVAS_ASPECT_RATIO), canvasBackgroundHeight - Symbol.CANVAS_LOCATION * Symbol.TWO);
                CanvasPosition = new Point((canvasBackgroundWidth - CanvasSize.Width) / Symbol.TWO, Symbol.CANVAS_LOCATION);
            }
            _model.CanvasSize = CanvasSize;
        }

        // Update pages size
        public void UpdatePagesSize(int pageBackgroundWidth = -1)
        {
            if (pageBackgroundWidth != -1)
            {
                PageSize = new Size(pageBackgroundWidth - Symbol.PAGES_LOCATION_X * Symbol.TWO, (int)((pageBackgroundWidth - Symbol.PAGES_LOCATION_X * Symbol.TWO) * Symbol.CANVAS_ASPECT_RATIO));
                _interval = Symbol.PAGE_INTERVAL * ((double)PageSize.Width / Symbol.PAGE_WIDTH);
                _model.PageSize = PageSize;
            }
        }

        // Insert new page
        public void InsertPage()
        {
            _model.PushInsertPageCommand();
        }

        // Set current page index
        public void SetCurrentPageIndex(int index)
        {
            _model.SetCurrentPageIndex(index);
        }

        // Get pages position
        public Point GetPagePosition(int index)
        {
            return new Point(Symbol.PAGES_LOCATION_X, Symbol.PAGES_LOCATION_Y + (int)(index * _interval));
        }

        // Load file data
        public void LoadFileData(List<List<Shape>> fileData)
        {
            _model.LoadFileData(fileData);
        }
    }
}
