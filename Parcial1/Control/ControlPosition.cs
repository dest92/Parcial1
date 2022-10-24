using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    class ControlPosition
    {
        public List<Position> pos;

        public void AddPosition()
        {
            pos = new List<Position>();

            pos.Add(new Position("Arquero"));
            pos.Add(new Position("Defensor"));
            pos.Add(new Position("Mediocampista"));
            pos.Add(new Position("Delantero"));

        }

        public void ShowPosition()
        {
            foreach (Position p in pos)
            {
                Console.WriteLine("Posicion: " + p.PositionName);
            }
        }
    }
}
