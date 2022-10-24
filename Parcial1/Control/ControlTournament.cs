using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    class ControlTournament
    {
        public List<Tournament> tournaments;
        public void AddTournament()
        {
            tournaments = new List<Tournament>();

            tournaments.Add(new Tournament(1, "Copa Argentina", 1));
            tournaments.Add(new Tournament(2, "Copa Libertadores", 1));
            tournaments.Add(new Tournament(1, "Copa Argentina", 2));
            tournaments.Add(new Tournament(1, "Copa Argentina", 3));
            tournaments.Add(new Tournament(1, "Copa Argentina", 4));
            tournaments.Add(new Tournament(1, "Copa Argentina", 5));
            
        }

        public void ShowTournament()
        {
            foreach (Tournament t in tournaments.DistinctBy(x => x.TournamentId)) //tour through the list and select the tournaments by id omitting the ones that are repeated
            {
                Console.WriteLine("Id: " + t.TournamentId + " Tournament: " + t.Name);
            }
            


        }

        public void AddMatchInTournament()
        {
            //Add match in tournament
            try
            {
                ControlMatches cm = new ControlMatches();
                //cm.AddMatch();
                cm.ShowMatches();

                Console.WriteLine("Input the id for a new match");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Input the id for the first team");

                ControlTeams ct = new();
                ct.ShowTeams();

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
                    ControlGoals cg = new();
                    ControlPlayers cp = new();
                    Console.WriteLine("Input the scorer player");
                    cp.ShowPlayers();
                    int playerId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input the scorer team");
                    Console.WriteLine("1. Local = {0}", Fteam.ToString());
                    Console.WriteLine("2. Visitor = {0}", Steam.ToString());
                    int teamGoal = int.Parse(Console.ReadLine());


                    cg.AddGoalInMatch(id, playerId, teamGoal);

                    Console.WriteLine("Do you want to add another goal? 1. Yes 2. No");
                    exit = int.Parse(Console.ReadLine());
                } while (exit == 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }




    }
}