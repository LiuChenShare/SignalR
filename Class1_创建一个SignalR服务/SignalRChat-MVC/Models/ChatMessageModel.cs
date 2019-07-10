using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat_MVC.Models
{
    /// <summary>
    /// 消息模型
    /// </summary>
    public class ChatMessageModel
    {
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }
    }
}