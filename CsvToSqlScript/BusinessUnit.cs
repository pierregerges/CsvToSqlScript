using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToSqlScript
{
    internal class BusinessUnit
    {
        public int BusinessUnitId { get; set; }
        public int CostCenterCode { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public bool Show{ get; set; }
    }
}
