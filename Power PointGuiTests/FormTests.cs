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

        // test initialize
        [TestInitialize()]
        public void FormTestInitialize()
        {
            _robot = new Robot(TARGET_PATH, ROOT);
        }

        [TestMethod()]
        public void ClickDrawShapeTest()
        {
            _robot.ClickButtonByName("lineButton");
            _robot.AssertEnable("lineButton", true);

            _robot.Move("_canvas", 60, 80, 320, 450);

            string[] data1 = { "刪除", "線", "(60, 80), (320, 450)" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data1);

            _robot.ClickButtonByName("rectangleButton");
            _robot.AssertEnable("rectangleButton", true);

            _robot.Move("_canvas", 60, 80, 320, 450);

            string[] data2 = { "刪除", "矩形", "(20, 30), (60, 140)" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 1, data2);

            _robot.ClickButtonByName("lineButton");
            _robot.AssertEnable("lineButton", true);

            _robot.Move("_canvas", 60, 80, 320, 450);

            string[] data3 = { "刪除", "圓形", "(60, 80), (120, 540)" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 2, data3);
        }

        [TestMethod()]
        public void UndoAndRedoTest()
        {
            _robot.ClickButtonByName("circleButton");

            _robot.Move("_canvas", 60, 80, 320, 450);

            _robot.ClickButtonByName("undoButton");

            _robot.ClickButtonByName("redoButton");

            string[] data1 = { "刪除", "圓形", "(60, 80), (320, 450)" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data1);
        }

        // test
        [TestMethod()]
        public void DataGridViewLineTest()
        {
            _robot.ClickButtonByName("開啟");
            _robot.ClickButtonByName("線");
            _robot.ClickButtonByName("新增");
            _robot.SwitchTo("AddShapeForm");
            _robot.InputText("_leftUpXTextBox", "20");
            _robot.InputText("_leftUpYTextBox", "30");
            _robot.InputText("_rightDownXTextBox", "60");
            _robot.InputText("_rightDownYTextBox", "140");
            _robot.ClickButtonByAccessibilityId("_okButton");
            _robot.SwitchTo("HW7");
        }

        // test
        [TestMethod()]
        public void DataGridViewCircleTest()
        {
            _robot.ClickButtonByName("開啟");
            _robot.ClickButtonByName("圓形");
            _robot.ClickButtonByName("新增");
            _robot.SwitchTo("AddShapeForm");
            _robot.InputText("_leftUpXTextBox", "20");
            _robot.InputText("_leftUpYTextBox", "30");
            _robot.InputText("_rightDownXTextBox", "60");
            _robot.InputText("_rightDownYTextBox", "140");
            _robot.ClickButtonByAccessibilityId("_okButton");
            _robot.SwitchTo("HW7");
        }

        // test
        [TestMethod()]
        public void DataGridViewRectangleTest()
        {
            _robot.ClickButtonByName("開啟");
            _robot.ClickButtonByName("矩形");
            _robot.ClickButtonByName("新增");
            _robot.SwitchTo("AddShapeForm");
            _robot.InputText("_leftUpXTextBox", "20");
            _robot.InputText("_leftUpYTextBox", "30");
            _robot.InputText("_rightDownXTextBox", "60");
            _robot.InputText("_rightDownYTextBox", "140");
            _robot.ClickButtonByAccessibilityId("_okButton");
            _robot.SwitchTo("HW7");
        }

        // test
        [TestMethod()]
        public void MoveShapeTest()
        {
            _robot.ClickButtonByName("circleButton");
            _robot.Move("_canvas", 60, 80, 140, 180);
            _robot.Move("_canvas", 80, 140, 210, 540);

            Thread.Sleep(3000);
            string[] data = { "刪除", "圓形", "(190, 480), (270, 580)" };
            _robot.AssertDataGridViewRowDataBy("_shapeDataGridView", 0, data);
        }

        // test
        [TestMethod()]
        public void AdjustForm()
        {
            _robot.Move("Form", 1420, 753, 1500, 1020);
            _robot.AssertSize("Form", 1032, 1499);
        }

        // test
        [TestMethod()]
        public void AddPageAndDeletePageForm()
        {
            _robot.ClickButtonByName("addPageButton");
            Thread.Sleep(3000);

            _robot.AssertDataGridViewRowCountBy("_shapeDataGridView", 1);
        }

        // test
        [TestCleanup()]
        public void FormTestCleanUp()
        {
            _robot.CleanUp();
        }
    }
}
