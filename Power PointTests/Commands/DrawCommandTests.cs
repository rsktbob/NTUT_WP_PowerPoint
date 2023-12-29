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
    public class DrawCommandTests
    {
        // DrawCommand constructor test
        [TestMethod()]
        public void DrawCommandTest()
        {
            Model model = new Model();
            Shape shape = new Circle(20, 60, 140, 180);
            DrawCommand command = new DrawCommand(model, shape);

            command.Execute();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }

        // Excute draw command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Rectangle(20, 60, 140, 180);
            DrawCommand command = new DrawCommand(model, shape);

            command.Execute();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);

            Shape resultShape = model.CurrentShapeManager[0];

            Assert.AreEqual(20, resultShape.PointX1);
            Assert.AreEqual(60, resultShape.PointY1);
            Assert.AreEqual(140, resultShape.PointX2);
            Assert.AreEqual(180, resultShape.PointY2);
        }

        // Unexecute draw command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Model model = new Model();
            Shape shape = new Rectangle(20, 60, 140, 180);
            DrawCommand command = new DrawCommand(model, shape);

            command.Execute();
            command.ReverseExecute();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);
        }
    }
}