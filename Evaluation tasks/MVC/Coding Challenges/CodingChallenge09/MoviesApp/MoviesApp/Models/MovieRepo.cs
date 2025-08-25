using MoviesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Models
{
    public class MovieRepo : IMovieRepository
    {
        private readonly MoviesDbContext _db = new MoviesDbContext();

        public IEnumerable<Movies> GetAll()
        {
            return from m in _db.Movies
                   select m;
        }

        public Movies GetById(int id)
        {
            return _db.Movies.FirstOrDefault(m => m.Mid == id);
        }

        public void Add(Movies movie)
        {
            _db.Movies.Add(movie);
        }

        public void Update(Movies movie)
        {
            var target = _db.Movies.FirstOrDefault(m => m.Mid == movie.Mid);
            if (target != null)
            {
                target.Moviename = movie.Moviename;
                target.DirectorName = movie.DirectorName;
                target.DateofRelease = movie.DateofRelease;
               
            }
        }

        public void Delete(int id)
        {
            var toDelete = _db.Movies.FirstOrDefault(m => m.Mid == id);
            if (toDelete != null)
            {
                _db.Movies.Remove(toDelete);
            }
        }

        public IEnumerable<Movies> MoviesByYear(int year)
        {
            return from m in _db.Movies
                   where m.DateofRelease.Year == year
                   select m;
        }

        public IEnumerable<Movies> MoviesByDirector(string directorName)
        {
            return _db.Movies
                      .Where(m => m.DirectorName != null && m.DirectorName.ToLower() == directorName.ToLower());
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
