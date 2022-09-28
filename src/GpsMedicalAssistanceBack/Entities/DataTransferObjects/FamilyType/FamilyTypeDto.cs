using Entities.DataTransferObjects.Family;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.FamilyType
{
    public class FamilyTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FamilyDto> Families { get; set; }
    }
}
