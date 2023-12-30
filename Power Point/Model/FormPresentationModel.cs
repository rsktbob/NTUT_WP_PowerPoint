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
        
        // Line state
        public bool LineChecked
        {
            get;
            private set;
        }

        // Rectangle state
        public bool RectangleChecked
        {
            get;
            private set;
        }

        // Circle state
        public bool CircleChecked
        {
            get;
            private set;
        }

        // Get general checked
        public bool GeneralChecked
        {
            get
            {
                return !(CircleChecked || LineChecked || RectangleChecked);
            }
        }

        // Get paint state
        public bool PaintState
        {
            get
            {
                return CircleChecked || LineChecked || RectangleChecked;
            }
        }

        // Get canvas width
        public int CanvasWidth
        {
            get
            {
                return _model.CanvasSize.Width;
            }
        }

        // Get canvas height
        public int CanvasHeight
        {
            get
            {
                return _model.CanvasSize.Height;
            }
        }

        // Get page width
        public int PageWidth
        {
            get
            {
                return _model.PageSize.Width;
            }
        }

        // Get page height
        public int PageHeight
        {
            get
            {
                return _model.PageSize.Height;
            }
        }

        // Get page count
        public int PagesCount
        {
            get
            {
                return _model.PageManager.Count;
            }
        }

        // Canvas positon
        public Point CanvasPosition
        {
            get;
            private set;
        }

        // Get redo enale
        public bool RedoEnable
        {
            get
            {
                return _model.RedoEnable;
            }
        }

        // Get undo enable
        public bool UndoEnable
        {
            get
            {
                return _model.UndoEnable;
            }
        }

        // Get isscaling state
        public bool IsScaling
        {
            get
            {
                return _model.IsScaling;
            }
        }

        // Get current page index
        public int CurrentPageIndex
        {
            get
            {
                return _model.CurrentPages.CurrentPageIndex;
            }
        }

        // Get current shapeManager
        public BindingList<Shape> CurrentShapeManager
        {
            get
            {
                return _model.CurrentShapeManager;
            }
        }

        // Get ModelChangee
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

        // Set canvas size
        public void SetCanvasSize(int width, int height)
        {
            _model.CanvasSize = new Size(width, height);
        }

        // Set small canvas size
        public void SetPageSize(int width, int height)
        {
            _model.PageSize = new Size(width, height);
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
            UpdatePagesSize();
        }

        // Redo
        public void Redo()
        {
            _model.Redo();
            UpdatePagesSize();
        }

        // Update canvas size
        public void UpdateCanvasSize(int canvasBackgroundWidth, int canvasBackgroundHeight)
        {
            int width = canvasBackgroundWidth - Symbol.CANVAS_LOCATION_X * Symbol.TWO;
            int height = (int)(width * Symbol.CANVAS_ASPECT_RATIO);
            SetCanvasSize(width, height);
            CanvasPosition = new Point(Symbol.CANVAS_LOCATION_X, (canvasBackgroundHeight - CanvasHeight) / Symbol.TWO);
        }

        // Update pages size
        public void UpdatePagesSize(int pageBackgroundWidth = -1)
        {
            if (pageBackgroundWidth != -1)
            {
                int width = pageBackgroundWidth - Symbol.PAGES_LOCATION_X * Symbol.TWO;
                int height = (int)(width * Symbol.CANVAS_ASPECT_RATIO);
                SetPageSize(width, height);
                _interval = Symbol.PAGE_INTERVAL * ((double)PageWidth / Symbol.PAGE_WIDTH);
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
    }
}
