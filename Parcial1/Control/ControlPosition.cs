using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
   static class ControlPosition
    {
        public static List<Position> pos = new List<Position>();

        public static void AddPosition()
        {
            

            pos.Add(new Position("Arquero"));
            pos.Add(new Position("Defensor"));
            pos.Add(new Position("Mediocampista"));
            pos.Add(new Position("Delantero"));

        }

        public static void ShowPosition()
        {
            foreach (Position p in pos)
            {
                Console.WriteLine("Posicion: " + p.PositionName);
            }
        }
    }
}
