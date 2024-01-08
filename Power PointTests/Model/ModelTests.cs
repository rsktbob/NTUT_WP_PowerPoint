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
    public class ModelTests
    {
        private Model _model;

        // Model test initialize
        [TestInitialize]
        public void ModelTestInitialize()
        {
            _model = new Model();
            _model.CanvasSize = new Size(960, 540);
            _model.PageSize = new Size(160, 90);
        }

        // Model constructor test
        [TestMethod()]
        public void ModelTest()
        {
            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
            Assert.IsFalse(_model.IsScaling);
            Assert.AreEqual(0, _model.CurrentPageIndex);
        }

        // Push add command test
        [TestMethod()]
        public void PushAddCommandTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);
        }

        // Push delete command test
        [TestMethod()]
        public void PushDeleteCommandTest()
        {
            _model.PushAddCommand(Symbol.RECTANGLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);

            _model.PushDeleteCommand(0);

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
        }

        // Push delete selected command test
        [TestMethod()]
        public void PushDeleteSelectedCommandTest()
        {
            _model.PushDeleteSelectedCommand();
            _model.PushAddCommand(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);

            Shape shape = _model.CurrentShapeManager[0];
            shape.IsSelected = true;
            _model.PushDeleteSelectedCommand();

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);
        }

        // Push draw command test
        [TestMethod()]
        public void PushDrawCommandTest()
        {
            Shape shape = new Circle(20, 30, 140, 180);
            _model.PushDrawCommand(shape);

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);
        }

        // Push move command test
        [TestMethod()]
        public void PushMoveCommandTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE, new Point(20, 30), new Point(60, 140));
            _model.HandlePointerPressed(50, 60);
            _model.PushMoveCommand(20, 30, 80, 210);

            Shape shape = _model.CurrentShapeManager[0];
            Assert.AreEqual(80, shape.PointX1);
            Assert.AreEqual(210, shape.PointY1);
            Assert.AreEqual(120, shape.PointX2);
            Assert.AreEqual(320, shape.PointY2);
        }

        // Push move command test
        [TestMethod()]
        public void PushScaleCommandTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE, new Point(20, 30), new Point(140, 180));
            Shape shape = _model.CurrentShapeManager[0];

            _model.HandlePointerPressed(50, 60);

            _model.PushScaleCommand(30, 50, 60, 140);

            Assert.AreEqual(20, shape.PointX1);
            Assert.AreEqual(30, shape.PointY1);
            Assert.AreEqual(60, shape.PointX2);
            Assert.AreEqual(140, shape.PointY2);
        }

        // Push insert page command test
        [TestMethod()]
        public void PushInsertPageCommandTest()
        {
            _model.PushInsertPageCommand();

            Assert.AreEqual(2, _model.AllPages.PageCount);
        }

        // Push delete current page command test
        [TestMethod()]
        public void PushDeleteCurrentPageCommand()
        {
            _model.PushInsertPageCommand();
            _model.PushDeleteCurrentPageCommand();

            Assert.AreEqual(1, _model.AllPages.PageCount);
        }

        // Draw canvas test
        [TestMethod()]
        public void DrawCanvasTest()
        {
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            _model.DrawCanvas(graphics);

            _model.SetState(Symbol.CIRCLE);

            _model.DrawCanvas(graphics);
        }

        // Draw small canvas test
        [TestMethod()]
        public void DrawPageTest()
        {
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            _model.DrawPage(0, graphics);

            _model.SetState(Symbol.CIRCLE);

            _model.DrawPage(0, graphics);
        }

        // Set paint state test
        [TestMethod()]
        public void SetStateTest()
        {
            _model.SetState(Symbol.LINE);
            Assert.IsInstanceOfType(GetPrivateField(_model, "_state"), typeof(DrawingState));

            _model.SetState(Symbol.CIRCLE);
            Assert.IsInstanceOfType(GetPrivateField(_model, "_state"), typeof(DrawingState));

            _model.SetState(Symbol.RECTANGLE);
            Assert.IsFalse(_model.IsScaling);
            Assert.IsInstanceOfType(GetPrivateField(_model, "_state"), typeof(DrawingState));

            _model.SetState(Symbol.GENERAL);
            Assert.IsInstanceOfType(GetPrivateField(_model, "_state"), typeof(PointState));
        }

        // Handle pointer pressed test
        [TestMethod()]
        public void HandlePointerPressedTest()
        {
            _model.SetState(Symbol.LINE);
            Shape ResultShape = (Shape)GetPrivateField(_model, "_hint");

            _model.HandlePointerPressed(-1, -1);

            Assert.AreEqual(0, ResultShape.PointX1);
            Assert.AreEqual(0, ResultShape.PointY1);
            Assert.AreEqual(0, ResultShape.PointX2);
            Assert.AreEqual(0, ResultShape.PointY2);

            _model.HandlePointerPressed(1, 3);

            Assert.AreEqual(1, ResultShape.PointX1);
            Assert.AreEqual(3, ResultShape.PointY1);
            Assert.AreEqual(1, ResultShape.PointX2);
            Assert.AreEqual(3, ResultShape.PointY2);
        }

        // Handle pointer moved test
        [TestMethod()]
        public void HandlePointerMovedTest()
        {
            _model.SetState(Symbol.LINE);
            Shape ResultShape = (Shape)GetPrivateField(_model, "_hint");

            _model.HandlePointerPressed(20, 120);
            _model.HandlePointerMoved(30, 180);

            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(120, ResultShape.PointY1);
            Assert.AreEqual(30, ResultShape.PointX2);
            Assert.AreEqual(180, ResultShape.PointY2);

            _model.HandlePointerReleased(60, 210);
            _model.SetState(Symbol.GENERAL);
            _model.HandlePointerPressed(30, 180);
            _model.HandlePointerReleased(30, 180);
            _model.HandlePointerMoved(60, 210);

            Assert.IsTrue(_model.IsScaling);
        }

        // Handle pointer released test
        [TestMethod()]
        public void HandlePointerReleasedTest()
        {
            _model.SetState(Symbol.LINE);
            _model.HandlePointerPressed(1, 3);
            _model.HandlePointerReleased(3, 6);

            Shape ResultShape = _model.CurrentShapeManager[0];
            Assert.IsInstanceOfType(ResultShape, typeof(Line));
            Assert.AreEqual(1, ResultShape.PointX1);
            Assert.AreEqual(3, ResultShape.PointY1);
            Assert.AreEqual(3, ResultShape.PointX2);
            Assert.AreEqual(6, ResultShape.PointY2);
        }

        // Undo test
        [TestMethod()]
        public void UndoTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE, new Point(20, 30), new Point(60, 140));

            _model.Undo();

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
        }

        // Redo test
        [TestMethod()]
        public void RedoTest()
        {
            _model.PushAddCommand(Symbol.RECTANGLE, new Point(20, 30), new Point(60, 140));

            _model.Undo();

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);

            _model.Redo();

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);
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

        [TestMethod()]
        public void PressDeleteTest()
        {
            _model.PressDelete();
            _model.PushInsertPageCommand();
            _model.PressDelete();
        }
    }
}