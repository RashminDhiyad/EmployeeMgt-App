using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public string Gender { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]

        public DateTime DOB { get; set; }
    }
}
