using MamidiMovies.DAL;
using MamidiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MamidiMovies.Controllers
{
    public class MoviePageController : MamidiMoviesController
    {
        private IMovieDAL movieDAL;

        public MoviePageController(IMovieDAL movieDAL)
        {
            this.movieDAL = movieDAL;
        }

        public MoviePageController()
        {

        }

        public ActionResult MoviePage()
        {
            return View("MoviePage");
        }

        [HttpPost]
        public ActionResult MoviePage(MoviePageViewModel model)
        {
            return View("MoviePage");
        }

        //Get Add Movie Information
        public ActionResult AddMovieInformation()
        {
            return View("MoviePage");
        }

        //Post Add Movie Information
        [HttpPost]
        public ActionResult AddMovieInformation(MoviePageViewModel movie)
        {
            if (movie.Title == null)
            {
                movie.Title = "";
            }
            if (movie.Year == null)
            {
                movie.Year = "";
            }
            if (movie.IsAction == false)
            {
                movie.IsAction = false;
            }
            if (movie.IsAdventure == false)
            {
                movie.IsAdventure = false;
            }
            if (movie.IsComedy == false)
            {
                movie.IsComedy = false;
            }
            if (movie.IsDocumentary == false)
            {
                movie.IsDocumentary = false;
            }
            if (movie.IsDrama == false)
            {
                movie.IsDrama = false;
            }
            if (movie.IsFamily == false)
            {
                movie.IsFamily = false;
            }
            if (movie.IsHistorical == false)
            {
                movie.IsHistorical = false;
            }
            if (movie.IsHorror == false)
            {
                movie.IsHorror = false;
            }
            if (movie.IsMystery == false)
            {
                movie.IsMystery = false;
            }
            if (movie.IsScienceFiction == false)
            {
                movie.IsScienceFiction = false;
            }
            if (movie.IsCartoon == false)
            {
                movie.IsCartoon = false;
            }
            if (movie.IsTelevisionShow == false)
            {
                movie.IsTelevisionShow = false;
            }
            if (movie.IsOther == false)
            {
                movie.IsOther = false;
            }
            movieDAL.AddMovieInformation(movie);
            return RedirectToAction("ThankYou");
        }

        //GET: ThankYou
        public ActionResult ThankYou()
        {
            return View("ThankYou");
        }
    }
}