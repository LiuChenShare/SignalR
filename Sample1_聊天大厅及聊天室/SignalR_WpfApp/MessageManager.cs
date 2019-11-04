using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SignalR_WpfApp
{
    /// <summary>
    /// 消息管理器
    /// </summary>
    public class MessageManager
    {
        #region 单例
        private static volatile MessageManager instance;
        private static readonly object obj = new object();
        public static MessageManager Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new MessageManager();
                        }
                    }

                }
                return instance;
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 消息回调事件
        /// </summary>
        public MessageEventHandler ExportEventHander;

        /// <summary>
        /// 导出进度事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public MessageEventArgs(Color color, string message)
            {
                Color = color;
                Message = message;
            }
            /// <summary>
            /// 颜色
            /// </summary>
            public Color Color { get; set; }
            /// <summary>
            /// 消息文本
            /// </summary>
            public string Message { get; set; }
        }
        #endregion

        #region 具体的消息通知
        /// <summary>
        /// 打印错误信息
        /// </summary>
        /// <param name="str">待打印的字符串(红色)</param>
        public void WriteErrorLine(string str)
        {
            ExportEventHander?.Invoke(null, new MessageEventArgs(Color.Red, str));
        }
        /// <summary>
        /// 打印警告信息
        /// </summary>
        /// <param name="str">待打印的字符串(黄色)</param>
        public void WriteWarningLine(string str)
        {
            ExportEventHander?.Invoke(null, new MessageEventArgs(Color.Yellow, str));
        }
        /// <summary>
        /// 打印正常信息
        /// </summary>
        /// <param name="str">待打印的字符串(白色)</param>
        public void WriteInfoLine(string str)
        {
            ExportEventHander?.Invoke(null, new MessageEventArgs(Color.White, str));
        }
        /// <summary>
        /// 打印成功的信息
        /// </summary>
        /// <param name="str">待打印的字符串(绿色)</param>
        public void WriteSuccessLine(string str)
        {
            ExportEventHander?.Invoke(null, new MessageEventArgs(Color.Green, str));
        }
        #endregion
    }
}
