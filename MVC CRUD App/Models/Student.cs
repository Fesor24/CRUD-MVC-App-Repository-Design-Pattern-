using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_App.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [MinLength(10, ErrorMessage ="Number can not be less than 10 digits")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime RegistrationDate { get; set; }
    }
}
