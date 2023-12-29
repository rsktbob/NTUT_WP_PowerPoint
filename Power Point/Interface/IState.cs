using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public interface IState
    {
        // Mouse move
        void HandleMouseMove(double pointX, double pointY);

        // Mouse Down
        void HandleMouseDown(double pointX, double pointY);

        // Mouse Release
        void HandleMouseUp(double pointX, double pointY);
    }
}
