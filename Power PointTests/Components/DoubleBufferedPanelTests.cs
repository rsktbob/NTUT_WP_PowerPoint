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
    public class DoubleBufferedPanelTests
    {
        //  DoubleBufferedPanel constructor test
        [TestMethod()]
        public void DoubleBufferedPanelTest()
        {
            DoubleBufferedPanel doubleBufferedPanel = new DoubleBufferedPanel();

            Assert.IsInstanceOfType(doubleBufferedPanel, typeof(DoubleBufferedPanel));
        }
    }
}