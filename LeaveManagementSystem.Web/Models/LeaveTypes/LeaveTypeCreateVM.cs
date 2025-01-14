using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(3,150, ErrorMessage= "The Character Length should be between 3- 150")]
        public string LeaveTypeName { get; set; } = string.Empty;
        [Required]
        [Range(1,30)]
        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
