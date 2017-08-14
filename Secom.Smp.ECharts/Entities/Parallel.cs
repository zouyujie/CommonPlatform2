/******************************************************************/
//  Parallel.cs
//  Implementation of the Class Parallel
//  版权所有： 紫衡技术
//  Created on:      18-7月-2017 8:45:43
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.axis;

namespace Secom.Smp.ECharts.Entities {
	public class Parallel : Basic<Parallel> {	

		public bool? axisExpandable{
			get;
			set;
		}

		public int? axisExpandCenter{
			get;
			set;
		}

		public int? axisExpandCount{
			get;
			set;
		}

		public int? axisExpandWidth{
			get;
			set;
		}

		public Axis parallelAxisDefault{
			get;
			set;
		}

		/// 
		/// <param name="axisExpandable"></param>
		public Parallel AxisExpandable(bool axisExpandable){
		     this.axisExpandable=axisExpandable;
		return this; 
		}

		/// 
		/// <param name="axisExpandCenter"></param>
		public Parallel AxisExpandCenter(int axisExpandCenter){
		     this.axisExpandCenter=axisExpandCenter;
		return this; 
		}

		/// 
        /// <param name="axisExpandCount"></param>
        public Parallel AxisExpandCount(int axisExpandCount)
        {
            this.axisExpandCount = axisExpandCount;
		return this; 
		}

		/// 
		/// <param name="axisExpandWidth"></param>
		public Parallel AxisExpandWidth(int axisExpandWidth){
		     this.axisExpandWidth=axisExpandWidth;
		return this; 
		}

	    /// 
	    /// <param name="paralleAxisDefault"></param>
	    public Parallel ParallelAxisDefault(Axis parallelAxisDefault)
	    {
	        this.parallelAxisDefault = parallelAxisDefault;
	        return this;
	    }

       

	}//end Parallel

}//end namespace Entities