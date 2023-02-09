using WebApplication3.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication3.Server.Configurations.Entities
{
    public class RiderSeedConfiguration : IEntityTypeConfiguration<Rider>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rider> builder)
        {

            builder.HasData(
                 new Rider
                 {
                     Id = 1,
                     Name = "Jack",
                     Vehicle="Bicycle",
                     DeliveryFee= 3,
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 },
                 new Rider
                 {
                     Id = 2,
                     Name = "John",
                     Vehicle = "Car",
                     DeliveryFee = 4,
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
                 );

        }
    }
}
