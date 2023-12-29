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
    public class RectangleTests
    {
        // Rectangle constructor test
        [TestMethod()]
        public void RectangleTest()
        {
            Rectangle rectangle = new Rectangle(20, 30, 180, 210);
            Assert.AreEqual(20, rectangle.PointX1);
            Assert.AreEqual(30, rectangle.PointY1);
            Assert.AreEqual(180, rectangle.PointX2);
            Assert.AreEqual(210, rectangle.PointY2);
            Assert.AreEqual(Symbol.RECTANGLE, rectangle.ShapeName);
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            Rectangle rectangle = new Rectangle(20, 30, 180, 210);
            FormGraphicsAdapter formGraphicsAdapter = new FormGraphicsAdapter(null);

            rectangle.Draw(formGraphicsAdapter, 1);

            rectangle.IsSelected = true;

            rectangle.Draw(formGraphicsAdapter, 1);
        }
    }
}