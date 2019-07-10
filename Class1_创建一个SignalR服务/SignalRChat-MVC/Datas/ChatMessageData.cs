using SignalRChat_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat_MVC.Datas
{
    public class ChatMessageData
    {
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

        private Queue<ChatMessageModel> Data = new Queue<ChatMessageModel>();      //消息队列

        /// <summary>插入</summary>
        public void EnqueueTask(ChatMessageModel model)
        {
            try
            {
                int max = 200;
                Data.Enqueue(model);
                if (Data.Count() > max)
                {
                    var num = Data.Count() - max;
                    for (int i = 0; i < num; i++)
                    {
                        Data.Dequeue();
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        /// <summary>获取</summary>
        public List<ChatMessageModel> GetList()
        {
            return Data.ToList();
        }
    }
}