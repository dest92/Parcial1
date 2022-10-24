using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
    class Teams
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

       public Teams(int id,string name)
        {
            TeamId = id;
            TeamName = name;
        }
        
    }
}

