using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                //cm.AddMatch();
                ControlMatches.ShowMatches();

                Console.WriteLine("Input the id for a new match");
                int id = int.Parse(Console.ReadLine());

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

                    Console.WriteLine("Input the scorer player");
                    ControlPlayers.ShowPlayers();
                    int playerId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input the scorer team");
                    Console.WriteLine("1. Local = {0}", Fteam.ToString());
                    Console.WriteLine("2. Visitor = {0}", Steam.ToString());
                    int teamGoal = int.Parse(Console.ReadLine());


                    ControlGoals.AddGoalInMatch(id, playerId, teamGoal);

                    Console.WriteLine("Do you want to add another goal? 1. Yes 2. No");
                    exit = int.Parse(Console.ReadLine());
                } while (exit == 1);

                //Count Local Goals
                int localGoals = ControlGoals.goals.Count(x => x.MatchId == id && x.TeamId == Fteam);

                //Count Visitor Goals
                int visitorGoals = ControlGoals.goals.Count(x => x.MatchId == id && x.TeamId == Steam);

                ControlMatches.matches.Add(new Matches(id, Fteam, Steam, tournament, localGoals, visitorGoals));
                //add match

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }




    }
}