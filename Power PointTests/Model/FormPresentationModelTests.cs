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
    public class FormPresentationModelTests
    {
        private FormPresentationModel _formPresentationModel;
        private Model _model = new Model();

        // FormPresentationModel test initialize
        [TestInitialize]
        public void FormPresentationModelTestInitialize()
        {
            _model = new Model();
            _formPresentationModel = new FormPresentationModel(_model);
            _formPresentationModel.UpdateCanvasSize(980, 665);
            _formPresentationModel.UpdatePagesSize(160);
        }

        // FormPresentationModel constructor test
        [TestMethod()]
        public void FormPresentationModelTest()
        {
            Assert.IsFalse(_formPresentationModel.LineChecked);
            Assert.IsFalse(_formPresentationModel.CircleChecked);
            Assert.IsFalse(_formPresentationModel.RectangleChecked);
            Assert.IsFalse(_formPresentationModel.PaintState);
            Assert.IsFalse(_formPresentationModel.IsScaling);
            Assert.IsFalse(_formPresentationModel.RedoEnable);
            Assert.IsFalse(_formPresentationModel.UndoEnable);
            Assert.IsTrue(_formPresentationModel.GeneralChecked);
            Assert.IsNull(_formPresentationModel.ModelChanged);

            _formPresentationModel.ModelChanged += () => { };

            Assert.IsNotNull(_formPresentationModel.ModelChanged);
        }

        // Add shape test
        [TestMethod()]
        public void AddShapeTest()
        {
            _formPresentationModel.AddShape(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);
        }

        // Delete Shape test
        [TestMethod()]
        public void DeleteShapeTest()
        {
            _formPresentationModel.AddShape(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);

            _formPresentationModel.DeleteShape(0);

            Assert.AreEqual(0, _formPresentationModel.CurrentShapeManager.Count);
        }

        // Cancel all state test
        [TestMethod()]
        public void SetStateTest()
        {
            _formPresentationModel.SetState(Symbol.LINE);

            Assert.IsTrue(_formPresentationModel.LineChecked);
            Assert.IsFalse(_formPresentationModel.CircleChecked);
            Assert.IsFalse(_formPresentationModel.RectangleChecked);
            Assert.IsTrue(_formPresentationModel.PaintState);
            Assert.IsFalse(_formPresentationModel.GeneralChecked);

            _formPresentationModel.SetState(Symbol.CIRCLE);

            Assert.IsFalse(_formPresentationModel.LineChecked);
            Assert.IsTrue(_formPresentationModel.CircleChecked);
            Assert.IsFalse(_formPresentationModel.RectangleChecked);
            Assert.IsTrue(_formPresentationModel.PaintState);
            Assert.IsFalse(_formPresentationModel.GeneralChecked);

            _formPresentationModel.SetState(Symbol.RECTANGLE);

            Assert.IsFalse(_formPresentationModel.LineChecked);
            Assert.IsFalse(_formPresentationModel.CircleChecked);
            Assert.IsTrue(_formPresentationModel.RectangleChecked);
            Assert.IsTrue(_formPresentationModel.PaintState);
            Assert.IsFalse(_formPresentationModel.GeneralChecked);

            _formPresentationModel.SetState(Symbol.GENERAL);

            Assert.IsFalse(_formPresentationModel.LineChecked);
            Assert.IsFalse(_formPresentationModel.CircleChecked);
            Assert.IsFalse(_formPresentationModel.RectangleChecked);
            Assert.IsFalse(_formPresentationModel.PaintState);
            Assert.IsTrue(_formPresentationModel.GeneralChecked);
        }

        // Handele point pressed test
        [TestMethod()]
        public void HandlePointerPressedTest()
        {
            _formPresentationModel.SetState(Symbol.LINE);
            Shape ResultShape = (Shape)GetPrivateField(_model, "_hint");
            _formPresentationModel.HandlePointerPressed(-1, -1);

            Assert.AreEqual(0, ResultShape.PointX1);
            Assert.AreEqual(0, ResultShape.PointY1);
            Assert.AreEqual(0, ResultShape.PointX2);
            Assert.AreEqual(0, ResultShape.PointY2);

            _formPresentationModel.HandlePointerPressed(1, 3);

            Assert.AreEqual(1, ResultShape.PointX1);
            Assert.AreEqual(3, ResultShape.PointY1);
            Assert.AreEqual(1, ResultShape.PointX2);
            Assert.AreEqual(3, ResultShape.PointY2);
        }

        // Handele point moved test
        [TestMethod()]
        public void HandlePointerMovedTest()
        {
            _formPresentationModel.SetState(Symbol.LINE);
            Shape ResultShape = (Shape)GetPrivateField(_model, "_hint");
            _formPresentationModel.HandlePointerPressed(20, 120);
            _formPresentationModel.HandlePointerMoved(30, 180);
            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(120, ResultShape.PointY1);
            Assert.AreEqual(30, ResultShape.PointX2);
            Assert.AreEqual(180, ResultShape.PointY2);

            _formPresentationModel.HandlePointerReleased(60, 210);
            _formPresentationModel.SetState(Symbol.GENERAL);
            _formPresentationModel.HandlePointerPressed(30, 180);
            _formPresentationModel.HandlePointerReleased(30, 180);
            _formPresentationModel.HandlePointerMoved(60, 210);

            Assert.IsTrue(_model.IsScaling);
        }

        // Handele point released test
        [TestMethod()]
        public void HandlePointerReleasedTest()
        {
            _formPresentationModel.SetState(Symbol.LINE);
            _formPresentationModel.HandlePointerPressed(1, 3);
            _formPresentationModel.HandlePointerReleased(3, 6);

            Shape ResultShape = _model.CurrentShapeManager[0];
            Assert.IsInstanceOfType(ResultShape, typeof(Line));
            Assert.AreEqual(1, ResultShape.PointX1);
            Assert.AreEqual(3, ResultShape.PointY1);
            Assert.AreEqual(3, ResultShape.PointX2);
            Assert.AreEqual(6, ResultShape.PointY2);
        }

        // Draw canvas test
        [TestMethod()]
        public void DrawCanvasTest()
        {
            FormPresentationModel formPresentationModel = new FormPresentationModel(new Model());
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            formPresentationModel.DrawCanvas(graphics);
        }

        // Draw small canvas test
        [TestMethod()]
        public void DrawSmallCanvasTest()
        {
            FormPresentationModel formPresentationModel = new FormPresentationModel(new Model());
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            formPresentationModel.DrawPage(0, graphics);
        }

        // Press delete test
        [TestMethod()]
        public void DeleteSelectedShapeTest()
        {
            _formPresentationModel.SetState(Symbol.CIRCLE);
            _formPresentationModel.HandlePointerPressed(6, 21);
            _formPresentationModel.HandlePointerReleased(65, 140);
            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);

            _formPresentationModel.HandlePointerPressed(18, 30);
            _formPresentationModel.HandlePointerReleased(18, 30);

            _formPresentationModel.PressDelete();
            Assert.AreEqual(0, _formPresentationModel.CurrentShapeManager.Count);
        }

        // Undo test
        [TestMethod()]
        public void UndoTest()
        {
            _formPresentationModel.AddShape(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);

            _formPresentationModel.Undo();

            Assert.AreEqual(0, _formPresentationModel.CurrentShapeManager.Count);
        }

        // Redo Test

        // Undo test
        [TestMethod()]
        public void RedoTest()
        {
            _formPresentationModel.AddShape(Symbol.CIRCLE, new Point(3, 21), new Point(6, 54));

            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);

            _formPresentationModel.Undo();

            Assert.AreEqual(0, _formPresentationModel.CurrentShapeManager.Count);

            _formPresentationModel.Redo();

            Assert.AreEqual(1, _formPresentationModel.CurrentShapeManager.Count);
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