using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
   public class Statistics
    {
        public int statisticsID { get; set; }     
        //Foreign keys
        public int TournamentID { get; set; }
        public int TeamID { get; set; }
        public int Points { get; set; }
        public int Matches { get; set; }
        public int Goalsfor { get; set; }
        public int Goalsagainst { get; set; }
        public int Goaldifference { get; set; }
       
        public Statistics(int tournamentID, int teamID, int points, int matches, int goalsfor, int goalsagainst, int goaldifference)
        {
            TournamentID = tournamentID;
            TeamID = teamID;
            Points = points;
            Matches = matches;
            Goalsfor = goalsfor;
            Goalsagainst = goalsagainst;
            Goaldifference = goaldifference;
        }
        

    }
}
