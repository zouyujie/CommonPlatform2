/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.ViewModel
* 文件名: BaseEntity
* 创建者: 邹琼俊
* 创建时间: 2017/7/12 9:21:03
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common.WebApiUtil;
using Secom.Smp.Common;
using System;
using System.Collections.Generic;

namespace Secom.Smp.Web.Base.ViewModel
{
    public abstract class BaseEntity<T> where T : class
    {
        #region WebApi获取数据
        public static string WebAPIDomain
        {
            get
            {
                string domain = SystemConfig.WebApiDomain;
                if (string.IsNullOrEmpty(domain))
                {
                    throw new Exception(string.Format("未包含WebAPI域名配置"));
                }
                return domain;
            }
        }
        public static string RelativeUrl { get; set; }
        public static string Url
        {
            get
            {
                return WebAPIDomain + RelativeUrl;
            }
        }

        public static List<T> GetAllBySource()
        {
            return WebApiClient<T>.GetAll(Url);
        }

        public static void EditBySource(List<int> value)
        {
            WebApiClient<T>.Edit(Url, value);
        }

        public static T GetOneBySource(string id)
        {
            return WebApiClient<T>.Get(Url, id);
        }
        #endregion
    }
}
