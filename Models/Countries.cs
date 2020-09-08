using System;
using System.Collections.Generic;

namespace EFCoreDataFirstOracle.Models
{
    public partial class Countries
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal? RegionId { get; set; }

        public virtual Regions Region { get; set; }
    }
}
