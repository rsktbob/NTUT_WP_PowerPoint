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
    public class PagesTests
    {
        [TestMethod()]
        public void PagesTest()
        {
            Pages pages = new Pages();

            Assert.AreEqual(1, pages.PageCount);
        }

        [TestMethod()]
        public void MoveCurrentPageShapeTest()
        {
            Pages pages = new Pages();
            Shapes shapes = new Shapes();

            pages.InsertPage(1, shapes);
            Shape circle = new Circle(20, 30, 60, 140);
            circle.IsSelected = true;
            shapes.AddShape(circle);

            pages.MoveCurrentPageShape(0, 50, 60);

            Assert.AreEqual(circle.PointX1, 50);
            Assert.AreEqual(circle.PointY1, 60);
            Assert.AreEqual(circle.PointX2, 90);
            Assert.AreEqual(circle.PointY2, 170);
        }

        [TestMethod()]
        public void InsertPageTest()
        {
            Pages pages = new Pages();
            pages.InsertPage(1, new Shapes());

            Assert.AreEqual(2, pages.PageCount);
        }

        [TestMethod()]
        public void DeletePageTest()
        {
            Pages pages = new Pages();
            pages.InsertPage(1, new Shapes());

            pages.DeletePage(1);

            Assert.AreEqual(1, pages.PageCount);
        }

        [TestMethod()]
        public void SetCurrentPageIndexTest()
        {
            Pages pages = new Pages();
            pages.InsertPage(1, new Shapes());

            pages.SetCurrentPageIndex(0);

            Assert.AreEqual(0, pages.CurrentPageIndex);
        }

        [TestMethod()]
        public void LoadFileDataTest()
        {
            Pages pages = new Pages();
            pages.LoadFileData(null);
        }
    }
}