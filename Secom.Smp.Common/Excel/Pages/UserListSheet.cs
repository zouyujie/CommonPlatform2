/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Excel.Pages
* 文件名: UserListSheet
* 创建者: 邹琼俊
* 创建时间: 2017/7/11 19:19:44
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Data.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Collections.Generic;


namespace Secom.Smp.Common.Excel
{
    /// <summary>
    /// 用户列表
    /// </summary>
    public class UserListSheet : GenerateSheet<Customer>
    {
        public UserListSheet(List<Customer> dataSource, string sheetName)
            : base(dataSource, sheetName)
        {

        }

        protected override List<ColumnsMapping> InitializeColumnHeadData()
        {
            List<ColumnsMapping> result = new List<ColumnsMapping>();
            result.Add(new ColumnsMapping()
            {
                ColumnsText = "客户名称",
                ColumnsData = GetPropertyName(p => p.Name),
                ColumnsIndex = 0,
                IsTotal = false,
                Width = 15
            });
            result.Add(new ColumnsMapping()
            {
                ColumnsText = "客户地址",
                ColumnsData = GetPropertyName(p => p.Address),
                ColumnsIndex = 1,
                IsTotal = false,
                Width = 30
            });
            result.Add(new ColumnsMapping()
            {
                ColumnsText = "创建时间",
                ColumnsData = GetPropertyName(p => p.CreateTime),
                ColumnsIndex = 2,
                IsTotal = false,
                Width = 15
            });
            result.Add(new ColumnsMapping()
            {
                ColumnsText = "备注",
                ColumnsData = GetPropertyName(p => p.Msg),
                ColumnsIndex = 3,
                IsTotal = false,
                Width = 30
            });

            return result;
        }
    }
}
