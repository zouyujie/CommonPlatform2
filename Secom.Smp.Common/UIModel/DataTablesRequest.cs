/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common
* 文件名: DataTablesRequest
* 创建者: 邹琼俊
* 创建时间: 2017/7/10 14:50:56
* 版权所有： 紫衡技术
******************************************************************/
using System.Linq;
using System.Web;

namespace Secom.Smp.Common.UIModel
{
    // 排序的方向
    public enum SortDirection
    {
        Asc,    // 升序
        Desc    // 降序
    }

    // 排序列的定义
    public class SortColumn
    {
        public int Index { get; set; }                  // 列序号
        public SortDirection Direction { get; set; }    // 列的排序方向
    }

    // 列定义
    public class Column
    {
        public string Name { get; set; }        // 列名
        public bool Sortable { get; set; }      // 是否可排序
        public bool Searchable { get; set; }    // 是否可搜索
        public string Search { get; set; }      // 搜索串
        public bool EscapeRegex { get; set; }   // 是否正则
    }
    /// <summary>
    /// DataTables请求参数封装类
    /// </summary>
    public class DataTablesRequest
    {
        private HttpRequestBase request;        // 内部使用的 Request 对象

        public DataTablesRequest(System.Web.HttpRequestBase request)    // 用于 MVC 模式下的构造函数
        {
            this.request = request;

            this.echo = this.ParseStringParameter(sEchoParameter);
            this.displayStart = this.ParseIntParameter(iDisplayStartParameter);
            this.displayLength = this.ParseIntParameter(iDisplayLengthParameter);
            this.sortingCols = this.ParseIntParameter(iSortingColsParameter);

            this.search = this.ParseStringParameter(sSearchParameter);
            this.regex = this.ParseStringParameter(bRegexParameter) == "true";

            // 排序的列
            int count = this.iSortingCols;
            this.sortColumns = new SortColumn[count];
            for (int i = 0; i < count; i++)
            {
                SortColumn col = new SortColumn();
                col.Index = this.ParseIntParameter(string.Format("iSortCol_{0}", i));

                if (this.ParseStringParameter(string.Format("sSortDir_{0}", i)) == "desc")
                {
                    col.Direction = SortDirection.Desc;
                }
                else
                {
                    col.Direction = SortDirection.Asc;
                }
                this.sortColumns[i] = col;
            }

            this.ColumnCount = this.ParseIntParameter(iColumnsParameter);

            count = this.ColumnCount;
            this.columns = new Column[count];

            if (this.ParseStringParameter(sColumnsParameter) == null || !this.ParseStringParameter(sColumnsParameter).Contains(','))
            {
                return;
            }
            string[] names = this.ParseStringParameter(sColumnsParameter).Split(',');

            for (int i = 0; i < count; i++)
            {
                Column col = new Column();
                col.Name = names[i];
                col.Sortable = this.ParseStringParameter(string.Format("bSortable_{0}", i)) == "true";
                col.Searchable = this.ParseStringParameter(string.Format("bSearchable_{0}", i)) == "true";
                col.Search = this.ParseStringParameter(string.Format("sSearch_{0}", i));
                col.EscapeRegex = this.ParseStringParameter(string.Format("bRegex_{0}", i)) == "true";
                columns[i] = col;
            }
        }
        public DataTablesRequest(HttpRequest httpRequest)       // 标准的 WinForm 方式下的构造函数
            : this(new HttpRequestWrapper(httpRequest))
        { }

        #region
        private const string sEchoParameter = "sEcho";

        // 起始索引和长度
        private const string iDisplayStartParameter = "iDisplayStart";
        private const string iDisplayLengthParameter = "iDisplayLength";

        // 列数
        private const string iColumnsParameter = "iColumns";
        private const string sColumnsParameter = "sColumns";

        // 参与排序列数
        private const string iSortingColsParameter = "iSortingCols";
        private const string iSortColPrefixParameter = "iSortCol_";         // 排序列的索引
        private const string sSortDirPrefixParameter = "sSortDir_";         // 排序的方向 asc, desc

        // 每一列的可排序性
        private const string bSortablePrefixParameter = "bSortable_";

        // 全局搜索
        private const string sSearchParameter = "sSearch";
        private const string bRegexParameter = "bRegex";

        // 每一列的搜索
        private const string bSearchablePrefixParameter = "bSearchable_";
        private const string sSearchPrefixParameter = "sSearch_";
        private const string bEscapeRegexPrefixParameter = "bRegex_";
        #endregion

        private readonly string echo;
        public string sEcho
        {
            get { return echo; }
        }

        private readonly int displayStart;
        public int iDisplayStart
        {
            get { return this.displayStart; }
        }

        private readonly int displayLength;
        public int iDisplayLength
        {
            get { return this.displayLength; }
        }

        // 参与排序的列
        private readonly int sortingCols;
        public int iSortingCols
        {
            get { return this.sortingCols; }
        }

        // 排序列
        private readonly SortColumn[] sortColumns;
        public SortColumn[] SortColumns
        {
            get { return sortColumns; }
        }

        private readonly int ColumnCount;
        public int iColumns
        {
            get { return this.ColumnCount; }
        }

        private readonly Column[] columns;
        public Column[] Columns
        {
            get { return this.columns; }
        }

        private readonly string search;
        public string Search
        {
            get { return this.search; }
        }

        private readonly bool regex;
        public bool Regex
        {
            get { return this.regex; }
        }

        #region 常用的几个解析方法
        private int ParseIntParameter(string name)          // 解析为整数
        {
            int result = 0;
            string parameter = this.request[name];
            if (!string.IsNullOrEmpty(parameter))
            {
                int.TryParse(parameter, out result);
            }
            return result;
        }

        private string ParseStringParameter(string name)    // 解析为字符串
        {
            return this.request[name];
        }
        private bool ParseBooleanParameter(string name)     // 解析为布尔类型
        {
            bool result = false;
            string parameter = this.request[name];
            if (!string.IsNullOrEmpty(parameter))
            {
                bool.TryParse(parameter, out result);
            }
            return result;
        }
        #endregion
    }
}
