/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Word
* 文件名: HtmlExt
* 创建者: WordHelper
* 创建时间: 2017/7/31 9:01:41
* 版权所有： 紫衡技术
******************************************************************/
using Aspose.Words;
using System.Web.Mvc;
using System.Web;

namespace Secom.Smp.Common.Word
{
    /// <summary>
    /// Word操作类
    /// </summary>
    public class WordHelper
    {
        public static Document GetDoc(string template)
        {
            string templateFile = HttpContext.Current.Server.MapPath(template);
            return new Document(templateFile);
        }
        /// <summary>
        /// 替换书签
        /// </summary>
        /// <param name="doc">word文档</param>
        /// <param name="title">书签名称</param>
        /// <param name="value">需要替换的内容</param>
        public void SetBookmark(ref Document doc, string title, string value)
        {
            Bookmark bookmark = doc.Range.Bookmarks[title];
            if (bookmark != null)
            {
                bookmark.Text = value;
            }
        }
        /// <summary>
        /// 对于HTML内容，需要通过InsertHtml方式进行写入
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        /// <param name="title">书签名称</param>
        /// <param name="value">需要替换的内容</param>
        public static void SetHtmlBookmark(ref Document doc, DocumentBuilder builder, string title, string value)
        {
            Aspose.Words.Bookmark bookmark = doc.Range.Bookmarks[title];
            if (bookmark != null)
            {
                builder.MoveToBookmark(bookmark.Name);
                builder.InsertHtml(value);
            }
        }
        /// <summary>
        /// 导出为Word
        /// </summary>
        /// <param name="doc">word模板</param>
        /// <param name="response">输出流</param>
        /// <param name="title">文件名称</param>
        /// <returns></returns>
        public static FileStreamResult ExportWord(Document doc, HttpResponseBase response ,string title)
        {
            doc.Save(HttpContext.Current.Response, title, ContentDisposition.Attachment,
             Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
            response.Flush();
            response.End();
            return new FileStreamResult(response.OutputStream, "application/ms-word");
        }
    }
}
