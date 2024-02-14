using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;


namespace SchoolBus_Access.Configuration
{
    public class ParentConfig : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);

            builder.Property(x => x.Name).HasColumnName("FirstName")
                .HasColumnType("nvarchar(15)").IsRequired();

            builder.Property(x => x.LastName).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Username).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(15)").IsRequired(false);

           //fluentApi relation

            builder.HasMany(p => p.Students)
                .WithOne(s => s.Parent)
                .HasForeignKey(s => s.ParentId);


            //hasdata
            builder.HasData(new Parent { Id = 1, Name = "Faiq", LastName = "Quliyev", Username = "quliyev", Password = "1111", Phone = "050-456-55-56"});

        }
    }
}
