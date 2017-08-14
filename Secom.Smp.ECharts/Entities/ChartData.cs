/******************************************************************/
//  ChartData.cs
//  Implementation of the Class ChartData
//  版权所有： 紫衡技术
//  Created on:      11-7月-2017 12:14:38
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities {
	public class ChartData {
        public string title
        {
            get;
            set;
        }

        public string ajax { get; set; }

        public IList<object> raw { get; set; }        

	    public Dictionary<string, object> data { get; set; }

        public IList<object> beforeRaw { get; set; }

	    public Dictionary<string, object> fun { get; set; }

        public Dictionary<string, object> fundata { get; set; }

	    public bool IsSetOption { get; set; }




	    public ChartOption option{
			get;
			set;
		}
 
		 

		/// 
		/// <param name="title"></param>
		public ChartData Title(string title){
		     this.title=title;
		return this; 
		}


	    public ChartData AddData(string name, object data)
	    {
	        if(this.data==null)
                this.data = new Dictionary<string, object>();
	        this.data.Add(name, data);
            return this;
	    }

        public ChartData AddFunData(string name, object data)
        {
            if (this.fundata == null)
                this.fundata = new Dictionary<string, object>();
            this.fundata.Add(name, data);
            return this;
        }

        public ChartData AddBeforeRaw(object raw)
        {
            if (this.beforeRaw == null)
                this.beforeRaw = new List<object>();
            this.beforeRaw.Add(raw);
            return this;
        }


	    public ChartData AddRaw(object raw)
	    {
            if (this.raw == null)
                this.raw = new List<object>();
            this.raw.Add(raw);
            return this;
	    }

        public ChartData AddFun(string name, object fun)
        {
            if (this.fun == null)
                this.fun = new Dictionary<string, object>();
            this.fun.Add(name, fun);
            return this;
        }

		/// 
		/// <param name="option"></param>
		public ChartData Option(ChartOption option){
		     this.option=option;
		return this; 
		}

        public ChartData Ajax(string url)
        {
            this.ajax = url;
            return this;
        }

	}//end ChartData

}//end namespace Entities