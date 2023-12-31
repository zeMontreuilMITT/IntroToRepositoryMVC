﻿using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IntroToRepositoryMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
