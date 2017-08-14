/******************************************************************/
//  RippleEffect.cs
//  Implementation of the Class RippleEffect
//  版权所有： 紫衡技术
//  Created on:      15-7月-2017 22:46:38
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.series {
	public class RippleEffect {

		 
		public int? period{
			get;
			set;
		}

		public double? scale{
			get;
			set;
		}

		public BrushType brushType{
			get;
			set;
		}

		/// 
		/// <param name="period"></param>
		public RippleEffect Period(int period){
		     this.period=period;
		return this; 
		}

		/// 
		/// <param name="scale"></param>
		public RippleEffect Scale(double scale){
		     this.scale=scale;
		return this; 
		}

		/// 
		/// <param name="brushType"></param>
        public RippleEffect BrushType(BrushType brushType)
        {
		     this.brushType=brushType;
		return this; 
		}

	}//end RippleEffect

}//end namespace series