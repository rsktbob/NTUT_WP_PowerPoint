using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Power_Point
{
    public class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected int _pointX1;
        protected int _pointY1;
        protected int _pointX2;
        protected int _pointY2;
        protected double _ratio = 1;

        // Shape constructor
        public Shape(int pointX1, int pointY1, int pointX2, int pointY2)
        {
            _pointX1 = pointX1;
            _pointY1 = pointY1;
            _pointX2 = pointX2;
            _pointY2 = pointY2;
        }

        // Get shape name
        public virtual string ShapeName
        {
            get 
            { 
                return Symbol.SHAPE; 
            }
        }

        // Get information
        public string Info
        {
            get 
            {
                return Symbol.LEFT_BRACKET + _pointX1.ToString() + Symbol.COMMA + _pointY1.ToString() + Symbol.RIGHT_BRACKET + Symbol.COMMA + Symbol.SPACE + Symbol.LEFT_BRACKET +
                    _pointX2.ToString() + Symbol.COMMA + _pointY2.ToString() + Symbol.RIGHT_BRACKET;
            }
        }

        // Get point x1
        [Browsable(false)]
        public int PointX1
        {
            get
            {
                return _pointX1;
            }
            set
            {
                _pointX1 = value;
                NotifyPropertyChanged(Symbol.INFO_ENGLISH);
            }
        }

        // Get point x2
        [Browsable(false)]
        public int PointX2
        {
            get
            {
                return _pointX2;
            }
            set
            {
                _pointX2 = value;
                NotifyPropertyChanged(Symbol.INFO_ENGLISH);
            }
        }

        // Get point y1
        [Browsable(false)]
        public int PointY1
        {
            get
            {
                return _pointY1;
            }
            set
            {
                _pointY1 = value;
                NotifyPropertyChanged(Symbol.INFO_ENGLISH);
            }
        }

        // Get point y2
        [Browsable(false)]
        public int PointY2
        {
            get
            {
                return _pointY2;
            }
            set
            {
                _pointY2 = value;
                NotifyPropertyChanged(Symbol.INFO_ENGLISH);
            }
        }

        // Get paint point x1
        [Browsable(false)]
        public int PaintPointX1
        {
            get
            {
                return (int)(_pointX1 * _ratio);
            }
        }

        // Get paint point x2
        [Browsable(false)]
        public int PaintPointX2
        {
            get
            {
                return (int)(_pointX2 * _ratio);
            }
        }

        // Get paint point y1
        [Browsable(false)]
        public int PaintPointY1
        {
            get
            {
                return (int)(_pointY1 * _ratio);
            }
        }

        // Get paint point y2
        [Browsable(false)]
        public int PaintPointY2
        {
            get
            {
                return (int)(_pointY2 * _ratio);
            }
        }

        // Get IsSelected
        [Browsable(false)]
        public bool IsSelected
        {
            get; set;
        }

        // Draw
        public virtual void Draw(IGraphics graphics, double ratio)
        {

        }

        // Move shape
        public void Move(int pointX, int pointY)
        {
            int width = _pointX2 - _pointX1;
            int height = _pointY2 - PointY1;
            _pointX1 = pointX;
            _pointY1 = pointY;
            _pointX2 = _pointX1 + width;
            _pointY2 = _pointY1 + height;
        }

        // Scale shape
        public void Scale(int pointX, int pointY)
        {
            _pointX2 = pointX;
            _pointY2 = pointY;
        }

        // Notify property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
