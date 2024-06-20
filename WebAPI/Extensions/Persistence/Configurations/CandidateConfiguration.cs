using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions.Entities;

namespace WebAPI.Extensions.Persistence.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Comment).IsRequired().HasMaxLength(3);
        }
    }
}