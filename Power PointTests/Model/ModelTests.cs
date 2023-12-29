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
            _model.SetCanvasSize(960, 540);
            _model.SetPageSize(160, 90);
        }

        // Model constructor test
        [TestMethod()]
        public void ModelTest()
        {
            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
            Assert.IsFalse(_model.IsScaling);
        }

        // Push add command test
        [TestMethod()]
        public void PushAddCommandTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE);

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);
        }

        // Push delete command test
        [TestMethod()]
        public void PushDeleteCommandTest()
        {
            _model.PushAddCommand(Symbol.RECTANGLE);

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);

            _model.PushDeleteCommand(0);

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
        }

        // Push delete selected command test
        [TestMethod()]
        public void PushDeleteSelectedCommandTest()
        {
            Shape shape = new Circle(20, 30, 140, 180);
            shape.IsSelected = true;

            _model.PushDeleteSelectedCommand();
            _model.AddCurrentPageShape(shape);

            Assert.AreEqual(1, _model.CurrentShapeManager.Count);

            _model.PushDeleteSelectedCommand();

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
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
            Shape shape = new Circle(20, 30, 140, 180);
            shape.IsSelected = true;
            _model.AddCurrentPageShape(shape);
            _model.PushMoveCommand(20, 30, 60, 140);

            Assert.AreEqual(60, shape.PointX1);
            Assert.AreEqual(140, shape.PointY1);
            Assert.AreEqual(180, shape.PointX2);
            Assert.AreEqual(290, shape.PointY2);
        }

        // Add shape test
        [TestMethod()]
        public void AddShapeTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE);
            Shape shape = _model.CurrentShapeManager[0];

            Assert.IsInstanceOfType(shape, typeof(Circle));
            Assert.IsNull(_model.ModelChanged);

            _model.ModelChanged += () => { };
            _model.PushAddCommand(Symbol.CIRCLE);
            Assert.IsNotNull(_model.ModelChanged);
        }

        //Delete shape test
        [TestMethod()]
        public void DeleteShapeTest()
        {
            _model.PushAddCommand(Symbol.CIRCLE);
            Assert.AreEqual(1, _model.CurrentShapeManager.Count);

            _model.DeleteCurrentPageShape(0);
            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
        }

        // Insert shape Test
        [TestMethod()]
        public void InsertShapeTest()
        {
            _model.AddCurrentPageShape(new Circle(0, 0, 0, 0));
            _model.AddCurrentPageShape(new Rectangle(0, 0, 0, 0));
            Shape shape = new Circle(20, 60, 140, 80);

            _model.InsertCurrentPageShape(1, shape);
            Shape ResultShape = _model.CurrentShapeManager[1];

            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(60, ResultShape.PointY1);
            Assert.AreEqual(140, ResultShape.PointX2);
            Assert.AreEqual(80, ResultShape.PointY2);
        }

        // Pop shape test
        [TestMethod()]
        public void PopShapeTest()
        {
            _model.AddCurrentPageShape(new Circle(20, 60, 140, 180));
            _model.AddCurrentPageShape(new Rectangle(0, 0, 0, 0));

            _model.PopCurrentPageShape();
            Shape ResultShape = _model.CurrentShapeManager[0];

            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(60, ResultShape.PointY1);
            Assert.AreEqual(140, ResultShape.PointX2);
            Assert.AreEqual(180, ResultShape.PointY2);
        }

        //Move shape test
        [TestMethod()]
        public void MoveShapeTest()
        {
            Shape shape = new Rectangle(60, 210, 80, 310);
            shape.IsSelected = true;
            _model.AddCurrentPageShape(shape);

            _model.MoveCurrentPageShape(0, 90, 290);

            Assert.AreEqual(90, shape.PointX1);
            Assert.AreEqual(290, shape.PointY1);
            Assert.AreEqual(110, shape.PointX2);
            Assert.AreEqual(390, shape.PointY2);
        }

        // Set Canvas size
        [TestMethod()]
        public void SetCanvasSizeTest()
        {
            _model.SetCanvasSize(500, 600);
            Assert.AreEqual(500, GetPrivateField(_model, "_canvasWidth"));
            Assert.AreEqual(600, GetPrivateField(_model, "_canvasHeight"));

            _model.SetCanvasSize(400, 500);
            Assert.AreEqual(400, GetPrivateField(_model, "_canvasWidth"));
            Assert.AreEqual(500, GetPrivateField(_model, "_canvasHeight"));
        }

        // Set small canvas size
        [TestMethod()]
        public void SetSmallCanvasSizeTest()
        {
            _model.SetPageSize(500, 600);
            Assert.AreEqual(500, GetPrivateField(_model, "_smallCanvasWidth"));
            Assert.AreEqual(600, GetPrivateField(_model, "_smallCanvasHeight"));

            _model.SetPageSize(400, 500);
            Assert.AreEqual(400, GetPrivateField(_model, "_smallCanvasWidth"));
            Assert.AreEqual(500, GetPrivateField(_model, "_smallCanvasHeight"));
        }

        // Draw canvas test
        [TestMethod()]
        public void DrawCanvasTest()
        {
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);
            _model.SetCanvasSize(500, 600);

            _model.DrawCanvas(graphics);

            _model.SetState(Symbol.CIRCLE);

            _model.DrawCanvas(graphics);
        }

        // Draw small canvas test
        [TestMethod()]
        public void DrawSamllCanvasTest()
        {
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);
            _model.SetPageSize(500, 600);

            _model.DrawPage(graphics);

            _model.SetState(Symbol.CIRCLE);

            _model.DrawPage(graphics);
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
            _model.PushAddCommand(Symbol.CIRCLE);

            _model.Undo();

            Assert.AreEqual(0, _model.CurrentShapeManager.Count);
        }

        // Redo test
        [TestMethod()]
        public void RedoTest()
        {
            _model.PushAddCommand(Symbol.RECTANGLE);

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
    }
}