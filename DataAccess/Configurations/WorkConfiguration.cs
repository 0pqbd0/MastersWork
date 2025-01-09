using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Entities;

namespace DataAccess.Configurations;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.WorkFileLink)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(w => w.ReviewFileLink)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(w => w.IsSubmittedOnTime)
            .IsRequired();

        builder.Property(w => w.Deadline)
            .IsRequired();

        builder.HasOne(w => w.Student)
            .WithMany()
            .HasForeignKey(w => w.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Supervisor)
            .WithMany()
            .HasForeignKey(w => w.SupervisorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Category)
            .WithMany()
            .HasForeignKey(w => w.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(w => w.Consultant)
            .WithMany()
            .HasForeignKey(w => w.ConsultantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}