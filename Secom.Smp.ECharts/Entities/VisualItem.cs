/******************************************************************/
//  BrushVisual.cs
//  Implementation of the Class BrushVisual
//  版权所有： 紫衡技术
//  Created on:      18-7月-2017 14:57:53
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities {
	public class VisualItem {

	 

		public string symbol{
			get;
			set;
		}

		public object symbolSize{
			get;
			set;
		}

		public object color{
			get;
			set;
		}

		public double? colorAlpha{
			get;
			set;
		}

		public double? opacity{
			get;
			set;
		}

		public IList<double> colorLightness{
			get;
			set;
		}

		public double? colorStaturation{
			get;
			set;
		}

		public double? colorHue{
			get;
			set;
		}

		/// 
		/// <param name="symbol"></param>
		public VisualItem Symbol(string symbol){
		     this.symbol=symbol;
		return this; 
		}

        public VisualItem Opacity(double opacity)
        {
            this.opacity = opacity;
            return this;
        }

        /// 
		/// <param name="color"></param>
		public VisualItem Color(string color){
		     this.color=color;
		return this; 
		}

        /// 
        /// <param name="color"></param>
        public VisualItem Color(object color)
        {
            this.color = color;
            return this;
        }


		/// 
		/// <param name="colorAlpha"></param>
		public VisualItem ColorAlpha(double colorAlpha){
		     this.colorAlpha=colorAlpha;
		return this; 
		}

		/// 
		/// <param name="colorLightness"></param>
		public VisualItem ColorLightness(IList<double> colorLightness){
		     this.colorLightness=colorLightness;
		return this; 
		}

		/// 
		/// <param name="colorStaturation"></param>
		public VisualItem ColorStaturation(double colorStaturation){
		     this.colorStaturation=colorStaturation;
		return this; 
		}

		/// 
		/// <param name="colorHue"></param>
		public VisualItem ColorHue(double colorHue){
		     this.colorHue=colorHue;
		return this; 
		}

		/// 
		/// <param name="symbolSize"></param>
		public VisualItem SymbolSize(double symbolSize){
		     this.symbolSize=symbolSize;
		return this; 
		}

        public VisualItem SymbolSize(object symbolSize)
        {
            this.symbolSize = symbolSize;
            return this;
        }

	}//end BrushVisual

}//end namespace Entities