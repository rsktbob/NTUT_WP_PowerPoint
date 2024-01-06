using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Power_Point
{
    public class Shapes
    {
        // Get shapesManager
        public BindingList<Shape> ShapeManager
        {
            get;
            private set;
        }

        // Get select shape Index
        public int SelectedShapeIndex
        {
            get;
            private set;
        }

        // Shape constructor
        public Shapes()
        {
            ShapeManager = new BindingList<Shape>();
            SelectedShapeIndex = -1;
        }

        // Add shape
        public void AddShape(Shape shape)
        {
            ShapeManager.Add(shape);
            UpdateSelectedIndex();
        }

        // Delete shape
        public void DeleteShape(int index)
        {
            if (index != -1 && index < ShapeManager.Count)
            {
                ShapeManager.RemoveAt(index);
                UpdateSelectedIndex();
            }
        }

        // Insert shape
        public void InsertShape(int index, Shape shape)
        {
            ShapeManager.Insert(index, shape);
            UpdateSelectedIndex();
        }

        // Pop shape
        public void PopShape()
        {
            ShapeManager.RemoveAt(ShapeManager.Count - 1);
            UpdateSelectedIndex();
        }

        // Move shape
        public void MoveShape(int index, int pointX, int pointY)
        {
            Shape shape = ShapeManager[index];
            shape.Move(pointX, pointY);
        }

        // Scale shape
        public void ScaleShape(int index, int pointX, int pointY)
        {
            Shape shape = ShapeManager[index];
            shape.Scale(pointX, pointY);
        }

        // Draw
        public void Draw(IGraphics graphics, double ratio)
        {
            foreach (Shape shape in ShapeManager)
                shape.Draw(graphics, ratio);
        }

        // Check shape selected
        public void CheckPointPressInShapes(double pointX, double pointY)
        {
            UpdateSelectedIndex();
            if (SelectedShapeIndex != -1)
            {
                ShapeManager[SelectedShapeIndex].IsSelected = false;
                SelectedShapeIndex = -1;
            }
            for (int i = 0; i < ShapeManager.Count; i++)
            {
                if (ShapeManager[i].PointX1 <= pointX && ShapeManager[i].PointX2 >= pointX
                    && ShapeManager[i].PointY1 <= pointY && ShapeManager[i].PointY2 >= pointY)
                {
                    ShapeManager[i].IsSelected = true;
                    SelectedShapeIndex = i;
                    break;
                }
            }
        }

        // Get Selected shape index
        private void UpdateSelectedIndex()
        {
            SelectedShapeIndex = -1;
            for (int i = 0; i < ShapeManager.Count; i++)
            {
                if (ShapeManager[i].IsSelected)
                    SelectedShapeIndex = i;
            }
        }

        // Check point enter selected shape
        public bool CheckPointEnterSelectedShapeCorner(double pointX, double pointY)
        {
            if (SelectedShapeIndex != -1)
            {
                int pointX2 = ShapeManager[SelectedShapeIndex].PointX2;
                int pointY2 = ShapeManager[SelectedShapeIndex].PointY2;
                if (pointX2 - Symbol.EIGHT <= pointX && pointX <= pointX2 + Symbol.EIGHT &&
                    pointY2 - Symbol.EIGHT <= pointY && pointY <= pointY2 + Symbol.EIGHT)
                    return true;
            }
            return false;
        }
    }
}
