using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public enum WorkStatus
{
    PendingReview,
    Approved,
    RequiresRevision,
    NeedsReview,
    NeedsUploudWorkFile
}

public class Work
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    [ForeignKey("Supervisor")]
    public int SupervisorId { get; set; }
    public Supervisor Supervisor { get; set; }
    
    [MaxLength(500)]
    public string WorkFileLink { get; set; }
    
    [MaxLength(500)]
    public string ReviewFileLink { get; set; }
    
    public bool IsSubmittedOnTime { get; set; }
    public DateTime Deadline { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    [ForeignKey("Consultant")]
    public int? ConsultantId { get; set; }
    public Consultant Consultant { get; set; }
    
    public WorkStatus Status { get; set; } = WorkStatus.NeedsReview;
}