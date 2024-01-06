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
            get; private set;
        }

        // Rectangle state
        public bool RectangleChecked
        {
            get; private set;
        }

        // Circle state
        public bool CircleChecked
        {
            get; private set;
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

        // Get canvas size
        public Size CanvasSize
        {
            get; private set;
        }

        // Get page size
        public Size PageSize
        {
            get; private set;
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
            get; private set;
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

        // Get pageManager
        public List<Shapes> PageManager
        {
            get
            {
                return _model.PageManager;
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
