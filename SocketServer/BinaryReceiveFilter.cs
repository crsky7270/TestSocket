using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Protocol;

namespace SocketServer
{
   public class BinaryReceiveFilter : IReceiveFilter<BinaryRequestInfo>
   {
      /// <summary>
      /// 截取发来请求的缓存当中的数据,该写法只针对没有结束符的协议
      /// </summary>
      /// <param name="readBuffer">默认buff大小是400k</param>
      /// <param name="offset">数据在缓存当中的位置</param>
      /// <param name="length">数据长度</param>
      /// <param name="toBeCopied"></param>
      /// <param name="rest">重置位置</param>
      /// <returns></returns>
      public BinaryRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
      {
         rest = 0;
         byte[] byt = new byte[length];
         Array.Copy(readBuffer, offset, byt, 0, length);
         return new BinaryRequestInfo("test", byt);
      }

      public void Reset()
      {
         //throw new NotImplementedException();
      }

      public int LeftBufferSize
      {
         get { return 0; }
      }

      public IReceiveFilter<BinaryRequestInfo> NextReceiveFilter
      {
         get { return this; }
      }

      public FilterState State { get; private set; }
   }
}
