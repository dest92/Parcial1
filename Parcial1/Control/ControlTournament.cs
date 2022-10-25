using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    static class ControlTournament
    {
        public static List<Tournament> tournaments = new List<Tournament>();
        public static void AddTournament()
        {


            tournaments.Add(new Tournament(1, "Copa Argentina", 1));
            tournaments.Add(new Tournament(2, "Copa Libertadores", 1));
            tournaments.Add(new Tournament(1, "Copa Argentina", 2));
            tournaments.Add(new Tournament(1, "Copa Argentina", 3));
            tournaments.Add(new Tournament(1, "Copa Argentina", 4));
            tournaments.Add(new Tournament(1, "Copa Argentina", 5));

        }

        public static void ShowTournament()
        {
            foreach (Tournament t in tournaments.DistinctBy(x => x.TournamentId)) //tour through the list and select the tournaments by id omitting the ones that are repeated
            {
                Console.WriteLine("Id: " + t.TournamentId + " Tournament: " + t.Name);
            }



        }

        public static void AddMatchInTournament()
        {
            //Add match in tournament
            try
            {

                Console.WriteLine("Input the id for the first team");


                ControlTeams.ShowTeams();

                int Fteam = int.Parse(Console.ReadLine());

                Console.WriteLine("Input the id for the second team");
                int Steam = int.Parse(Console.ReadLine());

                Console.WriteLine("Input the id for the tournament");
                ShowTournament();

                int tournament = int.Parse(Console.ReadLine());

                //loop 

                int exit = 1;

                do
                {

                    Console.WriteLine("Add goals");

                    Console.WriteLine("Input the scorer team");
                    Console.WriteLine("1. Local = {0}", Fteam.ToString());
                    Console.WriteLine("2. Visitor = {0}", Steam.ToString());
                    int teamGoal = int.Parse(Console.ReadLine());


                    Console.WriteLine("Input the scorer player");
                    ControlPlayers.ShowPlayersByTeam(teamGoal);
                    int playerId = int.Parse(Console.ReadLine());

                    ControlGoals.AddGoalInMatch(ControlMatches.matches.Count + 1, playerId, teamGoal);

                    Console.WriteLine("Do you want to add another goal? 1. Yes 2. No");
                    exit = int.Parse(Console.ReadLine());
                } while (exit == 1);

                //Count Local Goals
                int localGoals = ControlGoals.goals.Count(x => x.MatchId == ControlMatches.matches.Count + 1 && x.TeamId == Fteam);

                //Count Visitor Goals
                int visitorGoals = ControlGoals.goals.Count(x => x.MatchId == ControlMatches.matches.Count + 1 && x.TeamId == Steam);

                ControlMatches.matches.Add(new Matches(ControlMatches.matches.Count + 1, Fteam, Steam, tournament, localGoals, visitorGoals));
                //add match

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }


        //Return tournament by id

        public static string GetTournamentName(int tournamentId)
        {
            string tournamentName = "";
            foreach (Tournament t in tournaments)
            {
                if (t.TournamentId == tournamentId)
                {
                    tournamentName = t.Name;
                }
            }
            return tournamentName;
        }

        //Positions table



        public static void ShowMatchesByTournament(int tournamentId)
        {
            Console.WriteLine("Matches in the tournament: {0}", GetTournamentName(tournamentId));
            foreach (Matches m in ControlMatches.matches)
            {
                if (m.TournamentId == tournamentId)
                {
                    Console.WriteLine("Match: {0} - {1} - {2}", m.MatchId, ControlTeams.GetTeamName(m.LocalTeam), ControlTeams.GetTeamName(m.VisitorTeam));
                }
            }
        }

        public static void PointsByTournament()
        {
            Console.WriteLine("Input the tournament id");
            ShowTournament();
            int tournamentId = int.Parse(Console.ReadLine());
            int points;

            Dictionary<string, int> teamsPoint = new Dictionary<string, int>();



            foreach (Teams t in ControlTeams.teams)
            {
                points = 0;
                foreach (Matches m in ControlMatches.matches)
                {
                    if (m.TournamentId == tournamentId)
                    {
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
                        else if (m.VisitorTeam == t.TeamId)
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


                    //check if key exists
                    if (teamsPoint.ContainsKey(t.TeamName))
                    {
                        //update the value
                        teamsPoint[t.TeamName] = points;
                    }
                    else
                    {
                        //add the key
                        teamsPoint.Add(t.TeamName, points);
                    }
                }
            }
            //Sort dictionary by points
            var sortedDict = from entry in teamsPoint orderby entry.Value descending select entry;
            //Show the dictionary
            foreach (KeyValuePair<string, int> entry in sortedDict)
            {
                Console.WriteLine("Team: {0} - Points: {1}", entry.Key, entry.Value);
            }
        }
        public static void TotalMatchesByTournament()
        {
            //Count matches of a team in a tournament
            Console.WriteLine("Input the tournament id");
            ShowTournament();
            int tournamentId = int.Parse(Console.ReadLine());

            foreach (Teams t in ControlTeams.teams)
            {
                int matches = 0;
                foreach (Matches m in ControlMatches.matches)
                {
                    if (m.TournamentId == tournamentId)
                    {
                        if (m.LocalTeam == t.TeamId || m.VisitorTeam == t.TeamId)
                        {
                            matches++;
                        }
                    }
                }
                Console.WriteLine("Team: {0} - Matches: {1}", t.TeamName, matches);
            }

        }

        public static void GoalsFor()
        {
            {
                //Count goals for a team in a tournament
                Console.WriteLine("Input the tournament id");
                ShowTournament();
                int tournamentId = int.Parse(Console.ReadLine());

                foreach (Teams t in ControlTeams.teams)
                {
                    int goals = 0;
                    foreach (Matches m in ControlMatches.matches)
                    {
                        if (m.TournamentId == tournamentId)
                        {
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
                    Console.WriteLine("Team: {0} - Goals: {1}", t.TeamName, goals);
                }
            }
        }

        public static void GoalsAgainst()
        {
            {
                //Count goals against a team in a tournament
                Console.WriteLine("Input the tournament id");
                ShowTournament();
                int tournamentId = int.Parse(Console.ReadLine());

                foreach (Teams t in ControlTeams.teams)
                {
                    int goals = 0;
                    foreach (Matches m in ControlMatches.matches)
                    {
                        if (m.TournamentId == tournamentId)
                        {
                            if (m.LocalTeam == t.TeamId)
                            {
                                goals += m.GoalsVisitor;
                            }
                            else if (m.VisitorTeam == t.TeamId)
                            {
                                goals += m.GoalsLocal;
                            }
                        }
                    }
                    Console.WriteLine("Team: {0} - Goals: {1}", t.TeamName, goals);
                }
            }
        }

        public static void GoalsDifference()
        {
            //Count goals difference of a team in a tournament
            Console.WriteLine("Input the tournament id");
            ShowTournament();
            int tournamentId = int.Parse(Console.ReadLine());

            foreach (Teams t in ControlTeams.teams)
            {
                int goals = 0;
                foreach (Matches m in ControlMatches.matches)
                {
                    if (m.TournamentId == tournamentId)
                    {
                        if (m.LocalTeam == t.TeamId)
                        {
                            goals += m.GoalsLocal - m.GoalsVisitor;
                        }
                        else if (m.VisitorTeam == t.TeamId)
                        {
                            goals += m.GoalsVisitor - m.GoalsLocal;
                        }
                    }
                }
                Console.WriteLine("Team: {0} - Goals: {1}", t.TeamName, goals);
            }
        }

        public static void ListStatistics()
        {
            //Show statistics of a tournament
           



        }
    }
}

  
     

    

  

