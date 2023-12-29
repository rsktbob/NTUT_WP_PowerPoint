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
    public class CircleTests
    {
        // Circle constructor test
        [TestMethod()]
        public void CircleTest()
        {
            Circle circle = new Circle(20, 30, 180, 210);
            Assert.AreEqual(20, circle.PointX1);
            Assert.AreEqual(30, circle.PointY1);
            Assert.AreEqual(180, circle.PointX2);
            Assert.AreEqual(210, circle.PointY2);
            Assert.AreEqual(Symbol.CIRCLE, circle.ShapeName);
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            Circle circle = new Circle(20, 30, 180, 210);
            FormGraphicsAdapter formGraphicsAdapter = new FormGraphicsAdapter(null);

            circle.Draw(formGraphicsAdapter, 1);
            
            circle.IsSelected = true;

            circle.Draw(formGraphicsAdapter, 1);
        }
    }
}