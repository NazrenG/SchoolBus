using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBus_Model.Entities.Concretes;

namespace SchoolBus_Access.Configuration
{
    public class ClassConfig:IEntityTypeConfiguration<Class>
    {

        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnName("ClassName")
                .HasMaxLength(15)
                .IsRequired();

            // //FlluentApi relation

            builder.HasMany(c => c.Students)
                .WithOne(s => s.Class)
                .HasForeignKey(s => s.ClassId);

            //has data
            builder.HasData(new Class { Id = 1, Name = "681.21" });

        }
    }
}
