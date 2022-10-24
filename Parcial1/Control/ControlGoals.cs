using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    class ControlGoals
    {
        public List<Goals> goals;
        public void AddGoal()
        {
            goals = new List<Goals>();

            //add goals

            goals.Add(new Goals(1, 1, 1, 1));
            goals.Add(new Goals(2, 1, 1, 1));
            goals.Add(new Goals(3, 1, 1, 1));
            goals.Add(new Goals(4, 1, 1, 1));
            goals.Add(new Goals(5, 1, 1, 1));
            goals.Add(new Goals(6, 1, 2, 2));
            goals.Add(new Goals(7, 1, 7, 2));
            goals.Add(new Goals(8, 2, 3, 3));
            goals.Add(new Goals(9, 2, 4, 4));
            goals.Add(new Goals(10, 3, 5, 5));
            goals.Add(new Goals(11, 3, 1, 1));

        }

        public void ShowGoals()
        {
            foreach (Goals goal in goals)
            {
                Console.WriteLine("Id: " + goal.GoalId + " Player: " + goal.PlayerId + " Match: " + goal.MatchId + " Team: " + goal.TeamId);
            }
        }

        public void ShowGoalsByPlayer(int playerId)
        {
            foreach (Goals goal in goals)
            {
                if (goal.PlayerId == playerId)
                {
                    Console.WriteLine("Id: " + goal.GoalId + " Player: " + goal.PlayerId + " Match: " + goal.MatchId + " Team: " + goal.TeamId);
                }
            }
        }

        public void ShowGoalsByTeam(int teamId)
        {
            foreach (Goals goal in goals)
            {
                if (goal.TeamId == teamId)
                {
                    Console.WriteLine("Id: " + goal.GoalId + " Player: " + goal.PlayerId + " Match: " + goal.MatchId + " Team: " + goal.TeamId);
                }
            }
        }


        public void ShowGoalsByMatch(int matchId)
        {
            foreach (Goals goal in goals)
            {
                if (goal.MatchId == matchId)
                {
                    Console.WriteLine("Id: " + goal.GoalId + " Player: " + goal.PlayerId + " Match: " + goal.MatchId + " Team: " + goal.TeamId);
                }
            }
        }


        public void AddGoalInMatch(int matchId, int playerId, int teamId) { 
        
            goals.Add(new Goals(goals.Count + 1, matchId, playerId, teamId));
                //Console.WriteLine("Enter the match id: ");
                //ControlMatches cm = new();
                //cm.ShowMatches();
                //int matchId = Convert.ToInt32(Console.ReadLine());

                //Console.WriteLine("Enter the team id: ");
                //ControlTeams ct = new();
                //ct.ShowTeams();
                //int teamId = Convert.ToInt32(Console.ReadLine());
            
                //Console.WriteLine("Enter the player id: ");
                //ControlPlayers cp = new();
                //cp.ShowPlayers();

                //int playerId = Convert.ToInt32(Console.ReadLine());
     
                //goals.Add(new Goals(goals.Count + 1, playerId, matchId, teamId));
            
        }



    }
}

