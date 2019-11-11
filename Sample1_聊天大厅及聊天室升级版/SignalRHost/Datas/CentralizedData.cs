using ChatRoom.Models;
using ChatRoom.Models.Entiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHost.Datas
{
    /// <summary>
    /// 服务集中数据管理器
    /// </summary>
    public class CentralizedData
    {
        #region 单例
        /// <summary>
        /// ChatMessageData的单例表现
        /// </summary>
        private static volatile CentralizedData instance;
        private static readonly object obj = new object();
        public static CentralizedData Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new CentralizedData();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// 活跃的客户端信息
        /// </summary>
        public List<ClientInfoModel> ClientAddress = new List<ClientInfoModel>();

        /// <summary>
        /// 已注册用户
        /// </summary>
        public List<AccountInfo> UserList = new List<AccountInfo>
        {
            new AccountInfo{ Id = "1", Name = "村长", Account = "cunzhang", Password = "123456" },
            new AccountInfo{ Id = "2", Name = "喜羊羊", Account = "xiyangyang", Password = "123456" },
            new AccountInfo{ Id = "3", Name = "懒羊羊", Account = "lanyangyang", Password = "123456" },
            new AccountInfo{ Id = "4", Name = "沸羊羊", Account = "feiyangyang", Password = "123456" },
            new AccountInfo{ Id = "5", Name = "美羊羊", Account = "meiyangyang", Password = "123456" },
        };

        /// <summary>
        /// 已注册房间
        /// </summary>
        public List<RoomInfo> RoomList = new List<RoomInfo>
        {
            new RoomInfo{ Id = "1001", Name = "吊炸天厅" },
            new RoomInfo{ Id = "1002", Name = "纸醉金迷厅" },
            new RoomInfo{ Id = "1003", Name = "澳门赌场厅" },
            new RoomInfo{ Id = "1004", Name = "青青草原厅" },
        };
    }
}
