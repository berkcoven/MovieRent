using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CategoryFilms
    {
        public List<Categories> categories = new List<Categories>();
        public List<Movies> movies = new List<Movies>();
        public int selectedCatId { get; set; }

    }
}