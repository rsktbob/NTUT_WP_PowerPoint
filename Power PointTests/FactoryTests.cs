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
    public class FactoryTests
    {
        // Create shape test
        [TestMethod()]
        public void CreateShapeTest()
        {
            Factory factory = new Factory();
            Shape shape;

            shape = factory.CreateRandomPositionShape(Symbol.LINE, 200, 300);
            Assert.IsInstanceOfType(shape, typeof(Line));

            shape = factory.CreateRandomPositionShape(Symbol.CIRCLE, 200, 300);
            Assert.IsInstanceOfType(shape, typeof(Circle));

            shape = factory.CreateRandomPositionShape(Symbol.RECTANGLE, 200, 300);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));
        }
    }
}