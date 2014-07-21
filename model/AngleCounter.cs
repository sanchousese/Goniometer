﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace goniometer.model
{
    class AngleCounter
    {
        public static double calculateAngle(Point first, Point middle, Point second)
        {
            Point alphaVector = new Point(first.X - middle.X, first.Y - middle.Y);
            Point betaVector = new Point(second.X - middle.X, second.Y - middle.Y);

            return RadianToDegree(Math.Acos(productVectors(alphaVector, betaVector) / (vectorLength(alphaVector) * vectorLength(betaVector))));
        }

        public static double calculateAngle(Point first, Canvas canvas)
        {
            Point middle = new Point(canvas.Width / 2, canvas.Height);
            Point second = new Point(0, canvas.Height);

            return calculateAngle(first, middle, second);
        }

        private static double productVectors(Point alphaVector, Point betaVector)
        {
            return alphaVector.X * betaVector.X + alphaVector.Y * betaVector.Y;
        }

        private static double RadianToDegree(double angle)
        {
            return Math.Round(angle * (180.0 / Math.PI), 2);
        }

        private static double vectorLength(Point vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }
    }
}