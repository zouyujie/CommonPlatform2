/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Excel
* 文件名: BaseGenerateSheet
* 创建者: 邹琼俊
* 创建时间: 2017/7/11 19:12:34
* 版权所有： 紫衡技术
******************************************************************/
using NPOI.SS.UserModel;

namespace Secom.Smp.Common.Excel
{
    public abstract class BaseGenerateSheet
    {
        public string SheetName { set; get; }

        public IWorkbook Workbook { get; set; }

        public virtual void GenSheet(ISheet sheet)
        {

        }
    }
}
