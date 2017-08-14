namespace Secom.Smp.Common.UIModel
{
    /// <summary>
    /// 在服务器端,可以通过以下请求参数来获得当前客户端的操作信息
    /// jquery $('selector').datatable()插件 参数model
    /// </summary>
    public class jqDataTableParameter
    {
        /// <summary>
        /// 1.0 DataTable用来生成的信息
        /// </summary> 
        public string sEcho { get; set; }
        /// <summary>
        /// 2.0分页起始索引
        /// </summary>
        public int iDisplayStart { get; set; }
        /// <summary>
        /// 3.0每页显示的数量
        /// </summary>
        public int iDisplayLength { get; set; }
        /// <summary>
        /// 4.0搜索字段
        /// </summary>
        public string sSearch { get; set; }
        /// <summary>
        /// 5.0列数
        /// </summary>
        public int iColumns { get; set; }
        /// <summary>
        /// 6.0排序列的数量
        /// </summary>
        public int iSortingCols { get; set; }
        /// <summary>
        /// 7.0逗号分割所有的列
        /// </summary>
        public string sColumns { get; set; }
    }
}
