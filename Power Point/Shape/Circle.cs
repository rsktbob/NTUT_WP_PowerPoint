using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class Circle : Shape
    {
        public Circle(int pointX1, int pointY1, int pointX2, int pointY2) : base(pointX1, pointY1, pointX2, pointY2)
        {
            
        }

        // Get shape name
        public override string ShapeName
        {
            get 
            { 
                return Symbol.CIRCLE; 
            }
        }

        // Draw
        public override void Draw(IGraphics graphics, double ratio)
        {
            _ratio = ratio;
            graphics.DrawCircle(PaintPointX1, PaintPointY1, PaintPointX2, PaintPointY2);
            if (IsSelected)
            {
                graphics.DrawShapeSelected(PaintPointX1, PaintPointY1, PaintPointX2, PaintPointY2);
            }
        }
    }
}
