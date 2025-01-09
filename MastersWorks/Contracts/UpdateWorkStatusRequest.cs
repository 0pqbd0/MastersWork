using DataAccess.Entities;

namespace MastersWorks.Contracts;

public class UpdateWorkStatusRequest
{
    public WorkStatus Status { get; set; }
    public string? Comment { get; set; }
}