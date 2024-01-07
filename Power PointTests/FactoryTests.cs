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
            Factory factory1 = new Factory(Symbol.LINE);

            Shape shape1 = factory1.CreateShape(20, 30, 60, 140);
            Assert.IsInstanceOfType(shape1, typeof(Line));


            Factory factory2 = new Factory(Symbol.RECTANGLE);

            Shape shape2 = factory2.CreateShape(20, 30, 60, 140);
            Assert.IsInstanceOfType(shape2, typeof(Rectangle));

            Factory factory3 = new Factory(Symbol.CIRCLE);

            Shape shape3 = factory3.CreateShape(20, 30, 60, 140);
            Assert.IsInstanceOfType(shape3, typeof(Circle));
        }
    }
}