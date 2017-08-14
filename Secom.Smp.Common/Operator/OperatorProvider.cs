/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Operator
* 文件名: OperatorProvider
* 创建者: 邹琼俊
* 创建时间: 2017/7/3 17:03:41
* 版权所有： 紫衡技术
******************************************************************/

using System;

namespace Secom.Smp.Common
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "smp_2017";
        private string LoginProvider = SystemConfig.LoginProvider;

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).JsonToObject<OperatorModel>();
            }
            else if (LoginProvider == "Redis")
            {
                //从Redis获取对象
                object obj = null;//Common.Redis.Get(LoginUserKey);//根据 key 从 Reids 中获取用户的信息
                operatorModel = JsonTools.JsonToObject<OperatorModel>(obj.ToString());
                //Common.Redis.Set(sessionId, obj.ToString(), DateTime.Now.AddMinutes(20));//模拟滑动过期时间
            }
            else
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).JsonToObject<OperatorModel>();
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ObjectToJson()));
            }
            else if(LoginProvider == "Redis") //写入Redis
            {
                //1.设置Cookies——sessionId
                string sessionId = Guid.NewGuid().ToString();//作为 Redis 的 key
                //2.记录Redis——sessionId，使用 Redis 代替 Session 解决数据在不同 Web 服务器之间共享的问题
                //Common.Redis.Set(sessionId,operatorModel, DateTime.Now.AddMinutes(20));
                //3.将 Redis的key以 cookie 的形式返回到浏览器端的内存中，当用户再次请求其它的页面请求报文中会以 Cookie 将该值再次发送服务端。
                WebHelper.WriteCookie(LoginUserKey, sessionId);
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ObjectToJson()));
            }
            //WebHelper.WriteCookie("smp_mac", Md5.Md5Hash(Net.GetMacByNetworkInterface().ObjectToJson(), 32));
            //WebHelper.WriteCookie("smp_licence", SysLicence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else if (LoginProvider == "Redis")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
