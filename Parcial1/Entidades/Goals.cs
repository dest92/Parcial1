using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Entidades
{
    class Goals
    {
        public int GoalId;

        //Foreign keys
        public int MatchId;
        public int PlayerId;
        public int TeamId;

        public List<Goals> goals;

        public Goals(int id, int MatchID,int Pid,int Tid)
        {
            GoalId = id;
            MatchId = MatchID;
            PlayerId = Pid;
            TeamId = Tid;

        }

    }
}
