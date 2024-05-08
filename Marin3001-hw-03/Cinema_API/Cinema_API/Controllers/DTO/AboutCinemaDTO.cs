using Cinema_API.Models;

namespace Cinema_API.Controllers.DTO
{
    public class AboutCinemaDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Movie { get; set; }
        public int? Rows { get; set; }
        public int? Seats { get; set; }

        public static AboutCinemaDTO FromModel(Cinema cinema)
        {
            return new AboutCinemaDTO
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movie = cinema.Movie,
                Rows = cinema.Rows,
                Seats = cinema.Seats
            };
        }
    }
}

