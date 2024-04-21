using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Trådar_Asynkront
{
    internal class Race
    {
        public List<Cars> Races = new List<Cars>();


        public void AddCar(Cars car)
        {
            Races.Add(car);
        }

        public async Task StartRaceAsync()
        {
            List<Task> tasks = new List<Task>();
            bool raceWon = false;

            foreach (var car in Races)
            {
                tasks.Add(Task.Run(async () =>
                {
                    Console.WriteLine($"{car.CarName} startar racet . . . och körs av Thread nr {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(10000);
                    while (car.KmDrove < 2000)
                    {
                        car.RandomHappening(car);
                        Thread.Sleep(10000);
                    }
                    Console.WriteLine($"-------- {car.CarName} har nått målet! --------");
                    if (!raceWon)
                    {
                        Console.WriteLine($"******** Bilnummer: {car.Id}, {car.CarName} VANN RACET ********");
                        raceWon = true;
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }


        public void DisplayCarStatus()
        {
            foreach (var car in Races)
            {
                Console.WriteLine($"{car.Id}, {car.CarName} har kört {car.KmDrove} av 2000 och håller hastigheten {car.Speed}");
            }
        }

    }
}
