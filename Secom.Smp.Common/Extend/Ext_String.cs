/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Extend
* 文件名: Ext_String
* 创建者: 邹琼俊
* 创建时间: 2017/7/10 14:43:13
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Secom.Smp.Common
{
    public static class Ext_String
    {
        private static readonly Regex cleanWhitespace = new Regex(@"\s+", RegexOptions.Compiled | RegexOptions.Multiline);

        public static bool HasValue(this string source)
        {
            return !String.IsNullOrEmpty(source);
        }


        public static bool IsZiro(this string source)
        {
            return source.HasValue() && source != "0";
        }

        public static string IsRequired(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                //定义异常
                throw new ArgumentNullException("source");
            }

            return source;
        }

        public static string CleanHtmlTags(this string source)
        {
            Regex exp = new Regex(
                "<[^<>]*>",
                RegexOptions.Compiled
                );

            return exp.Replace(source.CleanWhiteSpace().Replace("&nbsp;", ""), "");
        }

        public static string CleanHtmlTags(this string source, bool keepWhiteSpace)
        {
            Regex exp = new Regex(
                "<[^<>]*>",
                RegexOptions.Compiled
                );

            if (!keepWhiteSpace)
                source = source.CleanHtmlTags();

            return exp.Replace(source.Replace("&nbsp;", ""), "");
        }


        public static string ClearHtml(this string source)
        {
            string StrNohtml = System.Text.RegularExpressions.Regex.Replace(source, "<[^>]+>", "");

            StrNohtml = Regex.Replace(StrNohtml, "&[^;]+;", "");
            return StrNohtml;
        }

        public static string CleanHref(this string source)
        {
            return HttpUtility.HtmlAttributeEncode(source);
        }

        public static string CleanWhiteSpace(this string source)
        {
            return cleanWhitespace.Replace(source, "");
        }

        public static string CleanAttr(this string source)
        {
            return Regex.Replace(source, @"<([^i\s>]+)[^>]*?>", "<$1>");
        }


        public static string Shorten(this string source, int characterCount)
        {
            string text = !string.IsNullOrEmpty(source) ? source.CleanHtmlTags().CleanWhiteSpace() : "";

            if (!string.IsNullOrEmpty(text) && characterCount > 0 && text.Length > characterCount)
            {
                text = text.Substring(0, characterCount);
            }

            return text;
        }

        public static string ComputeHash(this string value)
        {
            string hash = value;

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = Encoding.ASCII.GetBytes(value);
                data = md5.ComputeHash(data);
                hash = "";
                for (int i = 0; i < data.Length; i++)
                {
                    hash += data[i].ToString("x2", CultureInfo.CurrentCulture);
                }
            }

            return hash;
        }

        public static string ToChinese(this Enum value)
        {
            if (value == null)
                return "";

            System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return value.ToString();
            else
                return (attribArray[0] as DescriptionAttribute).Description;
        }

        public static T Parse<T>(this string value) where T : struct, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static bool IsMatch(this string str, string regex, bool isRequired)
        {
            if (string.IsNullOrEmpty(str))
                return !isRequired;

            return Regex.IsMatch(str, regex);
        }

        public static bool IsNumber(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return Regex.IsMatch(str, @"^\d+(\.\d+)?$");
        }

        public static string AddPath(this string path, string newPath)
        {
            if (string.IsNullOrEmpty(path))
                return newPath;
            return path + (path.EndsWith(@"/", true, CultureInfo.CurrentCulture) ? "" : "/") + newPath;
        }

        public static string SubStr(this string str, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else if (str.Length < startIndex)
                return string.Empty;
            else if (str.Length < startIndex + length)
                return str.Substring(startIndex);
            else
                return str.Substring(startIndex, length);
        }

        public static string SubStr(this string str, int length)
        {
            return str.SubStr(0, length);
        }

        public static string SubStr(this string str, int length, bool addEllipsis)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            int len = Encoding.Default.GetBytes(str).Length;
            if (len < length)
                return str;

            if (addEllipsis)
                return str.SubStr(length - 3) + "...";
            else
                return str.SubStr(length);
        }

        public static string UriQueryString(this Uri uri, string key)
        {
            if (key == null)
            {
                throw new ArgumentException("key is not null");
            }
            key = key.ToLower(CultureInfo.CurrentCulture);
            if (uri != null)
            {
                string pathQuery = uri.Query;
                pathQuery = pathQuery.SubStr(1, pathQuery.Length);
                string[] listQuery = pathQuery.Split(new char[] { '&' });

                string tag = string.Empty;
                foreach (var item in listQuery)
                {
                    if (item.ToLower(System.Globalization.CultureInfo.CurrentCulture).StartsWith(key, true, CultureInfo.CurrentCulture))
                    {
                        tag = item.SubStr(key.Trim().Length + 1, item.Length);
                        break;
                    }
                }
                return tag;
            }
            else
                return string.Empty;
        }

        public static string MD5(this string oldMD5, int length)
        {
            oldMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldMD5, "MD5").ToLower(System.Globalization.CultureInfo.CurrentCulture);

            //16位MD5加密（取32位加密的9~25字符）
            if (length == 16)
            {
                return oldMD5.Substring(8, 16);
            }

            return oldMD5;

        }
    }
}
