using System.ComponentModel.DataAnnotations;

namespace EmployeeDetail.Model
{
    public class EmployeeDetails
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
       
    }
}
