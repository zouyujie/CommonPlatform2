/******************************************************************/
//  BMap.cs
//  Implementation of the Class BMap
//  版权所有： 紫衡技术
//  Created on:      13-7月-2017 0:22:34
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities.bmap {
	public class BMap {

		 

		public IList<double> center{
			get;
			set;
		}

		public int zoom{
			get;
			set;
		}

		public bool roam{
			get;
			set;
		}

        public MapStyle mapStyle
        {
			get;
			set;
		}

		/// 
		/// <param name="center"></param>
		public BMap Center(IList<double> center){
		     this.center=center;
		return this; 
		}

       

		/// 
		/// <param name="zoom"></param>
		public BMap Zoom(int zoom){
		     this.zoom=zoom;
		return this; 
		}

		/// 
		/// <param name="roam"></param>
		public BMap Roam(bool roam){
		     this.roam=roam;
		return this; 
		}

	    /// 
	    /// <param name="mapStyle"></param>
        public MapStyle MapStyle()
	    {
	        if (this.mapStyle == null)
	            this.mapStyle = new MapStyle();
	        return this.mapStyle;
	    }

	}//end BMap

}//end namespace bmap