
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JMR.Models
{
    
    [Index(nameof(Email), IsUnique =true)]
    public class Credentials
    {
        [Required]
        public string? Email{get;set;}

        [Key]
        public int Id{get;set;}

        [Required]
        public string? password{get; set;}
    }
}

