using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DeleteCurrentPageCommand : ICommand
    {
        private Pages _pages;
        private Shapes _shapes;
        private int _index;

        public DeleteCurrentPageCommand(Pages pages)
        {
            _pages = pages;
            _shapes = pages.PageManager[pages.CurrentPageIndex];
            _index = pages.CurrentPageIndex;
        }

        // Execute delete page command
        public void Execute()
        {
            _pages.DeletePage(_index);
        }

        // Reverse delete page command
        public void ReverseExecute()
        {
            _pages.InsertPage(_index, _shapes);
        }
    }
}
