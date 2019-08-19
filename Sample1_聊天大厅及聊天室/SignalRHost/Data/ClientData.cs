using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Data
{
    public class ClientData
    {

        private static volatile ClientData instance;
        private static readonly object obj = new object();
        public static ClientData Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new ClientData();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 客户端id及地址
        /// </summary>
        public Dictionary<Guid, string> ClientAddress = new Dictionary<Guid, string>();
    }
}
