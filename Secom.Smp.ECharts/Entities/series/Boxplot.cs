using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.ECharts.Entities.series
{
    public class Boxplot : Rectangular<Boxplot>
    {
        public Boxplot()
        {
            this.type = ChartType.boxplot;
        }

    }
}
