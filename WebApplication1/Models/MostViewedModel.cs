using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MostViewedModel
    {
        /// <summary>
        /// filmin idsi
        /// </summary>
        public int MovieId { get; set; }
        /// <summary>
        /// filmin kiralanma sayısı
        /// </summary>
        public int Count { get; set; }

        public Movies Movie { get; set; }

    }
}