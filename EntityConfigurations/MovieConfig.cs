using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VideoRentalProject.Models;

namespace VideoRentalProject.EntityConfigurations
{
    public class MovieConfig:EntityTypeConfiguration<Movie>
    {
        public MovieConfig()
        {   HasMany(g => g.Genre)
                .WithMany(m => m.Movie)
                .Map(m =>
                {
                    m.ToTable("MoviesGenre");
                    m.MapLeftKey("MovieId");
                    m.MapRightKey("GenreId");
                });
        }
               
    }
}