/******************************************************************/
//  MapStyle.cs
//  Implementation of the Class MapStyle
//  ��Ȩ���У� �Ϻ⼼��
//  Created on:      13-7��-2017 0:22:34
//  ������: ����
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