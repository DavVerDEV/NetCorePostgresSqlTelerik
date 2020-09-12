using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCorePostgresSqlTelerik.Models
{
    public class Corsi
    {
        [Key]
        public int id { get; set; }

        public string descrizione { get; set; }

        public string titolo { get; set; }

        public int numMaxPrenotati { get; set; }

        public DateTime dIniziale { get; set; }
        
        public DateTime dFinale { get; set; }

        public List<int> ore { get; set; }
        
    }
}
