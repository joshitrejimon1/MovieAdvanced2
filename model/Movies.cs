using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAdvanced2.model
{
    internal class Movies
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public Movies(string iD, string name, string genre)
        {
            ID = iD;
            Name = name;
            Genre = genre;
        }
    }
}
