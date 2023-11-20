using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project_products.Models;

namespace project_products.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(128);
            builder.Property(x => x.Password).HasMaxLength(255);
            builder.Property(x => x.Role).HasMaxLength(128);
        }
    }
}
