﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace SocketServer
{

   public class BinaryAppServer : AppServer<BinaryAppSession, BinaryRequestInfo>
   {
      public BinaryAppServer()
         : base(new DefaultReceiveFilterFactory<BinaryReceiveFilter, BinaryRequestInfo>())
      {

      }

      public override event RequestHandler<BinaryAppSession, BinaryRequestInfo> NewRequestReceived
      {
         add { base.NewRequestReceived += value; }
         remove { base.NewRequestReceived -= value; }
      }

      protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
      {
         return base.Setup(rootConfig, config);
      }

      protected override void OnStarted()
      {
         base.OnStarted();
      }

      protected override void OnStopped()
      {
         base.OnStopped();
      }
   }
}
