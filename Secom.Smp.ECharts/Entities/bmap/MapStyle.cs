/******************************************************************/
//  MapStyle.cs
//  Implementation of the Class MapStyle
//  版权所有： 紫衡技术
//  Created on:      13-7月-2017 0:22:34
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.bmap {
	public class MapStyle {

	    public IList<StyleJson> styleJson { get; set; }
         
		 

		/// 
		/// <param name="stylejson"></param>
		public MapStyle StyleJson(IList<StyleJson> styleJson){
            this.styleJson = styleJson;
		return this; 
		}

	}//end MapStyle

}//end namespace bmap