/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Extend
* 文件名: Ext_Linq
* 创建者: 邹琼俊
* 创建时间: 2017/7/10 16:14:16
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace Secom.Smp.Data
{
    public static class Ext_Linq
    {
        public static IQueryable<T> OrderByEx<T>(this IQueryable<T> q, string direction, string fieldName)
        {
            try
            {
                var customProperty = typeof(T).GetCustomAttributes(false).OfType<ColumnAttribute>().FirstOrDefault();
                if (customProperty != null)
                {
                    fieldName = customProperty.Name;
                }
                var param = Expression.Parameter(typeof(T), "p");
                var prop = Expression.Property(param, fieldName);
                var exp = Expression.Lambda(prop, param);
                string method = direction.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
                Type[] types = new Type[] { q.ElementType, exp.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
                return q.Provider.CreateQuery<T>(mce);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
