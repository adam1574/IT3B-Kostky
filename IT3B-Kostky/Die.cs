using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.Windows;

namespace IT3B_Kostky
{
    public class Die
    {
        private static Random random = new Random();
        private double x;
        private double y;
        private double size;
        private int value;

        public Die(double x, double y, double size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            Roll();
        }

        public void Roll()
        {
            value = random.Next(1, 7);
        }

        public int Value
        {
            get { return value; }
        }

        public UIElement[] GetDrawingElements()
        {
            UIElement[] elements = new UIElement[8];

            Rectangle rect = new Rectangle
            {
                Width = size,
                Height = size,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.White
            };
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            elements[0] = rect;

            double dotSize = size / 6;
            double halfSize = size / 2;
            double quarterSize = size / 4;

            Action<double, double, int> drawDot = (dx, dy, index) =>
            {
                Ellipse dot = new Ellipse
                {
                    Width = dotSize,
                    Height = dotSize,
                    Fill = Brushes.Black
                };
                Canvas.SetLeft(dot, x + dx - dotSize / 2);
                Canvas.SetTop(dot, y + dy - dotSize / 2);
                elements[index] = dot;
            };

            switch (value)
            {
                case 1:
                    drawDot(halfSize, halfSize, 1);
                    break;
                case 2:
                    drawDot(quarterSize, quarterSize, 1);
                    drawDot(3 * quarterSize, 3 * quarterSize, 2);
                    break;
                case 3:
                    drawDot(quarterSize, quarterSize, 1);
                    drawDot(halfSize, halfSize, 2);
                    drawDot(3 * quarterSize, 3 * quarterSize, 3);
                    break;
                case 4:
                    drawDot(quarterSize, quarterSize, 1);
                    drawDot(3 * quarterSize, quarterSize, 2);
                    drawDot(quarterSize, 3 * quarterSize, 3);
                    drawDot(3 * quarterSize, 3 * quarterSize, 4);
                    break;
                case 5:
                    drawDot(quarterSize, quarterSize, 1);
                    drawDot(3 * quarterSize, quarterSize, 2);
                    drawDot(quarterSize, 3 * quarterSize, 3);
                    drawDot(3 * quarterSize, 3 * quarterSize, 4);
                    drawDot(halfSize, halfSize, 5);
                    break;
                case 6:
                    drawDot(quarterSize, quarterSize, 1);
                    drawDot(3 * quarterSize, quarterSize, 2);
                    drawDot(quarterSize, 3 * quarterSize, 3);
                    drawDot(3 * quarterSize, 3 * quarterSize, 4);
                    drawDot(quarterSize, halfSize, 5);
                    drawDot(3 * quarterSize, halfSize, 6);
                    break;
            }

            return elements;
        }
    }
}
