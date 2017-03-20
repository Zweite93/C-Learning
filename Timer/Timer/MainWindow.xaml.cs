using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentSecond;
        public MainWindow()
        {
            InitializeComponent();
            currentSecond = 0;
            var timer = new System.Threading.Timer(AddSecond, new AutoResetEvent(false), 0, 1000);
        }

        private void AddSecond(Object stateInfo)
        {
            this.timerTextBlock.Dispatcher.Invoke(() => timerTextBlock.Text = currentSecond.ToString());
            currentSecond++;
        }
    }
}
