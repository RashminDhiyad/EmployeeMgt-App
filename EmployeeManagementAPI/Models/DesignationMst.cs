using System.ComponentModel.DataAnnotations;
using EmployeeManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    [Table("DesignationMst")]
    public class DesignationMst
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        public string Designation { get; set; }
    }


}