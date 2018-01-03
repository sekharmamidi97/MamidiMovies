using MamidiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamidiMovies.DAL
{
    public interface IMovieDAL
    {
        MoviePageViewModel GetMovieInfoByMovieId(int movieId);
        bool AddMovieInformation(MoviePageViewModel movie);
        MoviePageViewModel GetMovieByTitle(string title);
        MoviePageViewModel GetMovieByYear(string year);
        MoviePageViewModel GetMovieByTitleYear(string title, string year);
    }
}
