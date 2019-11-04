using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SignalR_WpfApp.MessageManager;

namespace SignalR_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HubClient hubClient;

        public MainWindow()
        {
            InitializeComponent();
            MessageManager.Instance.ExportEventHander += Message;
            //listBox1.Background = Brushes.Gray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(testBox1.Text))
            {
                hubClient.SendMessage(testBox1.Text);
            }
        }

        #region 消息
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Message(object sender, MessageEventArgs e)
        {
            TextBlock tb = new TextBlock();
            tb.Text = e.Message;
            tb.Foreground = new SolidColorBrush(Color.FromArgb(e.Color.A, e.Color.R, e.Color.G, e.Color.B));
            this.listBox1.Items.Add(tb);
            //listBox1.SelectedIndex = listBox1.Items.Count - 1;选中最后一行
            listBox1.ScrollIntoView(listBox1.Items[listBox1.Items.Count - 1]);//跳转到最新的数据（自动往下翻）
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hubClient = new HubClient();
            hubClient.connectButton();
        }
    }
}
