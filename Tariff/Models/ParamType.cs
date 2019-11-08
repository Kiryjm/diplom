using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tariff.Models
{
    public class ParamType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ParamDataType? ParamDataType { get; set; }
    }
}