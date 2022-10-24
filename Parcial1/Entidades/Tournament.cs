using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
    class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }

        //Foreign keys
        public int TeamId { get; set; }
       
        public Tournament(int id, string name, int TId)
        {
            TournamentId = id;
            Name = name;
            TeamId = TId;
        }
        
        
    }
}
