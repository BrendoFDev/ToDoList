using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Mappings
{
    public class TaskMap: IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasDefaultValue("");
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.UrgencyLevel).HasColumnName("urgencyLevel").IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("creationDate").IsRequired();
            builder.Property(x => x.ExpirationDate).HasColumnName("expirationDate").IsRequired();
        }
    }
}
