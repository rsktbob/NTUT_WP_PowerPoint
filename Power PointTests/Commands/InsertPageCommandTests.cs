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
    public class InsertPageCommandTests
    {
        [TestMethod()]
        public void InsertPageCommandTest()
        {
            Pages pages = new Pages();
            InsertPageCommand command = new InsertPageCommand(pages);

            command.Execute();

            Assert.AreEqual(2, pages.PageCount);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Pages pages = new Pages();
            InsertPageCommand command = new InsertPageCommand(pages);

            command.Execute();
            command.Execute();

            Assert.AreEqual(3, pages.PageCount);
        }

        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Pages pages = new Pages();
            InsertPageCommand command = new InsertPageCommand(pages);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(1, pages.PageCount);
        }
    }
}