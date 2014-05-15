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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Demo06
{
    /// <summary>
    /// Window06.xaml 的交互逻辑
    /// </summary>
    public partial class Window06 : Window
    {
        public Window06()
        {
            InitializeComponent();
        }

        private void Window06_OnLoaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.04);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //listBox.Items.Add(new Button() {Content = "Hello Ant"});
            listBox.Items.Add(new Image()
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Demo06;component/Images/Baidu_256.ico"))
                });
        }
    }
}
