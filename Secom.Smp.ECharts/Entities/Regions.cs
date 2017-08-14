/******************************************************************/
//  Regions.cs
//  Implementation of the Class Regions
//  ��Ȩ���У� �Ϻ⼼��
//  Created on:      16-7��-2017 22:58:29
//  ������: ����
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Emit;
using Secom.Smp.ECharts.Entities.style;


namespace Secom.Smp.ECharts.Entities {
	public class Regions {

		
		public string name{
			get;
			set;
		}

		public bool selected{
			get;
			set;
		}

		public ItemStyle itemStyle{
			get;
			set;
		}

        public ItemStyle label
        {
			get;
			set;
		}

        public ItemStyle ItemStyle()
        {
            if(this.itemStyle==null)
                itemStyle = new ItemStyle();
		  return this.itemStyle; 
		}

        public ItemStyle Label()
        {
            if(this.label == null)
                label = new ItemStyle();
            return this.label; 
		}

	}//end Regions

}//end namespace Entities