using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
    class Matches
    {
        public int MatchId;


        //Foreign keys
        public int LocalTeam;
        public int VisitorTeam;
        public int TournamentId;
        public int GoalsLocal;
        public int GoalsVisitor;

        public Matches(int id, int local, int visitor, int tournament, int goalslocal, int goalsvisitor)
        {
            MatchId = id;
            LocalTeam = local;
            VisitorTeam = visitor;
            TournamentId = tournament;
            GoalsLocal = goalslocal;
            GoalsVisitor = goalsvisitor;
        }

    }
}
