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
         //throw new NotImplementedException();
      }

      private void appserver_NewRequestReceived(BinaryAppSession session, BinaryRequestInfo requestinfo)
      {
         //throw new NotImplementedException();
         //this.RecListBox.Items.Add(requestinfo.Body.ToString());

      }

      private void appserver_NewSessionConnected(BinaryAppSession session)
      {
         //session.Send("hello");
         byte[] byt = { 0x01, 0x03, 0x00, 0x00, 0x00, 0x20, 0x44, 0x12 };

         _session = session;
         session.Send(byt, 0, byt.Length);

         //throw new NotImplementedException();
      }

      /// <summary>
      /// 停止监听
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void button2_Click(object sender, EventArgs e)
      {
         //if (socket != null)
         //{
         //   socket.Close();
         //   socket.Dispose();
         //   this.button1.Enabled = true;
         //}
         _appServer.Stop();
         this.button1.Enabled = true;
      }

      private void button3_Click(object sender, EventArgs e)
      {

         byte[] byt = { 0x01, 0x03, 0x00, 0x00, 0x00, 0x20, 0x44, 0x12 };

         _session.Send(byt, 0, byt.Length);
      }
   }
}
