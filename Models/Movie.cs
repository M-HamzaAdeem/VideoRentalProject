using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalProject.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual ICollection<Genre> Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}