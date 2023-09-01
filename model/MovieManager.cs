using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MovieAdvanced2.model
{
    internal class MovieManager
    {
        private static string fileName = "C:\\Users\\acer\\Documents\\.NET_TRAINING\\V STUDIO\\OOPS\\OOPS4\\dotNetCore\\MOVIE_APP\\movieAppAdvanced\\data\\movies.dat";
        private static List<Movies> movies = new List<Movies>();

        public static void AddMovie(string id, string name, string genre)
        {
            if (movies.Count >= 5)
            {
                Console.WriteLine("Storage is full. Cannot add more movies.");
                return;
            }

            Movies newMovie = new Movies(id, name, genre);
            movies.Add(newMovie);
            Console.WriteLine("Movie added successfully.");
        }

        public static string ClearMovies()
        {
            movies.Clear();
            return "MoviesCleared";
        }

        public static List<Movies> GetMovies()
        {
            return movies;
        }

        public static string SaveToFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movies);
            }
            return "Movies saved. Exiting...";
        }

        public static void LoadFromFile(string fileName)
        {
            movies.Clear();
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    movies = (List<Movies>)formatter.Deserialize(fileStream);
                }
            }
        }

        public static List<string> GetMovieDetails()
        {
            List<string> movieDetails = new List<string>();

            foreach (var movie in movies)
            {
                movieDetails.Add($"ID: {movie.ID}, Name: {movie.Name}, Genre: {movie.Genre}");
            }

            return movieDetails;
        }

        public static string SetMovieDetail()
        {
            Console.WriteLine("Enter Movie ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Movie Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Movie Genre:");
            string genre = Console.ReadLine();

            AddMovie(id, name, genre);

            return "Movie added successfully.";
        }
    }
}
