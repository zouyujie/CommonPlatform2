/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.File
* 文件名: FileHelper
* 创建者: 邹琼俊
* 创建时间: 2017/7/20 18:49:05
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.Common
{
    public class FileHelper
    {
        public static bool DeleteFile(string fullName)
        {
            if (System.IO.File.Exists(fullName))
            {
                System.IO.File.Delete(fullName);
                return true;
            }
            return false;
        }
    }
}
