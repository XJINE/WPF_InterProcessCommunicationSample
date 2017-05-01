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

//参照の追加も必要
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace ServerSide
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        IPCData.MidObject midObject;

        public MainWindow()
        {
            InitializeComponent();

            //サーバサイドのチャンネルを生成.
            IpcServerChannel channel = new IpcServerChannel("SampleChannel");
            
            //チャンネルを登録.
            ChannelServices.RegisterChannel(channel, true);

            //やり取りするオブジェクトを生成して登録.
            midObject = new IPCData.MidObject();
            RemotingServices.Marshal(midObject,"OpenData");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //カウントを1増やす
            midObject.Count++;

            ((Button)sender).Content = midObject.Count;
        }

    
    }
}
