using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_Point
{
    public partial class Form : System.Windows.Forms.Form
    {
        private FormPresentationModel _presentationModel;
        private List<Button> _pages;

        public Form(FormPresentationModel presentationModel)
        {
            InitializeComponent();
        
            // set canvas size;
            _presentationModel = presentationModel;

            // set delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = Symbol.DELETE;
            deleteButtonColumn.Text = Symbol.DELETE;
            deleteButtonColumn.Width = Symbol.DATA_COLUMNS_DELETE_WIDTH;
            deleteButtonColumn.UseColumnTextForButtonValue = true;

            // shapelist setting
            _shapeDataGridView.Columns.Insert(0, deleteButtonColumn);
            _shapeDataGridView.DataSource = _presentationModel.CurrentShapeManager;
            _shapeDataGridView.Columns[Symbol.ONE].HeaderText = Symbol.SHAPE;
            _shapeDataGridView.Columns[Symbol.ONE].Width = Symbol.DATA_COLUMNS_SHAPE_WIDTH;
            _shapeDataGridView.Columns[Symbol.TWO].HeaderText = Symbol.INFO;
            _shapeDataGridView.Columns[Symbol.TWO].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Initialize pages
            _pages = new List<Button>();
            _pages.Add(_page1);
            _page1 = null;

            // Add canvas and pages update event
            _presentationModel.ModelChanged += UpdateAllPagesAndCanvasPaint;

            // Add press delete key event
            KeyDown += PressDelete;
        }

        // Load form
        private void LoadForm(object sender, EventArgs e)
        {
            // Initialize canvas size and pages size
            UpdateCanvasSize(sender, e);
            UpdatePagesSize(sender, e);

            // Initialize state
            UpdatePanel();
            _pages[0].PerformClick();
        }

        // Press delete
        private void PressDelete(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _presentationModel.PressDelete();
                UpdatePageSelected();
                UpdatePanel();
            }
        }

        // Add shape
        public void ClickAddShapeButton(object sender, EventArgs e)
        {
            string shapeType = _shapeComboBox.Text;
            AddShapeForm addShapeForm = new AddShapeForm(shapeType);
            addShapeForm._clickOkButtonEvent += ClickAddShapeFormOkButton;
            addShapeForm.Show();
            UpdatePanel();
        }

        // Delete shape
        private void ClickDeleteShapeButton(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                _presentationModel.DeleteShape(e.RowIndex);
                UpdatePanel();
            }
        }

        // Click line button
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.SetState(Symbol.LINE);
            UpdatePanel();
        }

        // Click rectangle button
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.SetState(Symbol.RECTANGLE);
            UpdatePanel();
        }

        // Click circle button
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.SetState(Symbol.CIRCLE);
            UpdatePanel();
        }

        // Click general button
        private void ClickGeneralButton(object sender, EventArgs e)
        {
            _presentationModel.SetState(Symbol.GENERAL);
            UpdatePanel();
        }

        // Update shape button state
        private void UpdatePanel()
        {
            _lineButton.Checked = _presentationModel.LineChecked;
            _rectangleButton.Checked = _presentationModel.RectangleChecked;
            _circleButton.Checked = _presentationModel.CircleChecked;
            _generalButton.Checked = _presentationModel.GeneralChecked;
            _undoButton.Enabled = _presentationModel.UndoEnable;
            _redoButton.Enabled = _presentationModel.RedoEnable;
            Cursor = _presentationModel.PaintState ? Cursors.Cross : Cursors.Default;
            Cursor = _presentationModel.IsScaling ? Cursors.SizeNWSE : Cursors.Default;
        }

        // Handle canvas pointer pressed
        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerPressed(e.X, e.Y);
            UpdatePanel();
        }

        // Handle canvas pointer released
        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerReleased(e.X, e.Y);
            UpdatePanel();
        }

        // Handle canvas pointer moved
        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.HandlePointerMoved(e.X, e.Y);
            UpdatePanel();
        }

        // Handle canvas paint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawCanvas(new FormGraphicsAdapter(e.Graphics));
        }

        // Handle page paint
        public void HandlePagePaint(object sender, PaintEventArgs e)
        {
            Button currentPage = sender as Button;
            int currentIndex = _pages.IndexOf(currentPage);
            _presentationModel.DrawPage(currentIndex, new FormGraphicsAdapter(e.Graphics));
        }

        // Update canvas size
        private void UpdateCanvasSize(object sender, EventArgs e)
        {
            _presentationModel.UpdateCanvasSize(_canvasBackground.Width, _canvasBackground.Height);
            _canvas.Width = _presentationModel.CanvasSize.Width;
            _canvas.Height = _presentationModel.CanvasSize.Height;
            _canvas.Location = _presentationModel.CanvasPosition;
            UpdateAllPagesAndCanvasPaint();
        }

        // Update pages size
        private void UpdatePagesSize(object sender, EventArgs e)
        {
            _presentationModel.UpdatePagesSize(_pageBackground.Width);
            UpdatePagesCount();
            for (int i = 0; i < _pages.Count; i++)
            {
                _pages[i].Width = _presentationModel.PageSize.Width;
                _pages[i].Height = _presentationModel.PageSize.Height;
                _pages[i].Location = _presentationModel.GetPagePosition(i);
            }
            UpdatePageSelected();
            UpdateAllPagesAndCanvasPaint();
        }

        // Update pages count
        private void UpdatePagesCount()
        {
            while (_pages.Count > _presentationModel.PagesCount)
            {
                _pages[_pages.Count - 1].Dispose();
                _pages.RemoveAt(_pages.Count - 1);
            }
            while (_pages.Count < _presentationModel.PagesCount)
            {
                _pages.Add(GetNewPage());
            }
        }

        // Update all pages and canvas paint
        private void UpdateAllPagesAndCanvasPaint()
        {
            UpdatePagesCount();
            _canvas.Refresh();
            for (int i = 0; i < _pages.Count; i++)
            {
                _pages[i].Refresh();
            }
        }

        // Click UndoButton
        private void ClickUndoButton(object sender, EventArgs e)
        {
            _presentationModel.Undo();
            UpdatePagesSize(sender, e);
            UpdateAllPagesAndCanvasPaint();
            UpdatePanel();
        }

        // Click RedoButton
        private void ClickRedoButton(object sender, EventArgs e)
        {
            _presentationModel.Redo();
            UpdatePagesSize(sender, e);
            UpdateAllPagesAndCanvasPaint();
            UpdatePanel();
        }

        // Get new page
        private Button GetNewPage()
        {
            Button newPage = new Button();
            newPage.BackColor = SystemColors.ButtonHighlight;
            newPage.Size = _pages[0].Size;
            newPage.TabIndex = 0;
            newPage.UseVisualStyleBackColor = true;
            newPage.FlatAppearance.BorderColor = Color.FromArgb(0, 107, 190);
            newPage.FlatAppearance.BorderSize = Symbol.TWO;
            newPage.Click += ClickPage;
            _pageBackground.Controls.Add(newPage);
            newPage.Paint += HandlePagePaint;
            return newPage;
        }

        // Click page
        private void ClickPage(object sender, EventArgs e)
        {
            Button currentPage = sender as Button;
            _addShapeButton.Focus();
            int index = _pages.IndexOf(currentPage);
            _presentationModel.SetCurrentPageIndex(index);
            UpdatePageSelected();
            UpdateAllPagesAndCanvasPaint();
        }

        private void UpdatePageSelected()
        {
            for (int i = 0; i < _pages.Count; i++)
            {
                _pages[i].FlatStyle = FlatStyle.Standard;
            }
            _pages[_presentationModel.CurrentPageIndex].FlatStyle = FlatStyle.Flat;
            _shapeDataGridView.DataSource = _presentationModel.CurrentShapeManager;
        }

        // Click add page button
        private void ClickAddPageButton(object sender, EventArgs e)
        {
            _presentationModel.InsertPage();
            UpdatePagesSize(sender, e);
            UpdatePanel();
        }

        // Click addShapeForm ok button
        private void ClickAddShapeFormOkButton(object sender, EventArgs e)
        {
            ShapeEventArguments arguments = e as ShapeEventArguments;
            _presentationModel.AddShape(arguments.ShapeType, arguments.Point1, arguments.Point2);
            UpdateAllPagesAndCanvasPaint();
        }

        // Click upload button
        private void ClickUploadButton(object sender, EventArgs e)
        {
            UploadForm uploadForm = new UploadForm();
            uploadForm.Show();
        }

        // Click download button
        private void ClickDownloadButton(object sender, EventArgs e)
        {

        }
    }
}
