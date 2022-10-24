using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Control
{
    static class  ControlPlayers
    {
        
        public static List<Players> players  = new List<Players>();


         
        public static void AddPlayer()
        {
            
            //add players
            players.Add(new Players(1, "Carlos", "Tevez", 35, 10, 4, 1));
            players.Add(new Players(2, "Gonzalo", "Higuain", 32, 9, 4, 2));
            players.Add(new Players(3, "Nicolás", "Tagliafico", 28, 3, 2, 3));
            players.Add(new Players(4, "Nicolás", "Domínguez", 28, 5, 3, 4));
            players.Add(new Players(5, "Franco", "Armani", 32, 1, 1, 5));
            players.Add(new Players(6, "Lucas", "Pratto", 31, 9, 4, 1));
            players.Add(new Players(7, "Ignacio", "Funes Mori", 30, 2, 2, 2));
            players.Add(new Players(8, "Enzo", "Perez", 32, 8, 3, 3));
            players.Add(new Players(9, "Leonardo", "Ponzio", 35, 5, 3, 4));
            players.Add(new Players(10, "Lucas", "Martinez Quarta", 26, 4, 2, 5));
            players.Add(new Players(11, "Lucas", "Alario", 26, 9, 4, 1));
            players.Add(new Players(12, "Nicolás", "De la Cruz", 25, 10, 3, 2));
            players.Add(new Players(13, "Lucas", "Ocampos", 26, 7, 3, 3));
            players.Add(new Players(14, "Javier", "Pinola", 33, 4, 2, 4));
            players.Add(new Players(15, "Nicolás", "Otamendi", 32, 2, 2, 5));
            players.Add(new Players(16, "Lionel", " Messi", 35, 10, 3, 1));
            players.Add(new Players(17, "Lautaro", "Martínez", 22, 9, 4, 2));
            players.Add(new Players(18, "Sergio", "Agüero", 32, 9, 4, 3));
            players.Add(new Players(19, "Giovani", "Lo Celso", 24, 8, 3, 4));
            players.Add(new Players(20, "Matias", "Acebal", 28, 3, 2, 5));


        }

        public static void ShowPlayers()
        {
            foreach (Players player in players)
            {
                Console.WriteLine("Id: " + player.PlayerId + " Name: " + player.PlayerName + " Last Name: " + player.PlayerLastName + " Team: " + player.TeamId);
            }
        }


    }



}
