using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tariff.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Operator Operator { get; set; }

        public RateType RateType { get; set; }

        public int OperatorId { get; set; }

        public int RateTypeId { get; set; }

        public virtual List<Param> Params { get; set; }

    }
}