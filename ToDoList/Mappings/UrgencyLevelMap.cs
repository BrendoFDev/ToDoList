using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Mappings
{
    public class UrgencyLevelMap : IEntityTypeConfiguration<Models.UrgencyLevel>
    {
        public void Configure(EntityTypeBuilder<Models.UrgencyLevel> builder)
        {
            builder.ToTable("UrgencyLevel");
            builder.HasKey(x => x.Id);
        }
    }
}
