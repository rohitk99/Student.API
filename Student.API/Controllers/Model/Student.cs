using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.API.Controllers.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudId { get; set; }
        [Required,MaxLength(50)]
        public string StudName { get; set; } = String.Empty;
        [Required ,MaxLength(10)]
        public string MobileNo { get; set; } = String.Empty;
        [Required, MaxLength(50)]
        public string Email { get; set; } = String.Empty;
        [MaxLength(50)]
        public string City { get; set; } = String.Empty;
        [MaxLength(50)]
        public string State { get; set; } = String.Empty;
        [MaxLength(6)]
        public string Pincode { get; set; } = String.Empty;
        [MaxLength(2000)]
        public string Address1 { get; set; } = String.Empty;
        [MaxLength(2000)]
        public string Address2 { get; set; } = String.Empty;


    }
}
