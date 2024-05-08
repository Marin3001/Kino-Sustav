
using Cinema_API.Models;

namespace Cinema_API.Controllers.DTO
{
    
        public class NewCinemaDTO
        {
            public string? Name { get; set; }
            public string? Location { get; set; }
            public string? Movie { get; set; }
            public int? Rows { get; set; }
            public int? Seats { get; set; }

        public Cinema ToModel()
            {
                return new Cinema
                {
                    Id = -1,
                    Name = Name,
                    Location = Location,
                    Movie = Movie,
                    Rows = Rows,
                    Seats = Seats
                };
            }
        }
    
}

