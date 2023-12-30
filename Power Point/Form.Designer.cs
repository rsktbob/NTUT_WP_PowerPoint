using System.Drawing;

namespace Power_Point
{
    partial class Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this._page1 = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._explanationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._addShapeButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._dataGroupBox = new System.Windows.Forms.GroupBox();
            this._shapeDataGridView = new System.Windows.Forms.DataGridView();
            this._pageBackground = new System.Windows.Forms.Panel();
            this._shapeToolStrip = new System.Windows.Forms.ToolStrip();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._generalButton = new System.Windows.Forms.ToolStripButton();
            this._addPageButton = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._uploadButton = new System.Windows.Forms.ToolStripButton();
            this._downloadButton = new System.Windows.Forms.ToolStripButton();
            this._canvasBackground = new System.Windows.Forms.Panel();
            this._canvas = new Power_Point.DoubleBufferedPanel();
            this._leftBorder = new System.Windows.Forms.Splitter();
            this._rightBorder = new System.Windows.Forms.Splitter();
            this._menuStrip.SuspendLayout();
            this._dataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).BeginInit();
            this._pageBackground.SuspendLayout();
            this._shapeToolStrip.SuspendLayout();
            this._canvasBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // _page1
            // 
            this._page1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._page1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(107)))), ((int)(((byte)(190)))));
            this._page1.FlatAppearance.BorderSize = 2;
            this._page1.Location = new System.Drawing.Point(8, 21);
            this._page1.Name = "_page1";
            this._page1.Size = new System.Drawing.Size(176, 95);
            this._page1.TabIndex = 0;
            this._page1.UseVisualStyleBackColor = true;
            this._page1.Click += new System.EventHandler(this.ClickPage);
            this._page1.Paint += new System.Windows.Forms.PaintEventHandler(this.HandlePagePaint);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._explanationsToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1417, 24);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "_menuStrip";
            // 
            // _explanationsToolStripMenuItem
            // 
            this._explanationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._explanationsToolStripMenuItem.Name = "_explanationsToolStripMenuItem";
            this._explanationsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this._explanationsToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _addShapeButton
            // 
            this._addShapeButton.Location = new System.Drawing.Point(17, 25);
            this._addShapeButton.Name = "_addShapeButton";
            this._addShapeButton.Size = new System.Drawing.Size(64, 41);
            this._addShapeButton.TabIndex = 3;
            this._addShapeButton.Text = "新增";
            this._addShapeButton.UseVisualStyleBackColor = true;
            this._addShapeButton.Click += new System.EventHandler(this.ClickAddShapeButton);
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓形"});
            this._shapeComboBox.Location = new System.Drawing.Point(103, 34);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(101, 20);
            this._shapeComboBox.TabIndex = 4;
            this._shapeComboBox.Text = "線";
            // 
            // _dataGroupBox
            // 
            this._dataGroupBox.Controls.Add(this._shapeDataGridView);
            this._dataGroupBox.Controls.Add(this._shapeComboBox);
            this._dataGroupBox.Controls.Add(this._addShapeButton);
            this._dataGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this._dataGroupBox.Location = new System.Drawing.Point(1176, 49);
            this._dataGroupBox.Name = "_dataGroupBox";
            this._dataGroupBox.Size = new System.Drawing.Size(241, 665);
            this._dataGroupBox.TabIndex = 6;
            this._dataGroupBox.TabStop = false;
            this._dataGroupBox.Text = "資料顯示";
            // 
            // _shapeDataGridView
            // 
            this._shapeDataGridView.AllowUserToAddRows = false;
            this._shapeDataGridView.AllowUserToDeleteRows = false;
            this._shapeDataGridView.AllowUserToResizeColumns = false;
            this._shapeDataGridView.AllowUserToResizeRows = false;
            this._shapeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeDataGridView.Location = new System.Drawing.Point(0, 88);
            this._shapeDataGridView.Name = "_shapeDataGridView";
            this._shapeDataGridView.ReadOnly = true;
            this._shapeDataGridView.RowHeadersVisible = false;
            this._shapeDataGridView.RowTemplate.Height = 24;
            this._shapeDataGridView.Size = new System.Drawing.Size(241, 577);
            this._shapeDataGridView.TabIndex = 8;
            this._shapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDeleteShapeButton);
            // 
            // _pageBackground
            // 
            this._pageBackground.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._pageBackground.Controls.Add(this._page1);
            this._pageBackground.Dock = System.Windows.Forms.DockStyle.Left;
            this._pageBackground.Location = new System.Drawing.Point(0, 49);
            this._pageBackground.Name = "_pageBackground";
            this._pageBackground.Size = new System.Drawing.Size(187, 665);
            this._pageBackground.TabIndex = 11;
            this._pageBackground.Resize += new System.EventHandler(this.UpdatePagesSize);
            // 
            // _shapeToolStrip
            // 
            this._shapeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._generalButton,
            this._addPageButton,
            this._undoButton,
            this._redoButton,
            this._uploadButton,
            this._downloadButton});
            this._shapeToolStrip.Location = new System.Drawing.Point(0, 24);
            this._shapeToolStrip.Name = "_shapeToolStrip";
            this._shapeToolStrip.Size = new System.Drawing.Size(1417, 25);
            this._shapeToolStrip.TabIndex = 12;
            this._shapeToolStrip.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(23, 22);
            this._lineButton.Text = "toolStripButton1";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(23, 22);
            this._rectangleButton.Text = "toolStripButton2";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleButton.Image")));
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(23, 22);
            this._circleButton.Text = "toolStripButton3";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _generalButton
            // 
            this._generalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._generalButton.Image = ((System.Drawing.Image)(resources.GetObject("_generalButton.Image")));
            this._generalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._generalButton.Name = "_generalButton";
            this._generalButton.Size = new System.Drawing.Size(23, 22);
            this._generalButton.Text = "toolStripButton1";
            this._generalButton.Click += new System.EventHandler(this.ClickGeneralButton);
            // 
            // _addPageButton
            // 
            this._addPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addPageButton.Image = ((System.Drawing.Image)(resources.GetObject("_addPageButton.Image")));
            this._addPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addPageButton.Name = "_addPageButton";
            this._addPageButton.Size = new System.Drawing.Size(23, 22);
            this._addPageButton.Text = "toolStripButton1";
            this._addPageButton.Click += new System.EventHandler(this.ClickAddPageButton);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(23, 22);
            this._undoButton.Text = "toolStripButton1";
            this._undoButton.Click += new System.EventHandler(this.ClickUndoButton);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(23, 22);
            this._redoButton.Text = "toolStripButton2";
            this._redoButton.Click += new System.EventHandler(this.ClickRedoButton);
            // 
            // _uploadButton
            // 
            this._uploadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._uploadButton.Image = ((System.Drawing.Image)(resources.GetObject("_uploadButton.Image")));
            this._uploadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._uploadButton.Name = "_uploadButton";
            this._uploadButton.Size = new System.Drawing.Size(23, 22);
            this._uploadButton.Text = "toolStripButton1";
            this._uploadButton.Click += new System.EventHandler(this.ClickUploadButton);
            // 
            // _downloadButton
            // 
            this._downloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._downloadButton.Image = ((System.Drawing.Image)(resources.GetObject("_downloadButton.Image")));
            this._downloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._downloadButton.Name = "_downloadButton";
            this._downloadButton.Size = new System.Drawing.Size(23, 22);
            this._downloadButton.Text = "toolStripButton2";
            this._downloadButton.Click += new System.EventHandler(this.ClickdownloadButton);
            // 
            // _canvasBackground
            // 
            this._canvasBackground.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._canvasBackground.Controls.Add(this._canvas);
            this._canvasBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvasBackground.Location = new System.Drawing.Point(187, 49);
            this._canvasBackground.Name = "_canvasBackground";
            this._canvasBackground.Size = new System.Drawing.Size(989, 665);
            this._canvasBackground.TabIndex = 0;
            this._canvasBackground.Resize += new System.EventHandler(this.UpdateCanvasSize);
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas.Location = new System.Drawing.Point(15, 44);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(960, 540);
            this._canvas.TabIndex = 13;
            this._canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.HandleCanvasPaint);
            this._canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasPointerPressed);
            this._canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasPointerMoved);
            this._canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandleCanvasPointerReleased);
            // 
            // _leftBorder
            // 
            this._leftBorder.BackColor = System.Drawing.SystemColors.GrayText;
            this._leftBorder.Location = new System.Drawing.Point(187, 49);
            this._leftBorder.Name = "_leftBorder";
            this._leftBorder.Size = new System.Drawing.Size(3, 665);
            this._leftBorder.TabIndex = 13;
            this._leftBorder.TabStop = false;
            // 
            // _rightBorder
            // 
            this._rightBorder.BackColor = System.Drawing.SystemColors.GrayText;
            this._rightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this._rightBorder.Location = new System.Drawing.Point(1173, 49);
            this._rightBorder.Name = "_rightBorder";
            this._rightBorder.Size = new System.Drawing.Size(3, 665);
            this._rightBorder.TabIndex = 14;
            this._rightBorder.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1417, 714);
            this.Controls.Add(this._rightBorder);
            this.Controls.Add(this._leftBorder);
            this.Controls.Add(this._canvasBackground);
            this.Controls.Add(this._dataGroupBox);
            this.Controls.Add(this._pageBackground);
            this.Controls.Add(this._shapeToolStrip);
            this.Controls.Add(this._menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip;
            this.Name = "Form";
            this.Text = "HW7";
            this.Load += new System.EventHandler(this.LoadForm);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._dataGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGridView)).EndInit();
            this._pageBackground.ResumeLayout(false);
            this._shapeToolStrip.ResumeLayout(false);
            this._shapeToolStrip.PerformLayout();
            this._canvasBackground.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _page1;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _explanationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.Button _addShapeButton;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.GroupBox _dataGroupBox;
        private System.Windows.Forms.DataGridView _shapeDataGridView;
        private System.Windows.Forms.Panel _pageBackground;
        private System.Windows.Forms.ToolStrip _shapeToolStrip;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _circleButton;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.ToolStripButton _generalButton;
        private System.Windows.Forms.Panel _canvasBackground;
        private System.Windows.Forms.Splitter _leftBorder;
        private System.Windows.Forms.Splitter _rightBorder;
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
        private System.Windows.Forms.ToolStripButton _addPageButton;
        private System.Windows.Forms.ToolStripButton _uploadButton;
        private System.Windows.Forms.ToolStripButton _downloadButton;
    }
}

