using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    static class ControlTeams
    {

        public static List<Teams> teams = new List<Teams>();
        public static void AddTeam()
        {
            //Create teams

           

            teams.Add(new Teams(1, "Boca Juniors"));

            teams.Add(new Teams(2, "River Plate"));

            teams.Add(new Teams(3, "Racing Club"));

            teams.Add(new Teams(4, "Independiente"));

            teams.Add(new Teams(5, "San Lorenzo"));

            



        }

        public static void ShowTeams()
        {

            foreach (Teams team in teams)
            {
                Console.WriteLine("Id: " + team.TeamId + " Team: " +  team.TeamName);
            }
        }

        public static string GetTeamName(int teamId)
        {
            string teamName = "";
            foreach (Teams team in teams)
            {
                if (team.TeamId == teamId)
                {
                    teamName = team.TeamName;
                }
            }
            return teamName;
        }

        
    }
}
