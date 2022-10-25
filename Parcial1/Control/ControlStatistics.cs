using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    static public class ControlStatistics
    {
        public static List<Statistics> statistics = new List<Statistics>();

        public static void AddStatistics()
        {

            Console.WriteLine("Input the tournament id");
            ControlTournament.ShowTournament();
             int tournamentId = int.Parse(Console.ReadLine());

            //if statistics exists delete it
            if (statistics.Exists(x => x.TournamentID == tournamentId))
            {
                statistics.RemoveAll(x => x.TournamentID == tournamentId);
            }

            

            

            foreach (Teams t in ControlTeams.teams)
            {
                int matches = 0;
                int goals = 0;
                int goalsAgainst = 0;
                int goalsDifference = 0;
                int points = 0;
                foreach (Matches m in ControlMatches.matches)
                {
                    if (m.TournamentId == tournamentId)
                    {
                        if (m.LocalTeam == t.TeamId || m.VisitorTeam == t.TeamId)
                        {
                            matches++;
                        }
                        if (m.LocalTeam == t.TeamId)
                        {

                            if (m.GoalsLocal > m.GoalsVisitor)
                            {
                                points += 3;
                            }
                            else if (m.GoalsLocal == m.GoalsVisitor)
                            {
                                points += 1;
                            }
                        }

                        if (m.LocalTeam == t.TeamId)
                        {
                            goalsDifference += m.GoalsLocal - m.GoalsVisitor;
                        }
                        else if (m.VisitorTeam == t.TeamId)
                        {
                            goalsDifference += m.GoalsVisitor - m.GoalsLocal;
                        }

                        if (m.LocalTeam == t.TeamId)
                        {
                            goalsAgainst += m.GoalsVisitor;
                        }
                        else if (m.VisitorTeam == t.TeamId)
                        {
                            goalsAgainst += m.GoalsLocal;
                        }

                        if (m.LocalTeam == t.TeamId)
                        {
                            goals += m.GoalsLocal;
                        }
                        else if (m.VisitorTeam == t.TeamId)
                        {
                            goals += m.GoalsVisitor;
                        }


                    }
                }
                if(statistics.Exists(x => x.TeamID == t.TeamId))
                {
                    statistics.RemoveAll(x => x.TeamID == t.TeamId);

                }

                statistics.Add(new Statistics(tournamentId, t.TeamId, points, matches, goals, goalsAgainst, goalsDifference));
            }
        }

        public static void ShowStatistics()
        {
            //Print all statistics

            //order by points
            var statisticsOrdered = statistics.OrderByDescending(x => x.Points).ToList();
            foreach (Statistics s in statisticsOrdered)
            {
                Console.WriteLine("Tournament: " + ControlTournament.GetTournamentName(s.TournamentID) + " Team: " + ControlTeams.GetTeamName(s.TeamID) + " Points: " + s.Points + " Matches: " + s.Matches + " Goals: " + s.Goalsfor + " Goals Against: " + s.Goalsagainst + " Goals Difference: " + s.Goaldifference);

            }

            //create a txt with statistics
            //System.IO.File.WriteAllText(@"C:\Users\Public\Statistics.txt", "Statistics" + Environment.NewLine);

            //foreach (Statistics s in statisticsOrdered)
            //{
            //    System.IO.File.AppendAllText(@"C:\Users\Public\Statistics.txt", "Tournament: " + ControlTournament.GetTournamentName(s.TournamentID) + " Team: " + ControlTeams.GetTeamName(s.TeamID) + " Points: " + s.Points + " Matches: " + s.Matches + " Goals: " + s.Goalsfor + " Goals Against: " + s.Goalsagainst + " Goals Difference: " + s.Goaldifference + Environment.NewLine);
            //}

          

            //Streamwriter
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\Statistics.txt", true))
            {
                file.WriteLine("");
                file.WriteLine("Statistics");
                foreach (Statistics s in statisticsOrdered)
                {
                    file.WriteLine("Tournament: " + ControlTournament.GetTournamentName(s.TournamentID) + " Team: " + ControlTeams.GetTeamName(s.TeamID) + " Points: " + s.Points + " Matches: " + s.Matches + " Goals: " + s.Goalsfor + " Goals Against: " + s.Goalsagainst + " Goals Difference: " + s.Goaldifference);
                }
            }
            Console.WriteLine("Las estadísticas fueron guardadas en: C:\\Users\\Public\\Statistics.txt");


        }
    }
}
