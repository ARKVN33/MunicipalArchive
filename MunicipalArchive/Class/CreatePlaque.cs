using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalArchive.Class
{
    public class CreatePlaque
    {
        public int Id { get; set; }
        public int? Main { get; set; }
        public int? Secondary { get; set; }
        public int? Part { get; set; }
        public string Description { get; set; }

        public CreatePlaque(int id, int? main, int? secondary, int? part, string description)
        {
            Id = id;
            Main = main;
            Secondary = secondary;
            Part = part;
            Description = description;
        }
    }
}
