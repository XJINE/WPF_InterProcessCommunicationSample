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

//ServerSideプロジェクトへの参照の追加も必要.
using ServerSide;

namespace ClientSide
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            //クライアントサイドのチャンネルを生成.
            IpcClientChannel channel = new IpcClientChannel();

            //チャンネルを登録
            ChannelServices.RegisterChannel(channel, true);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //リモートオブジェクトを取得
            //URIは"/チャンネル名/公開名"になる.
            IPCData.MidObject midObject = Activator.GetObject
                (typeof(IPCData.MidObject), "ipc://SampleChannel/OpenData") as IPCData.MidObject;
            
            //カウントを1増やす
            midObject.Count++;

            ((Button)sender).Content = midObject.Count;
        }

    }
}
