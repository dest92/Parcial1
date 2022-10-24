﻿using Parcial1.Control;

namespace parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }


        public static void Menu()
        {
            Console.Clear();
            int options = 1;
            while (options != 0)
            {
                

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                System.Threading.Thread.Sleep(2000);

                Console.WriteLine("0. Salir");
                Console.WriteLine("1. Inicializar todo");
                Console.WriteLine("2. Agregar partido en torneo");

                //Seleccionar opcion con las flechas
                int index = 0;
                int selected = 0;
                int salir = 0;
                string[] opciones = { "0. Exit", "1. Inicializar todo", "2. Agregar partido en torneo" };
                do
                {
                    index = selected;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Inicializar todo");
                    Console.WriteLine("2. Agregar partido en torneo");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(0, index);
                    Console.CursorVisible = false;
                    Console.WriteLine(opciones[index]);
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        selected++;
                        if (selected == opciones.Length)
                        {
                            selected = 0;
                        }
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        selected--;
                        if (selected == -1)
                        {
                            selected = opciones.Length - 1;
                        }
                    }

                    //seleccionar con enter

                    if (key.Key == ConsoleKey.Enter)
                    {
                        options = selected;
                        salir = 1;

                    }
                } while (salir != 1);


                switch (options)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine(@"
                     ██████╗  ██████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███████╗██╗
                    ██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝██╔════╝██║
                    ██║  ███╗██║   ██║██║   ██║██║  ██║██████╔╝ ╚████╔╝ █████╗  ██║
                    ██║   ██║██║   ██║██║   ██║██║  ██║██╔══██╗  ╚██╔╝  ██╔══╝  ╚═╝
                    ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝██████╔╝   ██║   ███████╗██╗
                     ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ╚══════╝╚═╝                                         
");
                        break;

                    case 1:
                        Console.Clear();
                        ControlGoals cg = new();
                        cg.AddGoal();
                        ControlMatches cm = new();
                        cm.AddMatch();
                        ControlTeams ct = new();
                        ct.AddTeam();
                        ControlTournament ctour = new();
                        ctour.AddTournament();
                        ControlPosition controlPosition = new();
                        controlPosition.AddPosition();
                        ControlPlayers controlPlayers = new();
                        controlPlayers.AddPlayer();
                        break;

                    case 2:
                        Console.Clear();
                        ControlTournament controlTournament = new();
                        controlTournament.AddMatchInTournament();
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
   