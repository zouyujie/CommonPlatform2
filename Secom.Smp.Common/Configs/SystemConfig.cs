namespace Secom.Smp.Common
{
    public class SystemConfig
    {
        /// <summary>
        /// 系统缓存设置时间
        /// </summary>
        public static double SysCacheTime
        {
            get
            {
                return string.IsNullOrEmpty(Configs.GetValue("SysCacheTime"))?20:double.Parse(Configs.GetValue("SysCacheTime"));
            }
        }
        /// <summary>
        /// 登陆提供者模式
        /// </summary>
        public static string LoginProvider
        {
            get { return Configs.GetValue("LoginProvider"); }
        }
        /// <summary>
        /// 是否显示异常信息
        /// </summary>
        public static bool IsShowEx
        {
            get { return Configs.GetValue("IsShowEx")=="true"?true:false; }
        }
        /// <summary>
        /// WebApi站点域名
        /// </summary>
        public static string WebApiDomain
        {
            get { return Configs.GetValue("WebApiDomain"); }
        }
        /// <summary>
        /// 系统主题名称
        /// </summary>
        public static string ThemeName
        {
            get { return Configs.GetValue("ThemeName"); }
        }
    }
}
