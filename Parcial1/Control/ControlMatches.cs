using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcial1.Control
{
     static class ControlMatches
    {

        public static List<Matches> matches = new List<Matches>();
        public static void AddMatch()
        {
            

            matches.Add(new Matches(1, 1, 2, 1, 1,1));
            matches.Add(new Matches(2, 3, 4, 1, 1, 1));
            matches.Add(new Matches(3, 5, 3, 1, 1, 1));
            matches.Add(new Matches(4, 2, 1, 1, 1, 1));
            matches.Add(new Matches(5, 4, 5, 1, 1, 1));
            matches.Add(new Matches(6, 3, 1, 1, 1, 1));
            matches.Add(new Matches(7, 5, 2, 1, 1, 1));
        }

        public static void ShowMatches()
        {
            
            foreach (Matches match in matches)
            {
                
                Console.WriteLine("Id: " + match.MatchId + " Tournament: " + ControlTournament.GetTournamentName(match.TournamentId) + " Local: " + ControlTeams.GetTeamName(match.LocalTeam) + " Visitor: " + ControlTeams.GetTeamName(match.VisitorTeam) + " Local goals: " + match.GoalsLocal + " Visitor goals: " + match.GoalsVisitor + " Winner: " + WinnerMatch(match.MatchId));
            }
        }

        //Return winner of a match with team name
        public static string WinnerMatch(int matchId)
        {
            string winner = "";
            foreach (Matches match in matches)
            {
                if (match.MatchId == matchId)
                {
                    if (match.GoalsLocal > match.GoalsVisitor)
                    {
                        winner = ControlTeams.GetTeamName(match.LocalTeam);
                    }
                    else if (match.GoalsLocal < match.GoalsVisitor)
                    {
                        winner = ControlTeams.GetTeamName(match.VisitorTeam);
                    }
                    else
                    {
                        winner = "Draw";
                    }
                }
            }
            return winner;
        }


      }
        
    }

