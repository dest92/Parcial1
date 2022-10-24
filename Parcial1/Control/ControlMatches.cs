using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
     class ControlMatches
    {

        public List<Matches> matches;
        public void AddMatch()
        {
            matches = new List<Matches>();

            matches.Add(new Matches(1, 1, 2, 2, 1,1));
            matches.Add(new Matches(2, 3, 4, 1, 1, 1));
            matches.Add(new Matches(3, 5, 3, 1, 1, 1));
            matches.Add(new Matches(4, 2, 1, 1, 1, 1));
            matches.Add(new Matches(5, 4, 5, 1, 1, 1));
            matches.Add(new Matches(6, 3, 1, 1, 1, 1));
            matches.Add(new Matches(7, 5, 2, 1, 1, 1));
        }

        public void ShowMatches()
        {
            matches = new List<Matches>();
            foreach (Matches match in matches)
            {
                Console.WriteLine("Id: " + match.MatchId + " Local: " + match.LocalTeam + " Visitor: " + match.VisitorTeam +  " LocalGoals: " + match.GoalsLocal + " VisitorGoals: " + match.GoalsVisitor);
            }
        }
        
    }
}
