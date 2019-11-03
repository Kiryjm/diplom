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

        public string Type { get; set; }

        public virtual ICollection<Param> Params { get; set; }

    }
}