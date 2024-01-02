﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class DeletePageCommand : ICommand
    {
        private Pages _pages;
        private Shapes _shapes;
        private int _index;

        public DeletePageCommand(Pages pages, int index)
        {
            _pages = pages;
            _shapes = pages.PageManager[index];
            _index = index;
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