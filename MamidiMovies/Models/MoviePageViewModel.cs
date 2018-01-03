using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MamidiMovies.Models
{
    public class MoviePageViewModel
    {
        public int MovieId { get; set; }
        public int LoginId { get; set; }
        [Required(ErrorMessage = "You must include a movie title.")]
        [Display(Name = "Title:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The movie's four digit release year is required.")]
        [Display(Name = "Year Released:")]
        public string Year { get; set; }
        [Required(ErrorMessage = "At least one genre must be selected.")]
        [Display(Name = "Genre:")]
        public string Genre { get; set; }
        public bool IsAction { get; set; }
        public bool IsAdventure { get; set; }
        public bool IsComedy { get; set; }
        public bool IsDocumentary { get; set; }
        public bool IsDrama { get; set; }
        public bool IsFamily { get; set; }
        public bool IsHistorical { get; set; }
        public bool IsHorror { get; set; }
        public bool IsMystery { get; set; }
        public bool IsScienceFiction { get; set; }
        public bool IsCartoon { get; set; }
        public bool IsTelevisionShow { get; set; }
        public bool IsOther { get; set; }
    }
}