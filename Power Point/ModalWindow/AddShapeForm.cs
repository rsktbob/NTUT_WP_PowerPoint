using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Power_Point
{
    public partial class AddShapeForm : System.Windows.Forms.Form
    {
        // Click ok button event
        public event EventHandler _clickOkButtonEvent;
        private string _shapeType;
        private int _pointX1;
        private int _pointY1;
        private int _pointX2;
        private int _pointY2;

        public AddShapeForm(string shapeType)
        {
            InitializeComponent();
            _shapeType = shapeType;
        }

        // Input text in the leftUpXInput
        private void InputLeftUpX(object sender, EventArgs e)
        {
            string input = _leftUpXTextBox.Text;
            if (int.TryParse(input, out int number))
            {
                _pointX1 = number;
                CheckInputIsAvailable();
            }
            else
            {
                _pointX1 = -1;
            }
        }

        // Input text in the leftUpYInput
        private void InputLeftUpY(object sender, EventArgs e)
        {
            string input = _leftUpYTextBox.Text;
            if (int.TryParse(input, out int number))
            {
                _pointY1 = number;
                CheckInputIsAvailable();
            }
            else
            {
                _pointY1 = -1;
            }
        }

        // Input text in the righttDownXInput
        private void InputRightDownX(object sender, EventArgs e)
        {
            string input = _rightDownXTextBox.Text;
            if (int.TryParse(input, out int number))
            {
                _pointX2 = number;
                CheckInputIsAvailable();
            }
            else
            {
                _pointX2 = -1;
            }
        }

        // Input text in the rightDownYInput
        private void InputRightDownY(object sender, EventArgs e)
        {
            string input = _rightDownYTextBox.Text;
            if (int.TryParse(input, out int number))
            {
                _pointY2 = number;
                CheckInputIsAvailable();
            }
            else
            {
                _pointY2 = -1;
            }
        }

        // Click cancel button
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // Click ok button
        private void ClickOkButton(object sender, EventArgs e)
        {
            if (_clickOkButtonEvent != null)
            {
                ShapeEventArguments arguments = new ShapeEventArguments(_shapeType, new Point(_pointX1, _pointY1), new Point(_pointX2, _pointY2));
                _clickOkButtonEvent.Invoke(sender, arguments);
            }
            this.Close();
        }

        // Check input is available
        public void CheckInputIsAvailable()
        {
            if (_pointX1 != -1 && _pointY1 != -1 && _pointY2 != -1 && _pointX2 != -1)
            {
                if (_pointX2 > _pointX1 && _pointY2 > _pointY1)
                {
                    _okButton.Enabled = true;
                }
                else
                {
                    _okButton.Enabled = false;
                }
            }
            else
            {
                _okButton.Enabled = false;
            }
        }
    }
}
