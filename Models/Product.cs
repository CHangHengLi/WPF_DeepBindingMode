using System;

namespace BindingModeDemo.Models
{
    /// <summary>
    /// 产品信息模型类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProductId { get; set; }
        
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockQuantity { get; set; }
        
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
} 