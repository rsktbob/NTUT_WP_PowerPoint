using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Power_Point
{
    public class Pages
    {
        public int CurrentPageIndex
        {
            get;
            private set;
        }

        // Get current shape manager
        public BindingList<Shape> CurrentShapeManager
        {
            get
            {
                return PageManager[CurrentPageIndex].ShapeManager;
            }
        }

        // Get current shapes
        public Shapes CurrentShapes
        {
            get
            {
                return PageManager[CurrentPageIndex];
            }
        }

        // Get current select shape index
        public int CurrentPageSelectedShapeIndex
        {
            get
            {
                return PageManager[CurrentPageIndex].SelectedShapeIndex;
            }
        }

        // Get page manager
        public List<Shapes> PageManager
        {
            get;
            private set;
        }

        public Pages()
        {
            PageManager = new List<Shapes>();
            PageManager.Add(new Shapes());
            CurrentPageIndex = 0;
        }

        // Move current page shape
        public void MoveCurrentPageShape(int index, int pointX, int pointY)
        {
            PageManager[CurrentPageIndex].MoveShape(index, pointX, pointY);
        }

        // Insert page
        public void InsertPage(int index, Shapes shapes)
        {
            PageManager.Insert(index, shapes);
            CurrentPageIndex = index;
        }

        // Delete page
        public void DeletePage(int index)
        {
            PageManager.RemoveAt(index);
            CurrentPageIndex = index >= 1 ? index - 1 : index;
        }

        // Set current page index
        public void SetCurrentPageIndex(int index)
        {
            CurrentPageIndex = index;
        }

        // Load file data
        public void LoadFileData(List<List<Shape>> fileData)
        {
            PageManager.Clear();
            for (int i = 0; i < fileData.Count; i++)
            {
                Shapes shapes = new Shapes();
                for (int j = 0; j < fileData[i].Count; j++)
                {
                    shapes.AddShape(fileData[i][j]);
                }
                PageManager.Add(shapes);
            }
            SetCurrentPageIndex(0);
        }
    }
}
