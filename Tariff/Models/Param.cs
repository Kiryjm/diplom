using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tariff.Models
{
    public class Param
    {
        public int Id { get; set; }

        public int ParamTypeId { get; set; }

        public int RateId { get; set; }

        public string Value { get; set; }

        public ParamType ParamType { get; set; }

        public IEnumerable<Rate> Rates { get; set; }

    }
}