using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public interface IGraphics
    {
        // clear graphics
        void ClearAll();

        // draw line
        void DrawLine(double pointX1, double pointY1, double pointX2, double pointY2);

        // draw rectangle
        void DrawRectangle(double pointX1, double pointY1, double pointX2, double pointY2);

        // draw circle
        void DrawCircle(double pointX1, double pointY1, double pointX2, double pointY2);

        // draw shape selected
        void DrawShapeSelected(double pointX1, double pointY1, double pointX2, double pointY2);

        // draw line selected
        void DrawLineSelected(double pointX1, double pointY1, double pointX2, double pointY2);
    }
}
