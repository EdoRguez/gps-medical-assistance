using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class UserParameters
    {
        public char? Identificationtype { get; set; }
        public string? Identification { get; set; }
        public List<string>? Includes { get; set; }
    }
}
