using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class Line : Shape
    {
        public Line(int pointX1, int pointY1, int pointX2, int pointY2) : base(pointX1, pointY1, pointX2, pointY2)
        {

        }

        // Get shape name
        public override string ShapeName
        {
            get 
            { 
                return Symbol.LINE;  
            }
        }

        // Draw
        public override void Draw(IGraphics graphics, double ratio)
        {
            _ratio = ratio;
            graphics.DrawLine(PaintPointX1, PaintPointY1, PaintPointX2, PaintPointY2);
            if (IsSelected)
                graphics.DrawLineSelected(PaintPointX1, PaintPointY1, PaintPointX2, PaintPointY2);
        }
    }
}
