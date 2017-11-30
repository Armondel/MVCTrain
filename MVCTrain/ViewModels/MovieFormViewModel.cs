using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTrain.Models;

namespace MVCTrain.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}