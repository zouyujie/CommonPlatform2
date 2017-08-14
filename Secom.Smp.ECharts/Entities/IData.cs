using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.ECharts.Entities
{
    public interface IData<T> 
    {

        T Data(params object[] values);
    }
}
