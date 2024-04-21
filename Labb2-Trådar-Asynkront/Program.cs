namespace Labb2_Trådar_Asynkront
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Race race = new Race();

            bool program = true;
            while (program)
            {
                Console.Clear();
                Console.WriteLine("     Starta race");
                Console.WriteLine("     Lägg till bil");
                Console.WriteLine("     Se lista på bilar");
                Console.WriteLine("     Avsluta");

                int cursorPos = 0;
                Console.SetCursorPosition(0, cursorPos);
                Console.CursorVisible = false;
                Console.Write("-->");
                ConsoleKeyInfo navigator;

                do
                {
                    navigator = Console.ReadKey();
                    Console.SetCursorPosition(0, cursorPos);
                    Console.Write("   ");
                    if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 0)
                    {
                        cursorPos--;
                    }

                    else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 3)
                    {
                        cursorPos++;
                    }

                    Console.SetCursorPosition(0, cursorPos);

                    Console.Write("-->");
                } while (navigator.Key != ConsoleKey.Enter);

                Console.Clear();


                switch (cursorPos)
                {
                    case 0://Starta race
                        if (race.Races.Count >= 2)
                        {
                            bool raceStatus = true;
                            Task userInputTask = Task.Run(() =>
                            {
                                Console.WriteLine("Tryck på Enter för att visa status för varje bil:");
                                while (raceStatus)
                                {
                                    while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                                    if (raceStatus)
                                    {
                                        race.DisplayCarStatus();
                                    }
                                    
                                }                               
                            });

                            await race.StartRaceAsync();
                            raceStatus = false;
                            Console.WriteLine("Racet är avslutat . . .");
                            

                        }
                        else
                        {
                            Console.WriteLine("Det måste finnas minst två bilar i racet");
                        }
                        Console.ReadKey();
                        break;
                    case 1://Lägg till bil
                        if (race.Races.Count >= 8)
                        {
                            Console.WriteLine("Max antalet bilar av 8 är redan uppnått i racet");
                        }
                        else
                        {
                            Console.WriteLine("Skriv in number på din bil: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Skriv in namn på din bil: ");
                            string name = Console.ReadLine();

                            race.AddCar(new Cars(number, name, 120, 0));
                            Console.WriteLine($"Bil nummer {number}, {name} är nu tillagd i racet. . .");
                        }
                        
                        Console.ReadKey();
                        break;
                    case 2: // Se lista på alla bilar
                        foreach (var raceCar in race.Races)
                        {
                            Console.WriteLine(raceCar.Id + ", " + raceCar.CarName);
                        }
                        Console.ReadKey();
                        break;
                    case 3: //Avsluta programmet
                        Console.WriteLine("Avslutar programmet. . .");
                        Thread.Sleep(2000);
                        program = false;
                        break;

                }
            }
        }
    }
}
