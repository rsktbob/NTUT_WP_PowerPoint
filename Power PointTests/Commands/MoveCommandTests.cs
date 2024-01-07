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
    public class MoveCommandTests
    {
        // MoveCommand constructor test
        [TestMethod()]
        public void MoveCommandTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(20, 60, 140, 180);
            shape.IsSelected = true;
            shapes.AddShape(shape);
            MoveCommand command = new MoveCommand(shapes, 20, 60, 90, 130);

            command.Execute();

            Assert.AreEqual(90, shape.PointX1);
            Assert.AreEqual(130, shape.PointY1);
            Assert.AreEqual(210, shape.PointX2);
            Assert.AreEqual(250, shape.PointY2);
        }

        // Excute move command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(60, 50, 140, 180);
            shape.IsSelected = true;
            shapes.AddShape(shape);
            MoveCommand command = new MoveCommand(shapes, 60, 50, 140, 160);

            command.Execute();

            Assert.AreEqual(140, shape.PointX1);
            Assert.AreEqual(160, shape.PointY1);
            Assert.AreEqual(220, shape.PointX2);
            Assert.AreEqual(290, shape.PointY2);
        }

        // Unexecute move comand test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(60, 50, 140, 180);
            shape.IsSelected = true;
            shapes.AddShape(shape);
            MoveCommand command = new MoveCommand(shapes, 60, 50, 140, 160);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(60, shape.PointX1);
            Assert.AreEqual(50, shape.PointY1);
            Assert.AreEqual(140, shape.PointX2);
            Assert.AreEqual(180, shape.PointY2);
        }
    }
}