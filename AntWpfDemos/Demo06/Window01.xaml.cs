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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo06
{
    /// <summary>
    /// Window01.xaml 的交互逻辑
    /// </summary>
    public partial class Window01 : Window
    {
        public Window01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation()
                {
                    From = button1.ActualWidth,
                    To = Width - 30,
                    Duration = TimeSpan.FromSeconds(0.3),
                    //FillBehavior = FillBehavior.Stop,
                    AutoReverse = true,
                    AccelerationRatio = 0.3, // 前30%时间加速
                    DecelerationRatio = 0.3, // 后30%时间减速
                    RepeatBehavior = new RepeatBehavior(2)
                };

//            DoubleAnimation heightAnimation = new DoubleAnimation()
//                {
//                    From = button1.ActualHeight,
//                    To = Height - 50,
//                    Duration = TimeSpan.FromSeconds(0.5),
//                    AutoReverse = true,
//                    BeginTime = TimeSpan.FromSeconds(0.3)
//                };

            widthAnimation.Completed += new EventHandler(widthAnimation_Completed);
            button1.BeginAnimation(Button.WidthProperty, widthAnimation);
//            button1.BeginAnimation(Button.HeightProperty, heightAnimation);
        }

        void widthAnimation_Completed(object sender, EventArgs e)
        {
            //button1.Width = 30;
            //button1.BeginAnimation(Button.WidthProperty, null);
        }
    }
}
