using System;

namespace BindingModeDemo.Models
{
    /// <summary>
    /// 用户信息模型类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// 是否活跃
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate { get; set; }
        
        /// <summary>
        /// 通知频率（天）
        /// </summary>
        public double NotificationFrequency { get; set; }
    }
} 