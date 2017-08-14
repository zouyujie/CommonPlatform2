/******************************************************************/
//  Geo.cs
//  Implementation of the Class Geo
//  版权所有： 紫衡技术
//  Created on:      16-7月-2017 22:58:20
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.style;

namespace Secom.Smp.ECharts.Entities {
	public class Geo : Basic<Geo> {

        public ChartType? type { get; set; }

        public object center { get; set; }

		public string map{
			get;
			set;
		}

	    public bool? silent { get; set; }

	    public bool? roam { get; set; }

		public double aspectScale{
			get;
			set;
		}

		public ScaleLimit scaleLimit{
			get;
			set;
		}

		public object nameMap{
			get;
			set;
		}

		public IList<string> layoutCenter{
			get;
			set;
		}

		public object layoutSize{
			get;
			set;
		}

		public Regions regions{
			get;
			set;
		}

        public ItemStyle label { get; set; }

	    public ItemStyle itemStyle { get; set; }


        public Geo Type(ChartType type)
        {
            this.type = type;
            return this;
        }

		/// 
		/// <param name="map"></param>
		public Geo Map(string map){
		     this.map=map;
		return this; 
		}

		/// 
		/// <param name="aspectScale"></param>
		public Geo AspectScale(double aspectScale){
		     this.aspectScale=aspectScale;
		return this; 
		}

	    /// 
	    /// <param name="scaleLimit"></param>
        public ScaleLimit ScaleLimit()
	    {
	        if (this.scaleLimit == null)
	            this.scaleLimit = new ScaleLimit();
	        return this.scaleLimit;
	    }

	    /// 
		/// <param name="nameMap"></param>
		public Geo NameMap(object nameMap){
		     this.nameMap=nameMap;
		return this; 
		}

		/// 
		/// <param name="layoutCenter"></param>
		public Geo LayoutCenter(IList<string> layoutCenter){
		     this.layoutCenter=layoutCenter;
		return this; 
		}

		/// 
		/// <param name="layoutSize"></param>
		public Geo LayoutSize(object layoutSize){
		     this.layoutSize=layoutSize;
		return this; 
		}

        public Regions Regions()
        {
            if(regions==null)
                this.regions = new Regions();
		  return this.regions; 
		}

        public Secom.Smp.ECharts.Entities.style.ItemStyle Label()
        {
            if(regions==null)
                this.label = new ItemStyle();
		  return label; 
		}

        public Geo Label(ItemStyle style)
        {
            this.label = style;
            return this;
        }

	    public Secom.Smp.ECharts.Entities.style.ItemStyle ItemStyle()
	    {
	        if (itemStyle == null)
	            this.itemStyle = new ItemStyle();
	        return this.itemStyle;
	    }

	    public Geo ItemStyle(ItemStyle style)
	    {
	        this.itemStyle = style;
	        return this;
	    }

		/// 
		/// <param name="roam"></param>
		public Geo Roam(bool roam){
		     this.roam=roam;
		return this; 
		}

		/// 
		/// <param name="silent"></param>
		public Geo Silent(bool silent){
		     this.silent=silent;
		return this; 
		}

        public Geo Center(object center)
        {
            this.center = center;
            return this;
        }

	}//end Geo

}//end namespace Entities