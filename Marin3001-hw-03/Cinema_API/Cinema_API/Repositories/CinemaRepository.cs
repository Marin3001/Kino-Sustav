using Cinema_API.Models;

namespace Cinema_API.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private List<Cinema> cinemas;

        public CinemaRepository()
        {
            cinemas = new List<Cinema>();
        }

        public bool AddCinema(Cinema cinema)
        {
            cinemas.Add(cinema);
            return true;
        }

        public List<Cinema> GetAllCinemas()
        {
            return cinemas;
        }

        public Cinema? GetCinemaById(int id)
        {
            return cinemas.FirstOrDefault(e => e.Id == id);
        }

        public bool DeleteCinema(int id)
        {
            Cinema? cinemaToRemove = GetCinemaById(id);
            if (cinemaToRemove != null)
            {
                cinemas.Remove(cinemaToRemove);
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Cinema with Id '{id}' not found.");
            }
            return false;
        }

        public bool UpdateCinema(int id, Cinema updatedCinema)
        {

            Cinema? existingCinema = GetCinemaById(id);
            if (existingCinema is not null)
            {
                existingCinema.Name = updatedCinema.Name;
                existingCinema.Location = updatedCinema.Location;
                existingCinema.Movie = updatedCinema.Movie;
                existingCinema.Rows = updatedCinema.Rows;
                existingCinema.Seats = updatedCinema.Seats;
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Cinema with Id '{id}' not found.");
            }
        }
    }
}
