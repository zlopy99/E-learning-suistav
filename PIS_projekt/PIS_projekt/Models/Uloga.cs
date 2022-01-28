using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS_projekt.Models
{
    public class Uloga
    {
        public Uloga()
        {
            Korisniks = new HashSet<Korisnik>();
        }
        public int UlogaId { get; set; }
        public string NazivUloge { get; set; }

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
