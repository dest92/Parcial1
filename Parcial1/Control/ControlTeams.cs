using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
     class ControlTeams
    {

        public List<Teams> teams;
        public void AddTeam()
        {
            //Create teams

            teams = new List<Teams>();

            teams.Add(new Teams(1, "Boca Juniors"));

            teams.Add(new Teams(2, "River Plate"));

            teams.Add(new Teams(3, "Racing Club"));

            teams.Add(new Teams(4, "Independiente"));

            teams.Add(new Teams(5, "San Lorenzo"));

            



        }

        public  void ShowTeams()
        {

            foreach (Teams team in teams)
            {
                Console.WriteLine("Id: " + team.TeamId + " Team: " +  team.TeamName);
            }

        }

    }
}
