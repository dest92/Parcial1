using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawers;

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
                        if (m.VisitorTeam == t.TeamId)
                        {
                            {
                                if (m.GoalsVisitor > m.GoalsLocal)
                                {
                                    points += 3;
                                }
                                else if (m.GoalsVisitor == m.GoalsLocal)
                                {
                                    points += 1;
                                }
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

        

        public static void TopScorersByTournament()
        {

            //Print scoring players

            Console.WriteLine("Input the tournament id");
            ControlTournament.ShowTournament();
            int tournamentId = int.Parse(Console.ReadLine());

            //scoring players by tournament

            var scoringPlayers = ControlMatches.matches.Where(x => x.TournamentId == tournamentId).Join(ControlGoals.goals, m => m.MatchId, g => g.MatchId, (m, g) => new { m, g }).Join(ControlPlayers.players, mg => mg.g.PlayerId, p => p.PlayerId, (mg, p) => new { mg, p }).Select(x => new { x.p.PlayerName, x.p.PlayerLastName, x.mg.g.GoalId }).ToList();

            //var scoringPlayersOrdered = scoringPlayers.GroupBy(x => x.PlayerLastName).Select(x => new { PlayerName = x.Key, Goals = x.Count(),  }).OrderByDescending(x => x.Goals).ToList();

            //order by goals with lastname
            var scoringPlayersOrdered2 = scoringPlayers.GroupBy(x => x.PlayerName).Select(x => new { PlayerName = x.Key, Goals = x.Count(), PlayerLastName = x.Select(y => y.PlayerLastName).FirstOrDefault() }).OrderByDescending(x => x.Goals).ToList();

            foreach (var s in scoringPlayersOrdered2)
            {
                Console.WriteLine("Player: " + s.PlayerName + " " + s.PlayerLastName  + " Goals: " + s.Goals);
            }


            //list to string array [,]

            string[,] scoringPlayersArray = new string[scoringPlayersOrdered2.Count+1, 3];

            //Set titles and values
            scoringPlayersArray[0, 0] = "Player";
            scoringPlayersArray[0, 1] = "Last Name";
            scoringPlayersArray[0, 2] = "Goals";

            for (int i = 1; i < scoringPlayersOrdered2.Count + 1; i++)
            {
                scoringPlayersArray[i, 0] = scoringPlayersOrdered2[i - 1].PlayerName;
                scoringPlayersArray[i, 1] = scoringPlayersOrdered2[i - 1].PlayerLastName;     
                scoringPlayersArray[i, 2] = scoringPlayersOrdered2[i - 1].Goals.ToString();
            }




            Drawers.DibujarTablas.DibujaTabla(scoringPlayersArray);

        }
    }
}
