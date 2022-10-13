using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Test1
    {
        [Key]
        public int Id { get; set; }
        public string? Fname { get; set; }
        [Required(ErrorMessage ="Enter The First Name")]
        [StringLength(15, MinimumLength =2, ErrorMessage = "Name must consist of minimum 2 characters")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string? Lname { get; set; }
    }
}
