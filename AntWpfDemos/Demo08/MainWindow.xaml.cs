using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo08
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnChange_OnClick(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush =
                new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Demo08;component/Images/a2.jpg")))
                    {
                        TileMode = TileMode.Tile,
                        ViewportUnits = BrushMappingMode.Absolute,
                        Viewport = new Rect(0,0,32,32),
                        Opacity = 0.3
                    };

            Resources["TileBrush"] = imageBrush;

        }
    }
}
