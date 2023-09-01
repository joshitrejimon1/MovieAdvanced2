using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAdvanced2.model
{
    internal class MovieController
    {
        public MovieManager manager;

        public MovieController()
        {
            manager = new MovieManager();
        }

        public void Start()
        {
            MovieManager.LoadFromFile("C:\\Users\\acer\\Documents\\.NET_TRAINING\\V STUDIO\\OOPS\\OOPS4\\dotNetCore\\MOVIE_APP\\movieAppAdvanced\\data\\movies.txt");
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Clear Movies");
            Console.WriteLine("3. Get Movies");
            Console.WriteLine("4. Save and Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    MovieManager.SetMovieDetail();
                    break;
                case 2:
                    MovieManager.ClearMovies();       
                    break;
                case 3:
                   MovieManager.GetMovieDetails();
                    break;
                case 4:
                    MovieManager.SaveToFile("movies.txt");
                    break;
                default:
                    break;
            }

            DisplayMenu();
        }

       
    }
}
