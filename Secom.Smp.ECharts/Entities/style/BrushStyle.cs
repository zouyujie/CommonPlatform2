/******************************************************************/
//  BrushStyle.cs
//  Implementation of the Class BrushStyle
//  版权所有： 紫衡技术
//  Created on:      18-7月-2017 14:58:35
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.style {
	public class BrushStyle {

	 
		public int? borderWidth{
			get;
			set;
		}

		public object color{
			get;
			set;
		}

		public object borderColor{
			get;
			set;
		}

		public int? width{
			get;
			set;
		}

		/// 
		/// <param name="borderWidth"></param>
		public BrushStyle BorderWidth(int borderWidth){
		     this.borderWidth=borderWidth;
		return this; 
		}

		/// 
		/// <param name="color"></param>
		public BrushStyle Color(string color){
		     this.color=color;
		return this; 
		}

		/// 
		/// <param name="borderColor"></param>
		public BrushStyle BorderColor(string borderColor){
		     this.borderColor=borderColor;
		return this; 
		}

		/// 
		/// <param name="width"></param>
		public BrushStyle Width(int width){
		     this.width=width;
		return this; 
		}

	}//end BrushStyle

}//end namespace style