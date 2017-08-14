/******************************************************************/
//  EffectScatter.cs
//  Implementation of the Class EffectScatter
//  版权所有： 紫衡技术
//  Created on:      15-7月-2017 22:04:53
//  创建者: 邹琼俊
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Secom.Smp.ECharts.Entities.series;
namespace Secom.Smp.ECharts.Entities.series {
	public class EffectScatter : Scatter {

	    public string effectType { get; set; }

        public ShowEffectType showEffectOn { get; set; }


	    public RippleEffect rippleEffect { get; set; }

	    public EffectScatter EffectType(string effectType)
	    {
	        this.effectType = effectType;
	        return this;
	    }

        public EffectScatter ShowEffectOn(ShowEffectType showEffectOn)
        {
            this.showEffectOn = showEffectOn;
            
            return this;
        }

        public RippleEffect RippleEffect()
        {
            if (this.rippleEffect == null)
                rippleEffect = new RippleEffect();
            return rippleEffect;
        }

        public RippleEffect RippleEffect(RippleEffect rippleEffect)
	    {
            this.rippleEffect = rippleEffect;
	        return rippleEffect;
	    }

	    public EffectScatter()
	    {
	        this.type = ChartType.effectScatter;
	    }

        public EffectScatter(string name)
            : this()
        {
            this.name = name;
        }


        
	}//end EffectScatter

}//end namespace series