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
    /// Window05.xaml 的交互逻辑
    /// </summary>
    public partial class Window05 : Window
    {
        public Window05()
        {
            InitializeComponent();
        }

        private void Window05_OnLoaded(object sender, RoutedEventArgs e)
        {
//            ListBoxItem item = new ListBoxItem()
//                {
//                    Content = "123"
//                };
//
//            canvas.Children.Add(item);

//            DispatcherTimer timer = new DispatcherTimer(
//                TimeSpan.FromSeconds(0.3),
//                DispatcherPriority.Normal,
//                (o, args) =>
//                    {
//                        funnyItemsPanel.Children.Add(new FunnyItemControl());
//                    },
//                this);


            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            funnyItemsPanel.Children.Add(new FunnyItemControl());
        }

        private void FunnyItemsPanel_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            e.Handled = true;
        }
    }
}
