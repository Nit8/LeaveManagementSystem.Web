using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType
    {
        public required int LeaveTypeId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public required string LeaveTypeName { get; set; }
        public required int NumberOfDays { get; set; }
    }
}
