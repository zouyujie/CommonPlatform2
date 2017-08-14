/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Excel
* 文件名: ColumnsMapping
* 创建者: 邹琼俊
* 创建时间: 2017/7/11 19:14:41
* 版权所有： 紫衡技术
******************************************************************/

namespace Secom.Smp.Common.Excel
{
    /// <summary>
    /// Excel列头的相关设置
    /// </summary>
    public class ColumnsMapping
    {
        #region 属性
        /// <summary>
        /// Excel 列头显示的值
        /// </summary>
        public string ColumnsText { get; set; }
        /// <summary>
        /// Excel 列绑定对像的属性, 可以为空
        /// </summary>
        public string ColumnsData { get; set; }
        /// <summary>
        /// Excel 列的宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 是否需要总计行
        /// </summary>
        public bool IsTotal { get; set; }
        /// <summary>
        /// Excel列的索引
        /// </summary>
        public int ColumnsIndex { get; set; }
        #endregion

        #region 构造方法
        /// <summary>
        /// Excel列头的相关设置
        /// </summary>
        public ColumnsMapping() { }
        /// <summary>
        /// Excel列头的相关设置
        /// </summary>
        public ColumnsMapping(string colText, string colData, int width, int colIndex, bool _isTotal)
        {
            this.ColumnsText = colText;
            this.ColumnsData = colData;
            this.Width = width;
            this.IsTotal = _isTotal;
            this.ColumnsIndex = colIndex;
        }
        #endregion
    }
}
