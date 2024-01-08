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
    public class ScaleCommandTests
    {
        [TestMethod()]
        public void ScaleCommandTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(20, 30, 60, 140);
            circle.IsSelected = true;
            shapes.AddShape(circle);
            ScaleCommand command = new ScaleCommand(shapes, 60, 140, 120, 180);

            command.Execute();

            Assert.AreEqual(20, circle.PointX1);
            Assert.AreEqual(30, circle.PointY1);
            Assert.AreEqual(120, circle.PointX2);
            Assert.AreEqual(180, circle.PointY2);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(20, 30, 60, 140);
            circle.IsSelected = true;
            shapes.AddShape(circle);
            ScaleCommand command = new ScaleCommand(shapes, 60, 140, 180, 540);

            command.Execute();

            Assert.AreEqual(20, circle.PointX1);
            Assert.AreEqual(30, circle.PointY1);
            Assert.AreEqual(180, circle.PointX2);
            Assert.AreEqual(540, circle.PointY2);
        }

        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(20, 30, 60, 140);
            circle.IsSelected = true;
            shapes.AddShape(circle);
            ScaleCommand command = new ScaleCommand(shapes, 60, 140, 180, 540);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(20, circle.PointX1);
            Assert.AreEqual(30, circle.PointY1);
            Assert.AreEqual(60, circle.PointX2);
            Assert.AreEqual(140, circle.PointY2);
        }
    }
}