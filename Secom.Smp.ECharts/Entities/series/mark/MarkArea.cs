using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secom.Smp.ECharts.Entities.style;

namespace Secom.Smp.ECharts.Entities.series.mark
{
    public class MarkArea : AbstractData<MarkArea>
    {
        public ItemStyle itemStyle { get; set; }

        public ItemStyle ItemStyle()
        {
            if(this.itemStyle==null)
                this.itemStyle = new ItemStyle();
            return this.itemStyle;
        }


    }
}
