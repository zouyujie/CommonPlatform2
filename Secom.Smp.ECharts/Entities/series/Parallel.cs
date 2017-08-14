/******************************************************************/
//  Parallel.cs
//  Implementation of the Class Parallel
//  版权所有： 紫衡技术
//  Created on:      18-7月-2017 10:19:21
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Secom.Smp.ECharts.Entities.series;
namespace Secom.Smp.ECharts.Entities.series {
	public class Parallel : ChartSeries<Parallel> {
		

          public Parallel()
        {
            this.type = ChartType.parallel;
        }

          public Parallel(string name)
              : this()
          {
            this.name = name;
        }

		public int? paralleIndex{
			get;
			set;
		}

		public bool? realtime{
			get;
			set;
		}


		/// 
		/// <param name="paralleIndex"></param>
		public Parallel ParalleIndex(int paralleIndex){
		     this.paralleIndex=paralleIndex;
		return this; 
		}

		/// 
		/// <param name="realtime"></param>
		public Parallel Realtime(bool realtime){
		     this.realtime=realtime;
		return this; 
		}

	}//end Parallel

}//end namespace series