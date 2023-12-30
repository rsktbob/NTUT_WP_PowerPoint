using System.Drawing;

namespace Power_Point
{
    partial class AddShapeForm
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
            this._leftUpXLabel = new System.Windows.Forms.Label();
            this._leftUpYLabel = new System.Windows.Forms.Label();
            this._rightDownXLabel = new System.Windows.Forms.Label();
            this._rightDownYLabel = new System.Windows.Forms.Label();
            this._leftUpXTextBox = new System.Windows.Forms.TextBox();
            this._leftUpYTextBox = new System.Windows.Forms.TextBox();
            this._rightDownXTextBox = new System.Windows.Forms.TextBox();
            this._rightDownYTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _leftUpXLabel
            // 
            this._leftUpXLabel.AutoSize = true;
            this._leftUpXLabel.Location = new System.Drawing.Point(51, 48);
            this._leftUpXLabel.Name = "_leftUpXLabel";
            this._leftUpXLabel.Size = new System.Drawing.Size(73, 12);
            this._leftUpXLabel.TabIndex = 5;
            this._leftUpXLabel.Text = "左上角座標X";
            // 
            // _leftUpYLabel
            // 
            this._leftUpYLabel.AutoSize = true;
            this._leftUpYLabel.Location = new System.Drawing.Point(154, 48);
            this._leftUpYLabel.Name = "_leftUpYLabel";
            this._leftUpYLabel.Size = new System.Drawing.Size(73, 12);
            this._leftUpYLabel.TabIndex = 6;
            this._leftUpYLabel.Text = "左上角座標Y";
            // 
            // _rightDownXLabel
            // 
            this._rightDownXLabel.AutoSize = true;
            this._rightDownXLabel.Location = new System.Drawing.Point(51, 129);
            this._rightDownXLabel.Name = "_rightDownXLabel";
            this._rightDownXLabel.Size = new System.Drawing.Size(73, 12);
            this._rightDownXLabel.TabIndex = 7;
            this._rightDownXLabel.Text = "右下角座標X";
            // 
            // _rightDownYLabel
            // 
            this._rightDownYLabel.AutoSize = true;
            this._rightDownYLabel.Location = new System.Drawing.Point(154, 129);
            this._rightDownYLabel.Name = "_rightDownYLabel";
            this._rightDownYLabel.Size = new System.Drawing.Size(73, 12);
            this._rightDownYLabel.TabIndex = 8;
            this._rightDownYLabel.Text = "右下角座標Y";
            // 
            // _leftUpXTextBox
            // 
            this._leftUpXTextBox.Location = new System.Drawing.Point(53, 63);
            this._leftUpXTextBox.Name = "_leftUpXTextBox";
            this._leftUpXTextBox.Size = new System.Drawing.Size(71, 22);
            this._leftUpXTextBox.TabIndex = 9;
            this._leftUpXTextBox.TextChanged += new System.EventHandler(this.InputLeftUpX);
            // 
            // _leftUpYTextBox
            // 
            this._leftUpYTextBox.Location = new System.Drawing.Point(156, 63);
            this._leftUpYTextBox.Name = "_leftUpYTextBox";
            this._leftUpYTextBox.Size = new System.Drawing.Size(71, 22);
            this._leftUpYTextBox.TabIndex = 10;
            this._leftUpYTextBox.TextChanged += new System.EventHandler(this.InputLeftUpY);
            // 
            // _rightDownXTextBox
            // 
            this._rightDownXTextBox.Location = new System.Drawing.Point(53, 144);
            this._rightDownXTextBox.Name = "_rightDownXTextBox";
            this._rightDownXTextBox.Size = new System.Drawing.Size(71, 22);
            this._rightDownXTextBox.TabIndex = 11;
            this._rightDownXTextBox.TextChanged += new System.EventHandler(this.InputRightDownX);
            // 
            // _rightDownYTextBox
            // 
            this._rightDownYTextBox.Location = new System.Drawing.Point(156, 144);
            this._rightDownYTextBox.Name = "_rightDownYTextBox";
            this._rightDownYTextBox.Size = new System.Drawing.Size(71, 22);
            this._rightDownYTextBox.TabIndex = 12;
            this._rightDownYTextBox.TextChanged += new System.EventHandler(this.InputRightDownY);
            // 
            // _okButton
            // 
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(53, 198);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(71, 23);
            this._okButton.TabIndex = 13;
            this._okButton.Text = "OK";
            this._okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.ClickOkButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(156, 198);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(71, 23);
            this._cancelButton.TabIndex = 14;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // AddShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._rightDownYTextBox);
            this.Controls.Add(this._rightDownXTextBox);
            this.Controls.Add(this._leftUpYTextBox);
            this.Controls.Add(this._leftUpXTextBox);
            this.Controls.Add(this._rightDownYLabel);
            this.Controls.Add(this._rightDownXLabel);
            this.Controls.Add(this._leftUpYLabel);
            this.Controls.Add(this._leftUpXLabel);
            this.Name = "AddShapeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _leftUpXLabel;
        private System.Windows.Forms.Label _leftUpYLabel;
        private System.Windows.Forms.Label _rightDownXLabel;
        private System.Windows.Forms.Label _rightDownYLabel;
        private System.Windows.Forms.TextBox _leftUpXTextBox;
        private System.Windows.Forms.TextBox _leftUpYTextBox;
        private System.Windows.Forms.TextBox _rightDownXTextBox;
        private System.Windows.Forms.TextBox _rightDownYTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}

