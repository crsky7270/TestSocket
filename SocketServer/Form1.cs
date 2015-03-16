using System;
using System.Net.Sockets;
using System.Windows.Forms;
using SuperSocket.Common;
using SuperSocket.Dlr;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using CloseReason = SuperSocket.SocketBase.CloseReason;

namespace SocketServer
{
   public partial class Form1 : Form
   {
      private BinaryAppServer _appServer;
      private BinaryAppSession _session;
      public Form1()
      {
         _appServer = new BinaryAppServer();

         InitializeComponent();
      }

      private ServerConfig GetSocketServerConfig()
      {
         var serverConfig = new ServerConfig();
         serverConfig.Port = 5000;
         return serverConfig;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         this.button1.Enabled = false;
         StartSocketListen();
      }

      /// <summary>
      /// 开始监听
      /// </summary>
      private void StartSocketListen()
      {
         //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         //socket.Bind(new IPEndPoint(IPAddress.Any, 5000));

         //socket.Listen(4);
         if (_appServer != null)
         {
            var serverConfig = GetSocketServerConfig();
            if (!_appServer.Setup(serverConfig))
            {
               MessageBox.Show("Failed To Setup");
               return;
            }
            
            if (!_appServer.Start())
            {
               MessageBox.Show("Failed To Start");
               return;
            }
            _appServer.NewSessionConnected += new SessionHandler<BinaryAppSession>(appserver_NewSessionConnected);
            _appServer.NewRequestReceived += new RequestHandler<BinaryAppSession, BinaryRequestInfo>(appserver_NewRequestReceived);
            _appServer.SessionClosed += new SessionHandler<BinaryAppSession, CloseReason>(appserver_SessionClosed);
            MessageBox.Show("Start Success");

         }

      }

      private void appserver_SessionClosed(BinaryAppSession session, CloseReason value)
      {
         session.Send("bye");
      }

      /// <summary>
      /// 接收到新的消息
      /// </summary>
      /// <param name="session"></param>
      /// <param name="requestinfo"></param>
      private void appserver_NewRequestReceived(BinaryAppSession session, BinaryRequestInfo requestinfo)
      {

      }

      /// <summary>
      /// Session Connected
      /// </summary>
      /// <param name="session"></param>
      private void appserver_NewSessionConnected(BinaryAppSession session)
      {
         _session = session;
      }

      /// <summary>
      /// 停止监听
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button2_Click(object sender, EventArgs e)
      {
         _appServer.Stop();
         this.button1.Enabled = true;
      }

      /// <summary>
      /// 测试读取指令
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button3_Click(object sender, EventArgs e)
      {
         byte[] byt = { 0x01, 0x03, 0x00, 0x00, 0x00, 0x20, 0x44, 0x12 };
         _session.Send(byt, 0, byt.Length);
      }
   }
}
