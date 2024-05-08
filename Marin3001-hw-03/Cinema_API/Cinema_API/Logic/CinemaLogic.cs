using Cinema_API.Logic;
using Microsoft.Extensions.Options;
using Cinema_API.Configuration;
using Cinema_API.Exceptions;
using Cinema_API.Models;
using System.Text.RegularExpressions;
using Cinema_API.Repositories;




namespace Cinema_API.Logic
{
    public class CinemaLogic : ICinemaLogic

    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly ValidationConfiguration _validationConfiguration;
        public CinemaLogic(ICinemaRepository cinemaRepository, IOptions<ValidationConfiguration> configuration)
        {
             _cinemaRepository = cinemaRepository;
            _validationConfiguration = configuration.Value;
        }
        private void NameValidation(string? name)
        {
            if (name is null)
            {
                throw new UserErrorException("Name field cannot be empty.");
            }

            if (!Regex.IsMatch(name, _validationConfiguration.CinemaRegex))
            {
                throw new UserErrorException($"Name format invalid for sender '{name}'");
            }

            if (name.Length > _validationConfiguration.NameMaxCharacters)
            {
                throw new UserErrorException($"Name field too long. Exceeded {_validationConfiguration.NameMaxCharacters} characters");
            }
        }
        private void LocationValidation(string? location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new UserErrorException("Location field cannot be empty.");
            }

            if (location.Length > _validationConfiguration.LocationMaxCharacters)
            {
                throw new UserErrorException($"Location field too long. Exceeded {_validationConfiguration.LocationMaxCharacters} characters");
            }

        }
        private void MovieValidation(string? movie)
        {
            if (string.IsNullOrEmpty(movie))
            {
                throw new UserErrorException("Movie field cannot be empty.");
            }

            if (movie.Length > _validationConfiguration.MovieMaxCharacters)
            {
                throw new UserErrorException($"Movie field too long. Exceeded {_validationConfiguration.MovieMaxCharacters} characters");
            }

        }
        private void RowsValidation(int? rows)
        {
            
            if(rows>=_validationConfiguration.RowsMaxValue)  
            {
                throw new UserErrorException($"Too big rows number, max rows number  is {_validationConfiguration.RowsMaxValue}.");
            }
        }
        private void SeatsValidation(int? seats)
        {
            if (seats >= _validationConfiguration.SeatsMaxValue)
            {
                throw new UserErrorException($"Too big seats number, max seats number  is {_validationConfiguration.SeatsMaxValue}.");
            }
        }
        public void AddCinema(Cinema? cinema)
        {
            // Check all arguments
            if (cinema is null)
            {
                throw new UserErrorException("Cannot create a new cinema. No cinema specified or the cinema is invalid.");
            }

            // Sanitize inputs
            cinema.Id = -1;

            
           

            NameValidation(cinema.Name);
            LocationValidation(cinema.Location);
            MovieValidation(cinema.Movie);
            RowsValidation(cinema.Rows);
            SeatsValidation(cinema.Seats);

            // All fields validated, continue...

            // Set email timestamp to current time
            // (use UTC for cross-timezone compatibility)
            

            _cinemaRepository.AddCinema(cinema);
        }

        public void UpdateCinema(int id, Cinema? cinema)
        {
            // Check all arguments
            if (cinema is null)
            {
                throw new UserErrorException("Cannot create a new cinema. No cinema specified or the cinema is invalid.");
            }

            // Sanitize inputs
            cinema.Id = -1;



            NameValidation(cinema.Name);
            LocationValidation(cinema.Location);
            MovieValidation(cinema.Movie);
            RowsValidation(cinema.Rows);
            SeatsValidation(cinema.Seats);

            // All fields validated, continue...

            _cinemaRepository.UpdateCinema(id, cinema);
        }

        public void DeleteCinema(int id)
        {
            if (_cinemaRepository.GetCinemaById(id) is null)
            {
                throw new UserErrorException($"Unable to find the requested cinema with id {id} to be deleted.");
            }
            else
            {
                _cinemaRepository.DeleteCinema(id);
            }
        }

        public Cinema? GetCinemaById(int id)
        {
            return _cinemaRepository.GetCinemaById(id);
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _cinemaRepository.GetAllCinemas();
        }


    }
}
