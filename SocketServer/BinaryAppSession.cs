using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SocketServer
{
   public class BinaryAppSession : AppSession<BinaryAppSession, BinaryRequestInfo>
   {
      protected override void OnSessionStarted()
      {
         this.Send("Welcome to Binary Server");
      }

      protected override void HandleUnknownRequest(BinaryRequestInfo requestInfo)
      {
         this.Send("Unknow request");
      }

      protected override void HandleException(Exception e)
      {
         this.Send("Application error:{0}", e.Message);
      }

      protected override void OnSessionClosed(CloseReason reason)
      {
         //add your logic
         base.OnSessionClosed(reason);
      }
   }
}
