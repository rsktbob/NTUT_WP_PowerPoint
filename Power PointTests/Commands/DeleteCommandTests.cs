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
    public class DeleteCommandTests
    {
        // DeleteCommand constructor test
        [TestMethod()]
        public void DeleteCommandTest()
        {
            Model model = new Model();
            model.AddCurrentPageShape(new Circle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(model, 0);

            command.Execute();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);
        }

        // Execute delete shape command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            model.AddCurrentPageShape(new Circle(0, 0, 0, 0));
            model.AddCurrentPageShape(new Rectangle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(model, 1);

            command.Execute();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }

        // Unexecute delete shape command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Model model = new Model();
            model.AddCurrentPageShape(new Circle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(model, 0);

            command.Execute();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);

            command.ReverseExecute();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }
    }
}