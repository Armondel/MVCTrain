using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTrain.Models
{
    public class Movie
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public byte? GenreId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }

        public byte NumberInStock { get; set; }
    }
}