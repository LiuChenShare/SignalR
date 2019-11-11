using System;

namespace ChatRoom.Models
{
    /// <summary>
    /// 客户端信息
    /// </summary>
    public class ClientInfoModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AddressId { get; set; }

        public string GroupId { get; set; }
    }
}
