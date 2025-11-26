using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Specification
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(t => t.ImageUrl)
                   .HasMaxLength(300);


            builder.Property(t => t.TravelDate)
                   .IsRequired();
        }
    }
}
