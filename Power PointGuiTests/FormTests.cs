using Power_Point;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Power_Point.GuiTests
{
    [TestClass()]
    public class FormTests
    {
        private Robot _robot;
        const string TARGET_PATH = @"D:\C#\NTUT_WP_PowerPoint\Power Point\bin\Debug\Power Point.exe";
        const string ROOT = @"D:\C#\NTUT_WP_PowerPoint\Power Point\bin\Debug";

        [TestInitialize()]
        public void FormTestInitialize()
        {
            _robot = new Robot(TARGET_PATH, ROOT);
        }

        //[TestMethod()]
        //public void FormTest()
        //{

        //}

        [TestMethod()]
        public void ClickAddShapeButtonTest()
        {
            _robot.ClickButton("_addShapeButton");
        }

        //[TestMethod()]
        //public void ClickLineButtonTest()
        //{
        //    _robot.ClickButton("_lineButton");
        //}

        //[TestMethod()]
        //public void ClickRectangleButtonTest()
        //{
        //    _robot.ClickButton("_rectangleButton");
        //}

        //[TestMethod()]
        //public void ClickCircleButtonTest()
        //{
        //    _robot.ClickButton("_circleButton");
        //}

        //[TestMethod()]
        //public void HandleCanvasPointerPressedTest()
        //{

        //}

        //[TestMethod()]
        //public void HandleCanvasPointerReleasedTest()
        //{

        //}

        //[TestMethod()]
        //public void HandleCanvasPointerMovedTest()
        //{

        //}

        //[TestMethod()]
        //public void HandleCanvasPaintTest()
        //{

        //}

        //[TestMethod()]
        //public void HandlePagePaintTest()
        //{

        //}

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

    }
}
