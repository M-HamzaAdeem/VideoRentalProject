using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalProject.Models;

namespace VideoRentalProject.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Enter Movie Name")]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Enter Release Date")]

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
       

        [Required(ErrorMessage = "Enter Stock ")]
        [Range(1, 20, ErrorMessage = "Stock Must be Between 1 and 20")]
        [Display(Name = "Available  Stock")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Select One Or More Genre (Use Ctrl to Select More then One)")]
        public int[] SelectedGenreIds { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
        }
    }
}