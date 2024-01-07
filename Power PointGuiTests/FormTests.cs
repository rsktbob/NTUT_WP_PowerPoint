using Power_Point;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;

namespace Power_Point.GuiTests
{
    [TestClass()]
    public class FormTests
    {
        const string TARGET_PATH = @"D:\C#\NTUT_WP_PowerPoint\Power Point\bin\Debug\Power Point.exe";
        const string ROOT = @"D:\C#\NTUT_WP_PowerPoint\Power Point\bin\Debug";
        Robot _robot;

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
        public void ClickLineButtonTest()
        {
            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 0);
            _robot.ClickButtonByName("lineButton");
            _robot.AssertEnable("lineButton", true);

            _robot.Draw(0, 0, 320, 450);

            //string[] data = { "刪除", "線", "(0, 0), (320, 450)" };
            //_robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);   
        }

        //[TestMethod()]
        //public void ClickRectangleButtonTest()
        //{
        //    _robot.ClickButtonByName("rectangleButton");
        //    _robot.AssertEnable("rectangleButton", true);
            
        //}

        //[TestMethod()]
        //public void ClickCircleButtonTest()
        //{
        //    _robot.ClickButtonByName("circleButton");
        //    _robot.AssertEnable("circleButton", true);
        //}

        [TestMethod()]
        public void ClickAddShapeButtonTest()
        {
            _robot.ClickButtonByName("新增");
            _robot.ClickButtonByAccessibilityId("_canvas");
        }

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
        public void FormTestCleanUp()
        {
            _robot.CleanUp();
        }
    }
}
