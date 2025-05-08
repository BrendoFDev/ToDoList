using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Mappings
{
    public class TaskStatusMap : IEntityTypeConfiguration<Models.TaskStatus> 
    {
        public void Configure(EntityTypeBuilder<Models.TaskStatus> builder)
        {
            builder.ToTable("TaskStatus");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }
}
