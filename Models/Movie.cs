using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalProject.ViewModels;

namespace VideoRentalProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Movie Name")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Movie Genre")]
        public virtual ICollection<Genre> Genre { get; set; }
        [Required(ErrorMessage = "Enter Release Date")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required(ErrorMessage = "Enter Stock ")]
        [Range(1,20,ErrorMessage ="Stock Must be Between 1 and 20")]
        [Display(Name = "Available  Stock")]
        public int Stock { get; set; }

        /*public Movie()
        {
            ReleaseDate = DateTime.Now;
            Stock = 0;
        }*/

        public Movie()
        {
            DateAdded = DateTime.Now;
        }
        public Movie(MovieFormViewModel viewModel)
        {
            Id = (int)viewModel.Id;
            Name = viewModel.Name;
            ReleaseDate = (DateTime)viewModel.ReleaseDate;
            Stock = (int)viewModel.Stock;

        }
    }
}