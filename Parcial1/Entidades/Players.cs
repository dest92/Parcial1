using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
     class Players
    {

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerLastName { get; set; }
        public int PlayerAge { get; set; }
        public int ShirtNumber { get; set; }


        //Foreign key

        public int PositionId { get; set; }
        public int TeamId { get; set; }

        public Players(int id, string name, string lastname, int age, int number, int posid, int teamid)
        {
                PlayerId = id;
                PlayerName = name;
                PlayerLastName = lastname;
                PlayerAge = age;
                ShirtNumber = number;
                PositionId = posid;
                TeamId = teamid;
        }
        
    }
}
