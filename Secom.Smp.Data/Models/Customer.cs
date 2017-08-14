/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Data.Models
* 文件名: Customer
* 创建者: 邹琼俊
* 创建时间: 2017/6/26 10:35:11
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.ComponentModel.DataAnnotations;

namespace Secom.Smp.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name = "用户名称")]
        public string Name { get; set; }
        [MaxLength(120)]
        [Required]
        [Display(Name = "用户地址")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "创建日期")]
        public DateTime? CreateTime { get; set; }
        [MaxLength(200)]
        [Display(Name = "备注")]
        public string Msg { get; set; }
        [Display(Name = "头像")]
        public string HeadsUrl { get; set; }
    }
}