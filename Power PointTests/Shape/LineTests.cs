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
    public class LineTests
    {
        // Line constructor test
        [TestMethod()]
        public void LineTest()
        {
            Line line = new Line(20, 30, 180, 210);
            Assert.AreEqual(20, line.PointX1);
            Assert.AreEqual(30, line.PointY1);
            Assert.AreEqual(180, line.PointX2);
            Assert.AreEqual(210, line.PointY2);
            Assert.AreEqual(Symbol.LINE, line.ShapeName);
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            Line line = new Line(20, 30, 180, 210);
            FormGraphicsAdapter formGraphicsAdapter = new FormGraphicsAdapter(null);

            line.Draw(formGraphicsAdapter, 1);

            line.IsSelected = true;

            line.Draw(formGraphicsAdapter, 1);
        }
    }
}