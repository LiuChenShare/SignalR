using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Models.Entiy
{
    /// <summary>
    /// 用户账号信息
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
