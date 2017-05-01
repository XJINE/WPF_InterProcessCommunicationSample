using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCData
{

    /// <summary>
    /// プロセス間通信サンプルのためのオブジェクト.
    /// </summary>
    public class MidObject:MarshalByRefObject
    {
        public int Count { get; set; }
    }
}
