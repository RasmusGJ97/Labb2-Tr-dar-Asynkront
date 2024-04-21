using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Trådar_Asynkront
{
    internal class Cars
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int Speed { get; set; }
        public int KmDrove { get; set; }


        public Cars(int id, string carName, int speed, int kmDrove)
        {
            Id = id;
            CarName = carName;
            Speed = speed;
            KmDrove = kmDrove;
        }


        public Cars RandomHappening(Cars car)
        {
            Random random = new Random();
            int rHappen = random.Next(1, 51);
            if (rHappen == 1)
            {
                Console.WriteLine($"{car.CarName} fick slut på bensin och behöver tanka, de står still i 30 sekunder.");
            }
            else if (rHappen == 2 || rHappen == 3)
            {
                Console.WriteLine($"{car.CarName} fick punktering och behöver byta däck, de står still i 20 sekunder.");
                car.KmDrove += (car.Speed / 3);
            }
            else if (rHappen >= 4 && rHappen <= 8)
            {
                Console.WriteLine($"En fågel träffar {car.CarName}'s bilruta och behöver tvätta den, de står still i 10 sekunder.");
                car.KmDrove += ((car.Speed / 3) * 2);
            }
            else if (rHappen >= 9 && rHappen <= 18)
            {
                car.Speed -= 5;
                Console.WriteLine($"{car.CarName}'s motor verkar bli sämre och de tappar lite toppfart. Deras nya toppfart är {car.Speed}");
                car.KmDrove += car.Speed;
            }
            else if (rHappen >= 19 && rHappen <= 21)
            {
                car.Speed += 5;
                Console.WriteLine($"{car.CarName} kör bra och de ökar sin toppfart. Deras nya toppfart är {car.Speed}");
                car.KmDrove += car.Speed;
            }
            else
            {
                Console.WriteLine($"{car.CarName} kör på för fullt.");
                car.KmDrove += (car.Speed);
            }
            return car;
        }
    }
}
