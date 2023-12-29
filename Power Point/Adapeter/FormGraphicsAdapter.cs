using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class FormGraphicsAdapter : IGraphics
    {
        Graphics _graphics;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        // clear graphics
        public void ClearAll()
        {

        }

        // Draw line
        public void DrawLine(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            if (_graphics != null)
            {
                _graphics.DrawLine(Pens.Red, (float)pointX1, (float)pointY1, (float)pointX2, (float)pointY2);
            }
        }

        // Draw rectangle
        public void DrawRectangle(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            if (_graphics != null)
            {
                _graphics.DrawRectangle(Pens.Red, (float)pointX1, (float)pointY1, (float)(pointX2 - pointX1), (float)(pointY2 - pointY1));
            }
        }

        // Draw circle
        public void DrawCircle(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            if (_graphics != null)
            {
                _graphics.DrawEllipse(Pens.Red, (float)pointX1, (float)pointY1, (float)(pointX2 - pointX1), (float)(pointY2 - pointY1));
            }
        }

        // Draw shape selected
        public void DrawShapeSelected(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            if (_graphics != null)
            {
                int radius = Symbol.SELECTED_SHAPE_SIZE / Symbol.TWO;
                int size = Symbol.SELECTED_SHAPE_SIZE;

                _graphics.DrawEllipse(Pens.Black, (float)(pointX1 - radius), (float)(pointY1 - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(((pointX1 + pointX2) / Symbol.TWO) - radius), (float)(pointY1 - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(pointX2 - radius), (float)(pointY1 - radius), size, size);

                _graphics.DrawEllipse(Pens.Black, (float)(pointX1 - radius), (float)(((pointY1 + pointY2) / Symbol.TWO) - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(pointX2 - radius), (float)(((pointY1 + pointY2) / Symbol.TWO) - radius), size, size);

                _graphics.DrawEllipse(Pens.Black, (float)(pointX1 - radius), (float)(pointY2 - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(((pointX1 + pointX2) / Symbol.TWO) - radius), (float)(pointY2 - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(pointX2 - radius), (float)(pointY2 - radius), size, size);
            }
        }

        // Draw line selected
        public void DrawLineSelected(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            if (_graphics != null)
            {
                int radius = Symbol.SELECTED_SHAPE_SIZE / Symbol.TWO;
                int size = Symbol.SELECTED_SHAPE_SIZE;
                _graphics.DrawEllipse(Pens.Black, (float)(pointX1 - radius), (float)(pointY1 - radius), size, size);
                _graphics.DrawEllipse(Pens.Black, (float)(pointX2 - radius), (float)(pointY2 - radius), size, size);
            }
        }
    }
}
