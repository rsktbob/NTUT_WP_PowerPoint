using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class InsertPageCommand : ICommand
    {
        Pages _pages;
        int _nextIndex;
        Shapes _shapes;

        public InsertPageCommand(Pages pages)
        {
            _pages = pages;
            _nextIndex = pages.CurrentPageIndex + 1;
            _shapes = new Shapes();
        }

        public void Execute()
        {
            _pages.InsertPage(_nextIndex, _shapes);
        }

        public void ReverseExecute()
        {
            _pages.DeletePage(_nextIndex);
        }
    }
}
