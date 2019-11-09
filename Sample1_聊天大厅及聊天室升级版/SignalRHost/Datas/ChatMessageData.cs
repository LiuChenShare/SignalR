using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Datas
{
    public class ChatMessageData
    {
        #region 单例
        /// <summary>
        /// ChatMessageData的单例表现
        /// </summary>
        private static volatile ChatMessageData instance;
        private static readonly object obj = new object();
        public static ChatMessageData Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new ChatMessageData();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion
    }
}
