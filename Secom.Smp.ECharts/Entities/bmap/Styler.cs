/******************************************************************/
//  Styler.cs
//  Implementation of the Class Styler
//  版权所有： 紫衡技术
//  Created on:      13-7月-2017 0:22:35
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.bmap {
	public class Styler {

		 

		public string color{
			get;
			set;
		}

		public VisibilityType? visibility{
			get;
			set;
		}

		/// 
		/// <param name="color"></param>
		public Styler Color(string color){
		     this.color=color;
		return this; 
		}

		/// 
		/// <param name="visibility"></param>
        public Styler Visibility(VisibilityType visibility)
        {
		     this.visibility=visibility;
		return this; 
		}

	}//end Styler

}//end namespace bmap