using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCorePostgresSqlTelerik.Models
{
    public class Prenotazioni
    {
        public int id { get; set; }

        public DateTime data {get; set;}

        public int ora { get; set; }

        public int idCorso { get; set; }

        public string idUtente { get; set; }
    }
}
