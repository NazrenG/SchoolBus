using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;


namespace SchoolBus_Access.Configuration
{
    public class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1,1);

            builder.Property(x => x.Name).HasColumnName("FirstName")
                .HasColumnType("nvarchar(15)").IsRequired();

            builder.Property(x => x.LastName).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Username).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(15)").IsRequired(false);
            builder.Property(x => x.Licence).HasDefaultValue(false);
           
            //hasdata
            builder.HasData(new Driver { Id = 1 ,Name="Elmar",LastName="Aliyev",Username="aliyev",Password="1111",Phone="050-456-65-64",Licence=true,BusId=1});
        }
    }
}
