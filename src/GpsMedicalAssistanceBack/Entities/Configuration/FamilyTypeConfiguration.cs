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
    public class FamilyTypeConfiguration : IEntityTypeConfiguration<FamilyType>
    {
        public void Configure(EntityTypeBuilder<FamilyType> builder)
        {
            builder.HasData
            (
                new FamilyType
                {
                    Id = 1,
                    Name = "Padre",
                },
                new FamilyType
                {
                    Id = 2,
                    Name = "Madre",
                },
                new FamilyType
                {
                    Id = 3,
                    Name = "Abuelo/a",
                },
                new FamilyType
                {
                    Id = 4,
                    Name = "Hermano/a",
                },
                new FamilyType
                {
                    Id = 5,
                    Name = "Tío/a",
                },
                new FamilyType
                {
                    Id = 6,
                    Name = "Primo/a",
                },
                new FamilyType
                {
                    Id = 7,
                    Name = "Esposo/a",
                },
                new FamilyType
                {
                    Id = 8,
                    Name = "Novio/a",
                },
                new FamilyType
                {
                    Id = 9,
                    Name = "Amigo/a",
                }
            );
        }
    }
}
