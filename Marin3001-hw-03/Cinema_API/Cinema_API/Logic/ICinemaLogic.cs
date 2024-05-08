using Cinema_API.Models;


namespace Cinema_API.Logic
{
    public interface ICinemaLogic
    {
        void AddCinema(Cinema? cinema);
        void UpdateCinema(int id, Cinema? cinema);
        Cinema? GetCinemaById(int id);
        IEnumerable<Cinema> GetAllCinemas();
        void DeleteCinema(int id);

    }
}
