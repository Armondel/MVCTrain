using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MVCTrain.Models;

namespace MVCTrain.DTO
{
    public class MovieDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte? GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}