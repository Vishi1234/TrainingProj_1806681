using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string Moviename { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofRelease { get; set; }
    }
}