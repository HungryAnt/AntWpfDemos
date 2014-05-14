using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Demo06
{
    class FunnyItemsPanel : Canvas
    {
        private const double LARGE_CIRCLE_RADIUS = 300;
        private const int ROUND_ITEMSCOUNT = 24;
        private const double UNIT_ANGLE = 360.0/ROUND_ITEMSCOUNT;
        private double _itemRadius;
        private double _itemWidth;
        private double _itemDistance;  // 主圆心到item圆心的长度
        private double _currentMainCircleRadius;
        private double _currentAngle = 270;
        private int _itemsCount = 0;

        private static double Sin(double angle)
        {
            return Math.Sin(angle/180*Math.PI);
        }

        private static double Cos(double angle)
        {
            return Math.Cos(angle / 180 * Math.PI);
        }

        public FunnyItemsPanel()
        {
            _currentMainCircleRadius = LARGE_CIRCLE_RADIUS;
            Caculate();
        }

        private void Caculate()
        {
            // 小圆半径 = 大圆半径 * cos(a)
            _itemRadius = _currentMainCircleRadius * Sin(UNIT_ANGLE / 2);
            _itemWidth = _itemRadius * 2;
            _itemDistance = _currentMainCircleRadius * Cos(UNIT_ANGLE / 2);
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            var uiElement = visualAdded as UIElement;

            uiElement.SetValue(FrameworkElement.WidthProperty, _itemWidth);
            uiElement.SetValue(FrameworkElement.HeightProperty, _itemWidth);


            double itemCenterX = _itemDistance*Cos(_currentAngle) + LARGE_CIRCLE_RADIUS;
            double itemCenterY = _itemDistance*Sin(_currentAngle) + LARGE_CIRCLE_RADIUS;

            double itemLeft = itemCenterX - _itemRadius;
            double itemTop = itemCenterY - _itemRadius;

            DoubleAnimation xLocAnimation = new DoubleAnimation()
                {
                    From = LARGE_CIRCLE_RADIUS - _itemRadius,
                    To = itemLeft,
                    Duration = TimeSpan.FromSeconds(0.3),
                    AccelerationRatio = 1, // 始终加速
                };

            DoubleAnimation yLocAnimation = new DoubleAnimation()
                {
                    From = LARGE_CIRCLE_RADIUS - _itemRadius,
                    To = itemTop,
                    Duration = TimeSpan.FromSeconds(0.3),
                    AccelerationRatio = 1,
                };

            uiElement.BeginAnimation(Canvas.LeftProperty, xLocAnimation);
            uiElement.BeginAnimation(Canvas.TopProperty, yLocAnimation);

//            SetLeft(uiElement, itemCenterX);
//            SetTop(uiElement, itemCenterY);

            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            _currentAngle -= UNIT_ANGLE;
            ++_itemsCount;

            if (_itemsCount % ROUND_ITEMSCOUNT == 0)
            {
                _currentMainCircleRadius -= _itemRadius;
                Caculate();
            }
        }
    }
}
