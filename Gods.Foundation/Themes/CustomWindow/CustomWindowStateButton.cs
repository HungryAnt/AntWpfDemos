using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gods.Foundation
{
    public class CustomWindowStateButton : Button
    {
        static CustomWindowStateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (CustomWindowStateButton),
                                                     new FrameworkPropertyMetadata(typeof (CustomWindowStateButton)));
        }

        public Brush BackgroundHoverBrush
        {
            get { return (Brush)GetValue(BackgroundHoverBrushProperty); }
            set { SetValue(BackgroundHoverBrushProperty, value); }
        }

        public static readonly DependencyProperty BackgroundHoverBrushProperty =
            DependencyProperty.Register("BackgroundHoverBrush", typeof(Brush), typeof(CustomWindowStateButton));




        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CustomWindowStateButton));

        
    }
}
