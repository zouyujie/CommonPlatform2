/******************************************************************/
//  StyleJson.cs
//  Implementation of the Class StyleJson
//  版权所有： 紫衡技术
//  Created on:      13-7月-2017 0:22:34
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.bmap {
	public class StyleJson {

	 
		public string featureType{
			get;
			set;
		}

		public string elementType{
			get;
			set;
		}

		public Styler stylers{
			get;
			set;
		}

		/// 
		/// <param name="featureType"></param>
		public StyleJson FeatureType(string featureType){
		     this.featureType=featureType;
		return this; 
		}

		/// 
		/// <param name="elementType"></param>
		public StyleJson ElementType(string elementType){
		     this.elementType=elementType;
		return this; 
		}

		/// 
		/// <param name="stylers"></param>
		public StyleJson Stylers(Styler stylers){
		     this.stylers=stylers;
		return this; 
		}

	}//end StyleJson

}//end namespace bmap