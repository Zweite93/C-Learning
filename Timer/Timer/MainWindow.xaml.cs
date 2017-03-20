using System;
using System.Threading;
using System.Windows;

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
            this.timerTextBlock.Dispatcher.BeginInvoke((Action)(() => timerTextBlock.Text = currentSecond++.ToString()));
        }
    }
}
