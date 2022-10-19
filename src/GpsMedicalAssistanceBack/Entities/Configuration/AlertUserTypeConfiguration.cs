using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class AlertUserTypeConfiguration : IEntityTypeConfiguration<AlertUserType>
    {
        public void Configure(EntityTypeBuilder<AlertUserType> builder)
        {
            builder.HasData
            (
                new AlertUserType
                {
                    Id = 1,
                    Name = "Creador",
                },
                new AlertUserType
                {
                    Id = 2,
                    Name = "Usuario en Riesgo",
                }
            );
        }
    }
}
