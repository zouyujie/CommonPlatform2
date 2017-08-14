/******************************************************************/
//  Brush.cs
//  Implementation of the Class Brush
//  版权所有： 紫衡技术
//  Created on:      18-7月-2017 14:58:04
//  创建者: 邹琼俊
/******************************************************************/

using System.Collections.Generic;
using System.Linq;
using Secom.Smp.ECharts.Entities.style;

namespace Secom.Smp.ECharts.Entities
{
    public class Brush : Basic<Brush> {	

		public IList<BrushToolBoxType> toolbox{
			get;
			set;
		}

		public object brushLink{
			get;
			set;
		}

		public object seriesIndex{
			get;
			set;
		}

		public object geoIndex{
			get;
			set;
		}

		public BrushType? brushType{
			get;
			set;
		}

		public BrushMode? brushMode{
			get;
			set;
		}

		public bool? transformable{
			get;
			set;
		}

		public BrushStyle brushStyle{
			get;
			set;
		}

		public BrushThrottleType? throttleType{
			get;
			set;
		}

		public int? throttleDelay{
			get;
			set;
		}

        public bool? removeOnClick { get; set; }

		public VisualItem inBrush{
			get;
			set;
		}

		public VisualItem outBrush{
			get;
			set;
		}

	    public BrushStyle BrushStyle()
	    {
	        if(this.brushStyle==null)
                this.brushStyle = new BrushStyle();
	        return this.brushStyle;
	    }

		/// 
		/// <param name="toolbox"></param>
		public Brush Toolbox(IList<BrushToolBoxType> toolbox){
		     this.toolbox=toolbox;
		return this; 
		}

		/// 
		/// <param name="brushLink"></param>
		public Brush BrushLink(object brushLink){
		     this.brushLink=brushLink;
		return this; 
		}

	    
	    /// 
		/// <param name="geoIndex"></param>
		public Brush GeoIndex(object geoIndex){
		     this.geoIndex=geoIndex;
		return this; 
		}

		/// 
		/// <param name="brushType"></param>
		public Brush BrushType(BrushType brushType){
		     this.brushType=brushType;
		return this; 
		}

	    /// 
	    /// <param name="burshMode"></param>
        public Brush BrushMode(BrushMode brushMode)
	    {
	        this.brushMode = brushMode;
	        return this;
	    }

	    /// 
        /// <param name="transformable"></param>
	    public Brush Transformable(bool transformable)
	    {
            this.transformable = transformable;
	        return this;
	    }

	    /// 
		/// <param name="brushStyle"></param>
		public Brush BurshStyle(BrushStyle brushStyle){
		     this.brushStyle=brushStyle;
		return this; 
		}

		/// 
		/// <param name="throttleType"></param>
		public Brush ThrottleType(BrushThrottleType throttleType){
		     this.throttleType=throttleType;
		return this; 
		}

		/// 
		/// <param name="throttleDelay"></param>
		public Brush ThrottleDelay(int throttleDelay){
		     this.throttleDelay=throttleDelay;
		return this; 
		}

		/// 
		/// <param name="removeOnClick"></param>
		public Brush RemoveOnClick(bool removeOnClick){
            this.removeOnClick = removeOnClick;
		return this; 
		}

        public VisualItem InBrush()
        {
            if(this.inBrush==null)
                this.inBrush = new VisualItem();
		  return this.inBrush; 
		}

        public VisualItem OutOfBrush()
        {
            if (this.outBrush == null)
                this.outBrush = new VisualItem();
            return this.outBrush; 
		}

		/// 
		/// <param name="seriesIndex"></param>
		public Brush SeriesIndex(string seriesIndex){
		     this.seriesIndex=seriesIndex;
		return this; 
		}

	    public Brush SeriesIndex(params int[] value)
	    {
	        this.seriesIndex = value.ToList();
	        return this;
	    }

		/// 
		/// <param name="seriesIndex"></param>
		public Brush SeriesIndex(int seriesIndex){
		     this.seriesIndex=seriesIndex;
		return this; 
		}

	}//end Brush

}//end namespace Entities