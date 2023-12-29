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
    public class ShapeTests
    {
        // Shape constructor test
        [TestMethod()]
        public void ShapeTest()
        {
            Shape shape = new Shape(20, 30, 140, 300);
            shape.PointX1 = 85;
            Assert.AreEqual(85, shape.PointX1);
            Assert.AreEqual(30, shape.PointY1);
            Assert.AreEqual(140, shape.PointX2);
            Assert.AreEqual(300, shape.PointY2);
            Assert.AreEqual(85, shape.PaintPointX1);
            Assert.AreEqual(30, shape.PaintPointY1);
            Assert.AreEqual(140, shape.PaintPointX2);
            Assert.AreEqual(300, shape.PaintPointY2);
            Assert.AreEqual(Symbol.SHAPE, shape.ShapeName);
            Assert.AreEqual(Symbol.LEFT_BRACKET + "85" + Symbol.COMMA + "30" + Symbol.RIGHT_BRACKET + Symbol.COMMA + Symbol.SPACE + Symbol.LEFT_BRACKET +
                   "140" + Symbol.COMMA + "300" + Symbol.RIGHT_BRACKET, shape.Info);
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            Shape shape = new Shape(30, 60, 140, 180);
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            shape.Draw(graphics, 1);
        }

        // Move test
        [TestMethod()]
        public void MoveTest()
        {
            Shape shape = new Circle(30, 60, 140, 180);

            shape.Move(60, 210);

            Assert.AreEqual(60, shape.PointX1);
            Assert.AreEqual(210, shape.PointY1);
            Assert.AreEqual(170, shape.PointX2);
            Assert.AreEqual(330, shape.PointY2);
        }
    }
}