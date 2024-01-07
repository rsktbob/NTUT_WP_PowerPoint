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
            Shapes shapes = new Shapes();
            AddCommand command = new AddCommand(shapes, Symbol.CIRCLE, 3, 14, 6, 18);

            command.Execute();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Execute add shape command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Shapes shapes = new Shapes();
            AddCommand command = new AddCommand(shapes, Symbol.CIRCLE, 3, 14, 6, 18);

            command.Execute();
            command.Execute();

            Assert.AreEqual(2, shapes.ShapeManager.Count);
        }

        // Reverse execute add shape command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Shapes shapes = new Shapes();
            AddCommand command = new AddCommand(shapes, Symbol.CIRCLE, 3, 14, 6, 18);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }
    }
}