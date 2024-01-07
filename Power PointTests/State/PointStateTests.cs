using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;

namespace Power_Point.Tests
{
    [TestClass()]
    public class PointStateTests
    {
        // PointState test
        [TestMethod()]
        public void PointStateTest()
        {
            PointState pointState = new PointState(new Model(), new Shapes());

            Shapes ResultShapes = (Shapes)GetPrivateField(pointState, "_shapes");

            Assert.AreEqual(0, ResultShapes.ShapeManager.Count);
        }

        // Mouse move test
        [TestMethod()]
        public void HandleMouseMoveTest()
        {
            Model model = new Model();
            Pages pages = (Pages)GetPrivateField(model, "_pages");
            model.PushAddCommand(Symbol.CIRCLE, new Point(20, 30), new Point(140, 180));
            Shape circle = pages.CurrentShapeManager[0];

            PointState pointState = new PointState(model, pages.CurrentShapes);
            pointState.HandleMouseDown(150, 210);
            pointState.HandleMouseMove(80, 140);

            Assert.AreEqual(20, circle.PointX1);
            Assert.AreEqual(30, circle.PointY1);
            Assert.AreEqual(140, circle.PointX2);
            Assert.AreEqual(180, circle.PointY2);

            pointState.HandleMouseDown(50, 65);
            pointState.HandleMouseMove(80, 140);

            Assert.AreEqual(50, circle.PointX1);
            Assert.AreEqual(105, circle.PointY1);
            Assert.AreEqual(170, circle.PointX2);
            Assert.AreEqual(255, circle.PointY2);

            pointState.HandleMouseUp(80, 140);
            pointState.HandleMouseMove(170, 255);
            pointState.HandleMouseDown(50, 65);
            pointState.HandleMouseMove(190, 275);

            Assert.IsTrue(pointState.IsScaling);
            Assert.AreEqual(190, circle.PointX2);
            Assert.AreEqual(275, circle.PointY2);
        }

        // Mouse Down test
        [TestMethod()]
        public void HandleMouseDownTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(20, 30, 140, 180));
            PointState pointState = new PointState(new Model(), shapes);

            pointState.HandleMouseDown(50, 65);
            Shapes ResultShapes = (Shapes)GetPrivateField(pointState, "_shapes");

            Assert.IsTrue(ResultShapes.ShapeManager[0].IsSelected);
        }

        // Mouse Up test
        [TestMethod()]
        public void HandleMouseUpTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(20, 30, 140, 180));
            PointState pointState = new PointState(new Model(), shapes);

            pointState.HandleMouseUp(140, 180);
            Assert.IsFalse((bool)GetPrivateField(pointState, "_isPressed"));
        }

        // Get private field
        private object GetPrivateField(object obj, string fieldName)
        {
            Type type = obj.GetType();
            FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(obj);
            }
            else
            {
                return null;
            }
        }
    }
}