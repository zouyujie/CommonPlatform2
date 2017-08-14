using Secom.Smp.Web.Maintain.Enums;
using System;

namespace Secom.Smp.Web.Maintain.Filters
{
    public class RepairSeach
    {
        public string OrdersNumer { get; set; }
        public DateTime? RepairTimeStart { get; set; }
        public DateTime? RepairTimeEnd { get; set; }
        public RepairOrderEnum RepairOrderStatus { get; set; }
    }
}