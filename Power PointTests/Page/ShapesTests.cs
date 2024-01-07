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
    public class ShapesTests
    {
        // Shape constructor test
        [TestMethod()]
        public void ShapesTest()
        {
            Shapes shapes = new Shapes();
            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }

        // Add shape test
        [TestMethod()]
        public void AddShapeTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(0, 0, 0, 0);
            
            shapes.AddShape(shape);
            
            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Delete shape test
        [TestMethod()]
        public void DeleteShapeTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(0, 0, 0, 0);
            
            shapes.AddShape(shape);
            
            Assert.AreEqual(1, shapes.ShapeManager.Count);

            shapes.DeleteShape(-1);
            
            Assert.AreEqual(1, shapes.ShapeManager.Count);

            shapes.DeleteShape(0);
            
            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }

        // Insert test
        [TestMethod()]
        public void InsertShapeTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(0, 0, 0, 0));
            shapes.AddShape(new Rectangle(0, 0, 0, 0));

            shapes.InsertShape(0, new Circle(20, 30, 80, 140));
            Shape ResultShape = shapes.ShapeManager[0];

            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(30, ResultShape.PointY1);
            Assert.AreEqual(80, ResultShape.PointX2);
            Assert.AreEqual(140, ResultShape.PointY2);
        }

        // Pop test
        [TestMethod()]
        public void PopShapeTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(20, 30, 60, 140));
            shapes.AddShape(new Rectangle(0, 0, 0, 0));

            shapes.PopShape();
            Shape ResultShape = shapes.ShapeManager[0];

            Assert.AreEqual(20, ResultShape.PointX1);
            Assert.AreEqual(30, ResultShape.PointY1);
            Assert.AreEqual(60, ResultShape.PointX2);
            Assert.AreEqual(140, ResultShape.PointY2);
        }

        // Move test
        [TestMethod()]
        public void MoveShapeTest()
        {
            Shape shape = new Circle(20, 30, 60, 140);
            shape.IsSelected = true;
            Shapes shapes = new Shapes();
            shapes.AddShape(shape);

            shapes.MoveShape(0, 50, 200);

            Assert.AreEqual(50, shape.PointX1);
            Assert.AreEqual(200, shape.PointY1);
            Assert.AreEqual(90, shape.PointX2);
            Assert.AreEqual(310, shape.PointY2);
        }

        // Scale test
        [TestMethod()]
        public void ScaleShapeTest()
        {
            Shape shape = new Circle(20, 30, 60, 140);
            shape.IsSelected = true;
            Shapes shapes = new Shapes();
            shapes.AddShape(shape);

            shapes.ScaleShape(0, 80, 180);

            Assert.AreEqual(20, shape.PointX1);
            Assert.AreEqual(30, shape.PointY1);
            Assert.AreEqual(80, shape.PointX2);
            Assert.AreEqual(180, shape.PointY2);
        }

        // Draw test
        [TestMethod()]
        public void DrawTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(30, 60, 140, 180));
            shapes.AddShape(new Circle(30, 50, 150, 210));
            shapes.AddShape(new Circle(50, 80, 140, 180));
            FormGraphicsAdapter graphics = new FormGraphicsAdapter(null);

            shapes.Draw(graphics, 1);
        }

        // Check point in shapes test
        [TestMethod()]
        public void CheckPointPressInShapesTest()
        {
            Shapes shapes = new Shapes();
            Shape shape = new Circle(20, 20, 300, 300);
            shapes.AddShape(shape);

            shapes.CheckPointPressInShapes(14, 18);
            
            Assert.AreEqual(-1, shapes.SelectedShapeIndex);

            shapes.CheckPointPressInShapes(30, 180);
            
            Assert.AreEqual(0, shapes.SelectedShapeIndex);

            shapes.CheckPointPressInShapes(350, 650);
            
            Assert.AreEqual(-1, shapes.SelectedShapeIndex);
        }

        // Check point enter selected shape test
        [TestMethod()]
        public void CheckPointEnterSelectedShapeCornerTest()
        {
            Shapes shapes = new Shapes();
            Shape circle = new Circle(20, 20, 300, 300);
            circle.IsSelected = true;

            shapes.AddShape(circle);

            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(20, 30));
            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(300, 14));
            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(600, 14));
            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(14, 300));
            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(14, 600));
            Assert.IsFalse(shapes.CheckPointEnterSelectedShapeCorner(8, 14));
            Assert.IsTrue(shapes.CheckPointEnterSelectedShapeCorner(300, 300));
        }
    }
}