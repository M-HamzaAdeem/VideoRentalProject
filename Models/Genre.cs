using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentalProject.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}