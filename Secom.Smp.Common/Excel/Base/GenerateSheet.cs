/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Excel
* 文件名: GenerateSheet
* 创建者: 邹琼俊
* 创建时间: 2017/7/11 19:13:58
* 版权所有： 紫衡技术
******************************************************************/
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Secom.Smp.Common.Excel
{
    /// <summary>
    /// 导出Excel基类
    /// </summary>
    public class GenerateSheet<T> : BaseGenerateSheet
    {
        #region 私有字段
        // Excel 显示时间的样式
        private ICellStyle dateStyle = null;
        // Excel 显示列头的样式
        private ICellStyle headStyle = null;
        // Excel 显示内容的样式
        private ICellStyle contentsStyle = null;
        // Excel 显示总计的样式
        private ICellStyle totalStyle = null;
        // 列头集合
        private List<ColumnsMapping> columnHeadList = null;
        // 显示的数据
        private List<T> dataSource;
        #endregion

        #region 属性
        /// <summary>
        /// Excel 显示时间的样式
        /// </summary>
        protected ICellStyle DateStyle
        {
            get { return dateStyle; }
            set { dateStyle = value; }
        }
        /// <summary>
        /// Excel 显示列头的样式
        /// </summary>
        protected ICellStyle HeadStyle
        {
            get { return headStyle; }
            set { headStyle = value; }
        }
        /// <summary>
        /// Excel 显示内容的样式
        /// </summary>
        protected ICellStyle ContentsStyle
        {
            get { return contentsStyle; }
            set { contentsStyle = value; }
        }
        /// <summary>
        /// Excel 显示总计的样式
        /// </summary>
        protected ICellStyle TotalStyle
        {
            get { return totalStyle; }
            set { totalStyle = value; }
        }
        /// <summary>
        /// 是否有边框 只读
        /// </summary>
        protected bool IsBorder { get; private set; }

        protected List<ColumnsMapping> ColumnHeadList
        {
            get { return this.columnHeadList; }
            private set { this.columnHeadList = value; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 导出Excel基类
        /// </summary>
        /// <param name="_dataSource">Sheet里面显示的数据</param>
        public GenerateSheet(List<T> _dataSource)
            : this(_dataSource, string.Empty, true)
        {
        }
        /// <summary>
        /// 导出Excel基类
        /// </summary>
        /// <param name="_dataSource">Sheet里面显示的数据</param>
        public GenerateSheet(List<T> _dataSource, string sheetName)
            : this(_dataSource, sheetName, true)
        {
        }
        /// <summary>
        /// 导出Excel基类
        /// </summary>
        /// <param name="_dataSource">Sheet里面显示的数据</param>
        /// <param name="isBorder">是否有边框</param>
        public GenerateSheet(List<T> _dataSource, bool isBorder)
            : this(_dataSource, string.Empty, isBorder)
        {
        }
        /// <summary>
        /// 导出Excel基类
        /// </summary>
        /// <param name="_dataSource">Sheet里面显示的数据</param>
        /// <param name="isBorder">是否有边框</param>
        public GenerateSheet(List<T> _dataSource, string sheetName, bool isBorder)
        {
            //if (_dataSource != null && _dataSource.Count > 0)
            this.dataSource = _dataSource;
            //else
            //    throw new Exception("数据不能为空！");
            this.IsBorder = isBorder;
            this.SheetName = sheetName;
        }
        #endregion

        #region 可以被重写的方法
        /// <summary>
        /// 生成Excel的Sheet
        /// </summary>
        /// <param name="sheet"></param>
        public override void GenSheet(ISheet sheet)
        {
            this.SetSheetContents(sheet);
        }
        /// <summary>
        /// 初始化列头
        /// </summary>
        /// <returns></returns>
        protected virtual List<ColumnsMapping> InitializeColumnHeadData()
        {
            try
            {
                List<PropertyInfo> propertyList = this.GetObjectPropertyList();
                List<ColumnsMapping> columnsList = new List<ColumnsMapping>();
                int colIndex = 0;
                foreach (PropertyInfo propertyInfo in propertyList)
                {
                    columnsList.Add(new ColumnsMapping()
                    {
                        ColumnsData = propertyInfo.Name,
                        ColumnsText = propertyInfo.Name,
                        ColumnsIndex = colIndex,
                        IsTotal = false,
                        Width = 15
                    });
                    colIndex++;
                }
                return columnsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置列头
        /// </summary>
        /// <param name="sheet">Excel Sheet</param>
        /// <param name="rowIndex">记录Excel最大行的位置，最大值为65535</param>
        protected virtual void SetColumnHead(ISheet sheet, ref int rowIndex)
        {
            if (columnHeadList.Count > 0)
            {
                IRow headerRow = sheet.CreateRow(rowIndex);
                foreach (ColumnsMapping columns in columnHeadList)
                {
                    ICell newCell = headerRow.CreateCell(columns.ColumnsIndex);
                    newCell.SetCellValue(columns.ColumnsText);
                    newCell.CellStyle = headStyle;
                    //设置列宽
                    SetColumnsWidth(sheet, columns.ColumnsIndex, columns.Width);
                }
                rowIndex++;
            }
        }
        /// <summary>
        /// 设置Excel内容
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dataSource"></param>
        /// <param name="rowIndex"></param>
        protected virtual void SetSheetContents(ISheet sheet, List<T> dataSource, ref int rowIndex)
        {
            if (dataSource != null)
            {
                foreach (T value in dataSource)
                {
                    #region 填充内容
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    int colIndex = 0;
                    foreach (ColumnsMapping columns in columnHeadList)
                    {
                        if (columns.ColumnsIndex >= 0)
                        {
                            if (columns.ColumnsIndex >= colIndex)
                                colIndex = columns.ColumnsIndex;
                            else
                                columns.ColumnsIndex = colIndex;

                            ICell newCell = dataRow.CreateCell(colIndex);
                            string drValue = string.Empty;
                            if (!string.IsNullOrEmpty(columns.ColumnsData))
                                drValue = GetModelValue(columns.ColumnsData, value);
                            SetCellValue(newCell, rowIndex, drValue, columns);
                            colIndex++;
                        }
                    }
                    #endregion

                    rowIndex++;
                }
                //rowIndex++;
            }
        }
        /// <summary>
        /// 设置单元格的数据
        /// </summary>
        /// <param name="cell">单元格对像</param>
        /// <param name="rowIndex">单元格行索引</param>
        /// <param name="drValue">单元格数据</param>
        /// <param name="columns">单元格的列信息</param>
        protected virtual void SetCellValue(ICell cell, int rowIndex, string drValue, ColumnsMapping columns)
        {
            cell.CellStyle = contentsStyle;
            if (!string.IsNullOrEmpty(columns.ColumnsData))
            {
                PropertyInfo info = GetObjectProperty(columns.ColumnsData);
                switch (info.PropertyType.FullName)
                {
                    case "System.String": //字符串类型
                        double result;
                        if (IsNumeric(drValue, out result))
                        {
                            double.TryParse(drValue, out result);
                            cell.SetCellValue(result);
                            break;
                        }
                        else
                        {
                            cell.SetCellValue(drValue);
                            break;
                        }
                    case "System.DateTime": //日期类型
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        cell.SetCellValue(dateV);
                        cell.CellStyle = dateStyle; //格式化显示
                        break;
                    case "System.Boolean": //布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        cell.SetCellValue(boolV);
                        break;
                    case "System.Int16": //整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        cell.SetCellValue(intV);
                        break;
                    case "System.Decimal": //浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        cell.SetCellValue(doubV);
                        break;
                    case "System.DBNull": //空值处理
                        cell.SetCellValue("");
                        break;
                    default:
                        cell.SetCellValue(drValue);
                        break;
                }
            }
            else
            {
                cell.SetCellValue("");
            }
        }
        /// <summary>
        /// 设置总计单元格的数据
        /// </summary>
        /// <param name="cell">总计单元格</param>
        /// <param name="rowIndex">当前行的索引</param>
        /// <param name="startRowIndex">内容数据的开始行</param>
        /// <param name="columns">当前列信息</param>
        protected virtual void SetTotalCellValue(ICell cell, int rowIndex, int startRowIndex, ColumnsMapping columns)
        {
            if (columns.IsTotal)
            {
                string colItem = CellReference.ConvertNumToColString(columns.ColumnsIndex);
                cell.CellStyle = totalStyle;
                cell.SetCellFormula(string.Format("SUM({0}{1}:{2}{3})", colItem, startRowIndex, colItem, rowIndex));
            }
        }
        /// <summary>
        /// 在所有数据最后添加总计，当然也可以是其它的公式
        /// </summary>
        /// <param name="sheet">工作薄Sheet</param>
        /// <param name="rowIndex">当前行</param>
        /// <param name="startRowIndex">内容开始行</param>
        protected virtual void SetTotal(ISheet sheet, ref int rowIndex, int startRowIndex)
        {
            if (rowIndex > startRowIndex)
            {
                IRow headerRow = sheet.CreateRow(rowIndex) as IRow;
                foreach (ColumnsMapping columns in columnHeadList)
                {
                    ICell newCell = headerRow.CreateCell(columns.ColumnsIndex);
                    SetTotalCellValue(newCell, rowIndex, startRowIndex, columns);
                }
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取属性名字
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        protected string GetPropertyName(Expression<Func<T, object>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        protected void SetColumnsWidth(ISheet sheet, int colIndex, int width)
        {
            //设置列宽
            sheet.SetColumnWidth(colIndex, width * 256);
        }
        #endregion

        #region 私有方法
        private void SetSheetContents(ISheet sheet)
        {
            if (sheet != null)
            {
                // 初始化相关样式
                this.InitializeCellStyle();
                // 初始化列头的相关数据
                this.columnHeadList = InitializeColumnHeadData();
                // 当前行
                int rowIndex = 0;
                // 设置列头
                this.SetColumnHead(sheet, ref rowIndex);
                // 内容开始行
                int startRowIndex = rowIndex;
                // 设置Excel内容
                this.SetSheetContents(sheet, dataSource, ref rowIndex);
                // 在所有数据最后添加总计，当然也可以是其它的公式
                if (dataSource.Count > 0)
                {
                    this.SetTotal(sheet, ref rowIndex, startRowIndex);
                }
            }
        }
        /// <summary>
        /// 初始化相关对像
        /// </summary>
        private void InitializeCellStyle()
        {
            columnHeadList = new List<ColumnsMapping>();

            // 初始化Excel 显示时间的样式
            dateStyle = this.Workbook.CreateCellStyle();
            IDataFormat format = this.Workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            if (this.IsBorder)
            {
                //有边框
                dateStyle.BorderBottom = BorderStyle.Thin;
                dateStyle.BorderLeft = BorderStyle.Thin;
                dateStyle.BorderRight = BorderStyle.Thin;
                dateStyle.BorderTop = BorderStyle.Thin;
            }

            // 初始化Excel 列头的样式
            headStyle = this.Workbook.CreateCellStyle();
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;// 文本居左
            IFont font = this.Workbook.CreateFont();
            font.FontHeightInPoints = 12;   // 字体大小
            font.Boldweight = 700;          // 字体加粗
            headStyle.SetFont(font);

            if (this.IsBorder)
            {
                //有边框
                headStyle.BorderBottom = BorderStyle.Thin;
                headStyle.BorderLeft = BorderStyle.Thin;
                headStyle.BorderRight = BorderStyle.Thin;
                headStyle.BorderTop = BorderStyle.Thin;
            }

            // 初始化Excel 显示内容的样式
            contentsStyle = this.Workbook.CreateCellStyle();
            font = this.Workbook.CreateFont();
            font.FontHeightInPoints = 10;
            contentsStyle.SetFont(font);
            if (this.IsBorder)
            {
                //有边框
                contentsStyle.BorderBottom = BorderStyle.Thin;
                contentsStyle.BorderLeft = BorderStyle.Thin;
                contentsStyle.BorderRight = BorderStyle.Thin;
                contentsStyle.BorderTop = BorderStyle.Thin;
            }

            // 初始化Excel 显示总计的样式
            totalStyle = this.Workbook.CreateCellStyle();
            font = this.Workbook.CreateFont();
            font.Boldweight = 700;
            font.FontHeightInPoints = 10;
            totalStyle.SetFont(font);
            if (this.IsBorder)
            {
                //有边框
                totalStyle.BorderBottom = BorderStyle.Thin;
                totalStyle.BorderLeft = BorderStyle.Thin;
                totalStyle.BorderRight = BorderStyle.Thin;
                totalStyle.BorderTop = BorderStyle.Thin;
            }
        }
        /// <summary>
        /// 获取 T 对像的所有属性
        /// </summary>
        /// <returns></returns>
        private List<PropertyInfo> GetObjectPropertyList()
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            Type t = typeof(T);
            if (t != null)
            {
                PropertyInfo[] piList = t.GetProperties();
                foreach (var pi in piList)
                {
                    if (!pi.PropertyType.IsGenericType)
                    {
                        result.Add(pi);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 根据属性名字获取 T 对像的属性
        /// </summary>
        /// <returns></returns>
        private PropertyInfo GetObjectProperty(string propertyName)
        {
            Type t = typeof(T);
            PropertyInfo result = t.GetProperty(propertyName);
            return result;
        }
        /// <summary>
        /// 获取类中的属性值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string GetModelValue(string FieldName, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(FieldName).GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 判断是否为一个数字并反回值
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool IsNumeric(String message, out double result)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
                result = -1;
                if (rex.IsMatch(message))
                {
                    result = double.Parse(message);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                result = 0;
                return false;
            }
        }
        #endregion
    }
}
