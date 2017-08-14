//******************************************************************/
//  ScaleLimit.cs
//  Implementation of the Class ScaleLimit
//  版权所有： 紫衡技术
//  Created on:      16-7月-2017 22:58:36
//  创建者: 邹琼俊
//******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities {
	public class ScaleLimit {
		

		public double min{
			get;
			set;
		}

		public double max{
			get;
			set;
		}

		/// 
		/// <param name="min"></param>
		public ScaleLimit Min(double min){
		     this.min=min;
		return this; 
		}

		/// 
		/// <param name="max"></param>
		public ScaleLimit Max(double max){
		     this.max=max;
		return this; 
		}

	}//end ScaleLimit

}//end namespace Entities