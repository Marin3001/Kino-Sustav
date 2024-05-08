
using Microsoft.Data.Sqlite;
using Cinema_API.Models;
using Cinema_API.Configuration;
using Microsoft.Extensions.Options;


namespace Cinema_API.Repositories
{
    public class CinemaRepository_SQL : ICinemaRepository
    {
        private readonly string _connectionString;
        private readonly string _dbDatetimeFormat = "yyyy-MM-dd hh:mm:ss.fff";

        public CinemaRepository_SQL(IOptions<DBConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
        }
        


        public bool AddCinema(Cinema cinema)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO Cinema (Name, Location, Movie, Rows, Seats)
                VALUES ($name, $location, $movie, $rows, $seats)";

            command.Parameters.AddWithValue("$name", cinema.Name);
            command.Parameters.AddWithValue("$location", cinema.Location);
            command.Parameters.AddWithValue("$movie", cinema.Movie);
            command.Parameters.AddWithValue("$rows", cinema.Rows);
            command.Parameters.AddWithValue("$seats", cinema.Seats);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException("Could not insert cinema into database.");
                return false;
            }
            else return true;
        }

        public bool DeleteCinema(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    DELETE FROM Cinema
                    WHERE ID == $id";
            command.Parameters.AddWithValue("$id", id);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected < 1)
            {
                return false;

                throw new ArgumentException($"No cinemas with ID = {id}.");

            }
            else return true;
        }



        public List<Cinema> GetAllCinemas()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT Id, Name, Location, Movie, Rows, Seats FROM Cinema";

            using var reader = command.ExecuteReader();

            var results = new List<Cinema>();
            while (reader.Read())
            {

                var row = new Cinema
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Location = reader.GetString(2),
                    Movie = reader.GetString(3),
                    Rows = reader.GetInt32(4),
                    Seats = reader.GetInt32(5)
                };

                results.Add(row);
            }

            return results;

        }

        public Cinema? GetCinemaById(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT Id, Name, Location, Movie, Rows, Seats FROM Cinema WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            Cinema result = null;

            if (reader.Read())
            {
                result = new Cinema
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Location = reader.GetString(2),
                    Movie = reader.GetString(3),
                    Rows = reader.GetInt32(4),
                    Seats = reader.GetInt32(5)
                };

            }

            return result;
        }

        
        public bool UpdateCinema(int id, Cinema? updatedCinema)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE Cinema
                SET
                    Name = $name,
                    Location = $location,
                    Movie = $movie,
                    Rows = $rows,
                    Seats = $seats
                WHERE
                    ID == $id";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$name", updatedCinema.Name);
            command.Parameters.AddWithValue("$location", updatedCinema.Location);
            command.Parameters.AddWithValue("$movie", updatedCinema.Movie);
            command.Parameters.AddWithValue("$rows", updatedCinema.Rows);
            command.Parameters.AddWithValue("$seats", updatedCinema.Seats);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                return false;
                throw new ArgumentException($"Could not update cinema with ID = {id}.");
            }
            else return true;
        }
    }
}


    

