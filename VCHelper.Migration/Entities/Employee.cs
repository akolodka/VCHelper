using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCHelper.Migration.Entities
{
    [Table("employee")]
    internal class Employee
    {
        [Key]
        [Column("employee_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EmployeeId { get; set; }

        [Column("last_name")]
        public string Lastname { get; set; }

        [Column("first_name")]
        public string? Firstname { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("state")]
        public string? State { get; set; } 
    }
}
