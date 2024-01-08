using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class DeleteCurrentPageCommandTests
    {
        [TestMethod()]
        public void DeleteCurrentPageCommandTest()
        {
            Pages pages = new Pages();
            DeleteCurrentPageCommand commmand = new DeleteCurrentPageCommand(pages);

            commmand.Execute();

            Assert.AreEqual(0, pages.PageCount);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Pages pages = new Pages();
            InsertPageCommand insertPagecommand = new InsertPageCommand(pages);
            insertPagecommand.Execute();
            DeleteCurrentPageCommand deleteCurrentPageCommand = new DeleteCurrentPageCommand(pages);
            
            deleteCurrentPageCommand.Execute();

            Assert.AreEqual(1, pages.PageCount);
        }

        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Pages pages = new Pages();
            InsertPageCommand insertPagecommand = new InsertPageCommand(pages);
            insertPagecommand.Execute();
            DeleteCurrentPageCommand deleteCurrentPageCommand = new DeleteCurrentPageCommand(pages);

            deleteCurrentPageCommand.Execute();
            deleteCurrentPageCommand.ReverseExecute();

            Assert.AreEqual(2, pages.PageCount);
        }
    }
}