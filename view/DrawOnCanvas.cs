using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace goniometer.view
{
    class DrawOnCanvas
    {

        private Canvas canvas;
        private double radiusPoint = 10;


        public DrawOnCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }


        public void touching(Point point)
        {
            drawLineTo(point);

            drawPoint(point);
        }


        private void drawPoint(Point point)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.BlueViolet);
            ellipse.Width = radiusPoint;
            ellipse.Height = radiusPoint;
            Canvas.SetLeft(ellipse, point.X - radiusPoint / 2);
            Canvas.SetTop(ellipse, point.Y - radiusPoint / 2);
            canvas.Children.Add(ellipse);
        }

        private void drawLineTo(Point point)
        {
            Line line = new Line();
            line.Stroke = new SolidColorBrush(Colors.BlueViolet);
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = canvas.Width / 2;
            line.Y2 = canvas.Height;
            canvas.Children.Add(line);
        }

    }
}
