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
    public class DeleteSelectedCommandTests
    {
        // DeleteCommand constructor test
        [TestMethod()]
        public void DeleteSelectedCommandTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(shapes, 0);

            command.Execute();

            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }

        // Execute delete selected shape command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(0, 0, 0, 0);
            circle.IsSelected = true;
            shapes.AddShape(circle);
            shapes.AddShape(new Rectangle(0, 0, 0, 0));
            DeleteSelectedCommand command = new DeleteSelectedCommand(shapes);

            command.Execute();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Unexecute delete selected shape command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(0, 0, 0, 0);
            circle.IsSelected = true;
            shapes.AddShape(circle) ;
            DeleteSelectedCommand command = new DeleteSelectedCommand(shapes);

            command.Execute();

            Assert.AreEqual(0, shapes.ShapeManager.Count);

            command.ReverseExecute();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }
    }
}