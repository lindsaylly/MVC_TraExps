using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string ProvName { get; set; }
        public string ProvAbbr { get; set; }
        public int CountryId { get; set; }
    }
}
