using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Power_Point.Tests
{
    [TestClass()]
    public class ShapeEventArgumentsTests
    {
        [TestMethod()]
        public void ShapeEventArgumentsTest()
        {
            ShapeEventArguments arguments = new ShapeEventArguments(Symbol.CIRCLE, new Point(30, 60), new Point(80, 140));

            Assert.AreEqual(new Point(30, 60), arguments.Point1);
            Assert.AreEqual(new Point(80, 140), arguments.Point2);
            Assert.AreEqual(Symbol.CIRCLE, arguments.ShapeType);
        }
    }
}