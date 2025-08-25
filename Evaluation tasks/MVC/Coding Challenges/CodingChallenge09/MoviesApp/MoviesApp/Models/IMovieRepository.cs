
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetAll();
        Movies GetById(int id);
        void Add(Movies movie);
        void Update(Movies movie);
        void Delete(int id);
        IEnumerable<Movies> MoviesByYear(int year);
        IEnumerable<Movies> MoviesByDirector(string directorName);
        void Save();
    }

}