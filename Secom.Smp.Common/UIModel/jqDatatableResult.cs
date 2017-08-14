using System.Collections.Generic;

namespace Secom.Smp.Common.UIModel
{
    public class jqDatatableResult<T> where T : class
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int iTotalRecords { get; set; }
        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int iTotalDisplayRecords { get; set; }
        /// <summary>
        /// datables数据源 JSON格式
        /// </summary>
        public IEnumerable<T> data { get; set; }
    }
}
