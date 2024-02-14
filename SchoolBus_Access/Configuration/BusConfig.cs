using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Configuration
{
    public class BusConfig : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnName("Fullname")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Number).HasColumnName("BusNumber")
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.SeatCount).HasDefaultValue(15);

            //FlluentApi relation

            builder.HasOne(b => b.Driver)
                .WithOne(d => d.Bus)
                .HasForeignKey<Driver>(d => d.BusId);


            builder.HasMany(b => b.Students)
                .WithOne(s => s.Bus)
                .HasForeignKey(s => s.BusId);

            builder.HasMany(b => b.Routes)
                 .WithOne(r => r.Bus)
                 .HasForeignKey(r => r.BusId);
            //HasData
            builder.HasData(new Bus { Id = 1, Name = "Bus1", Number = "90-BS-234", SeatCount = 25 });

        }
    }
}
