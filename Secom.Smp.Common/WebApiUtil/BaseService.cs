/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Clients.Admin.Admin
* 文件名: BaseService
* 创建者: 邹琼俊
* 创建时间: 2017/7/20 14:26:12
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Secom.Smp.Common.WebApiUtil
{
    public class BaseService<T> where T:class
    {
        #region WebApi获取数据
        /// <summary>
        /// WebApi 请求地址
        /// </summary>
        public static string Url
        {
            get
            {
                string url = ConfigurationManager.AppSettings[typeof(T).Name];
                if (string.IsNullOrEmpty(url))
                {
                    throw new Exception(string.Format("“{0}”未包含URL配置", typeof(T).Name));
                }
                return SystemConfig.WebApiDomain+url;
            }
        }
        public  T Get(string id)
        {
            return WebApiClient<T>.Get(Url, id);
        }
        public T Get(string url,string id)
        {
            return WebApiClient<T>.Get(url, id);
        }
        public  List<T> GetAll()
        {
            return WebApiClient<T>.GetAll(Url);
        }
        public List<T> GetFilter(FilterParam filter)
        {
            string url = string.Format("{0}/?{1}", Url, filter.GetFilter());
            return WebApiClient<T>.GetAll(url);
        }
        public  void EditList(List<int> value)
        {
            WebApiClient<T>.Edit(Url, value);
        }
        #endregion
}
}
