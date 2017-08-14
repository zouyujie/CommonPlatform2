/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Data.Areas.Base.Controllers
* 文件名: DefaultController
* 创建者: 邹琼俊
* 创建时间: 2017/6/23 10:02:24
* 版权所有： 紫衡技术
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Secom.Smp.ECharts.Entities {
	public class Controller {



        public VisualItem inRange
        {
			get;
			set;
		}

        public VisualItem outOfRange
        {
			get;
			set;
		}

        public VisualItem InRange()
        {
            if(this.inRange==null)
                this.inRange = new VisualItem();
            return this.inRange;
        }


        public VisualItem OutOfRange()
        {
            if (this.outOfRange == null)
                this.outOfRange = new VisualItem();
            return this.outOfRange;
        }

	    /// 
	    /// <param name="inRange"></param>
	    public Controller InRange(VisualItem inRange)
	    {
	        this.inRange = inRange;
	        return this;
	    }

	    /// 
		/// <param name="outOfRange"></param>
		public Controller OutOfRange(VisualItem outOfRange){
		     this.outOfRange=outOfRange;
		return this; 
		}

	}//end Controller

}//end namespace Entities