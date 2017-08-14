/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Data.Models
* 文件名: OperatorLog
* 创建者: 邹琼俊
* 创建时间: 2017/6/26 15:06:38
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Secom.Smp.Data.Models
{
    public class OperatorLog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name ="日志名称")]
        public string Name { get; set; }
        [MaxLength(120)]
        public string CreateBy { get; set; }
        [Display(Name = "创建日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "日志备注")]
        [MaxLength(200)]
        public string Msg { get; set; }
    }
}