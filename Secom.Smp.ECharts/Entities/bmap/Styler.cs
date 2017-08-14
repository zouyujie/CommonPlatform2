/******************************************************************/
//  Styler.cs
//  Implementation of the Class Styler
//  ��Ȩ���У� �Ϻ⼼��
//  Created on:      13-7��-2017 0:22:35
//  ������: ����
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