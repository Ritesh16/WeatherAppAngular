using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Statistics
{
    public class StatsOutputModel<T>
    {
        public T Value { get; set; }
        public DateTime Date { get; set; }
    }
}
