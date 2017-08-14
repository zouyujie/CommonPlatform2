/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.WebApi
* 文件名: WebApiClient
* 创建者: 邹琼俊
* 创建时间: 2017/7/12 9:12:48
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Secom.Smp.Common.WebApiUtil
{
    public static class WebApiClient<T>
    {
        public static T Get(string url, string id)
        {
            T entity = default(T);
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddHeader(client);
            // List all info.
            HttpResponseMessage response = client.GetAsync(string.Format("{0}/{1}", url, id)).Result;// Blocking call（阻塞调用）! 
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                entity = response.Content.ReadAsAsync<T>().Result;
            }
            return entity;
        }
        public static List<T> GetAll(string url)
        {
            List<T> li = new List<T>();
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            // 为JSON格式添加一个Accept报头
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddHeader(client);
            // List all info.
            HttpResponseMessage response = client.GetAsync(url).Result;// Blocking call（阻塞调用）! 
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                // 解析响应体。阻塞！
                li = response.Content.ReadAsAsync<List<T>>().Result;
            }
            return li;
        }

        public static bool Edit(string url, List<int> value)
        {
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddHeader(client);
            var response = client.PutAsJsonAsync(url, value).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<TI> GetList<TI>(string url, List<int> value)
        {
            List<TI> list = new List<TI>();
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddHeader(client);
            var response = client.PostAsJsonAsync(url, value).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<TI>>().Result;
            }
            return list;
        }
        /// <summary>
        /// 添加自定义请求报文Header
        /// </summary>
        /// <param name="client"></param>
        private static void AddHeader(HttpClient client)
        {
            OperatorModel _OperatorModel = OperatorProvider.Provider.GetCurrent();
            if (_OperatorModel != null)
            {
                var model = WebApiLicence.GetValidateModel(_OperatorModel.UserId);
                if (model != null)
                {
                    client.DefaultRequestHeaders.Add("Userid", model.UserId);
                    client.DefaultRequestHeaders.Add("Signature", model.ServerToken);
                    client.DefaultRequestHeaders.Add("Timestamp ", DateTime.Now.ToString());
                }
            }
        }
    }
}
