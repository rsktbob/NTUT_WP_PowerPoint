using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Power_Point.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        // DrawingState constructor test
        [TestMethod()]
        public void DrawingStateTest()
        {
            DrawingState drawingState = new DrawingState(new Model(), new Shapes(), new Shape(0, 0, 0, 0));

            Shapes ResultShapes = (Shapes)GetPrivateField(drawingState, "_shapes");
            Shape ResultHint = (Shape)GetPrivateField(drawingState, "_hint");

            Assert.AreEqual(0, ResultShapes.ShapeManager.Count);
            Assert.AreEqual(0, ResultHint.PointX1);
            Assert.AreEqual(0, ResultHint.PointY1);
            Assert.AreEqual(0, ResultHint.PointX2);
            Assert.AreEqual(0, ResultHint.PointY2);
        }

        // Mouse move test
        [TestMethod()]
        public void HandleMouseMoveTest()
        {
            DrawingState drawingState = new DrawingState(new Model(), new Shapes(), new Circle(0, 0, 0, 0));
            Shape ResultHint = (Shape)GetPrivateField(drawingState, "_hint");

            drawingState.HandleMouseMove(60, 210);

            Assert.AreEqual(0, ResultHint.PointX1);
            Assert.AreEqual(0, ResultHint.PointY1);
            Assert.AreEqual(0, ResultHint.PointX2);
            Assert.AreEqual(0, ResultHint.PointY2);

            drawingState.HandleMouseDown(120, 120);
            drawingState.HandleMouseMove(180, 210);

            Assert.AreEqual(120, ResultHint.PointX1);
            Assert.AreEqual(120, ResultHint.PointY1);
            Assert.AreEqual(180, ResultHint.PointX2);
            Assert.AreEqual(210, ResultHint.PointY2);
        }

        // Mouse Down test
        [TestMethod()]
        public void HandleMouseDownTest()
        {
            DrawingState drawingState = new DrawingState(new Model(), new Shapes(), new Circle(0, 0, 0, 0));
            Shape ResultHint = (Shape)GetPrivateField(drawingState, "_hint");

            drawingState.HandleMouseDown(60, 210);

            Assert.IsTrue((bool)GetPrivateField(drawingState, "_isPressed"));
            Assert.AreEqual(60, ResultHint.PointX1);
            Assert.AreEqual(210, ResultHint.PointY1);
            Assert.AreEqual(60, ResultHint.PointX2);
            Assert.AreEqual(210, ResultHint.PointY2);
        }

        // Mouse Release test
        [TestMethod()]
        public void HandleMouseUpTest()
        {
            DrawingState drawingState = new DrawingState(new Model(), new Shapes(), new Circle(0, 0, 0, 0));
            Shape ResultHint = (Shape)GetPrivateField(drawingState, "_hint");

            drawingState.HandleMouseUp(140, 260);
            
            Assert.IsFalse((bool)GetPrivateField(drawingState, "_isPressed"));

            drawingState.HandleMouseDown(140, 260);
            drawingState.HandleMouseUp(140, 260);

            Assert.IsFalse((bool)GetPrivateField(drawingState, "_isPressed"));
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