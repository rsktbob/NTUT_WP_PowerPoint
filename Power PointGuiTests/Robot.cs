using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

namespace Power_Point.GuiTests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButtonByName(string name)
        {
            _driver.FindElementByName(name).Click();
            Thread.Sleep(1000);
        }

        // test
        public void ClickButtonByAccessibilityId(string name)
        {
            _driver.FindElementByAccessibilityId(name).Click();
            Thread.Sleep(1000);
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.IsTrue(Compare(rowDatas[i].Text.Replace("(null)", ""), data[i - 1]));
            }
        }

        // test
        public void InputText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Clipboard.SetText(text);
            element.Click();
            Thread.Sleep(100);
            element.SendKeys(OpenQA.Selenium.Keys.Control + "a" + OpenQA.Selenium.Keys.Delete);
            Thread.Sleep(100);
            element.SendKeys(OpenQA.Selenium.Keys.Control + "v");
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }

        // Move
        public void Move(string name, int pointX1, int pointY1, int pointX2, int pointY2)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Actions action = new Actions(_driver);

            action.MoveToElement(element, pointX1, pointY1).ClickAndHold().MoveByOffset(pointX2 - pointX1, pointY2 - pointY1).Release().Perform();
            Sleep(5);
        }

        // Click position
        public void ClickPosition(string name, int pointX1, int pointY1)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Actions action = new Actions(_driver);

            action.MoveToElement(element, pointX1, pointY1).ClickAndHold().Perform();
            Sleep(5);
        }

        // Assert size
        public void AssertSize(string name, int height, int width)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);

            Assert.AreEqual(element.Size.Width, width);
            Assert.AreEqual(element.Size.Height, height);
        }

        // 他會有誤差pointX1, pointY1, pointX2, pointY2
        bool Compare(string s1, string s2)
        {
            string pattern = @"\((-?\d+), (-?\d+)\), \((-?\d+), (-?\d+)\)";

            Match match1 = Regex.Match(s1, pattern);
            Match match2 = Regex.Match(s2, pattern);
            if (match1.Success && match2.Success)
            {
                int num1 = int.Parse(match1.Groups[1].Value);
                int num2 = int.Parse(match1.Groups[2].Value);
                int num3 = int.Parse(match1.Groups[3].Value);
                int num4 = int.Parse(match1.Groups[4].Value);

                bool compare1 = num1 <= int.Parse(match2.Groups[1].Value) + 1 && num1 >= int.Parse(match2.Groups[1].Value) - 1;
                bool compare2 = num2 <= int.Parse(match2.Groups[2].Value) + 1 && num2 >= int.Parse(match2.Groups[2].Value) - 1;
                bool compare3 = num3 <= int.Parse(match2.Groups[3].Value) + 1 && num3>= int.Parse(match2.Groups[3].Value) - 1;
                bool compare4 = num4 <= int.Parse(match2.Groups[4].Value) + 1 && num4 >= int.Parse(match2.Groups[4].Value) - 1;
                return compare1 && compare2 && compare3 && compare4;
            }
            else
            {
                return true;
            }
        }
    }
}
