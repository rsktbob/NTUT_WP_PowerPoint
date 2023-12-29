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
    public class AddCommandTests
    {
        // Add command constructor test
        [TestMethod()]
        public void AddCommandTest()
        {
            Model model = new Model();
            AddCommand command = new AddCommand(model, Symbol.CIRCLE);

            command.Execute();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }

        // Execute add shape command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            AddCommand command = new AddCommand(model, Symbol.CIRCLE);

            command.Execute();
            command.Execute();

            Assert.AreEqual(2, model.CurrentShapeManager.Count);
        }

        // Reverse execute add shape command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Model model = new Model();
            AddCommand command = new AddCommand(model, Symbol.CIRCLE);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);
        }
    }
}