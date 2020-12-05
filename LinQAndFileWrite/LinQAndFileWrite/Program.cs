using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LinQAndFileWrite
{
    class Program
    {
        static void Main(string[] args)

        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://digikala.com");
            Console.WriteLine(reply);
            File.WriteAllText(@"E:\learning\writehere.txt",reply);
            List<Car> myCars = new List<Car>()
            {
               new Car(){VIN="A2",Make="oldsmobile",Model="cutlas Supereme",StickerPrice=55000,Year=2020 },
                new Car(){VIN="B1",Make="BMW",Model="toyota",StickerPrice=23000,Year=2017 },
                new Car(){VIN="C3",Make="BMW",Model="754i",StickerPrice=19500,Year=2013},
                 new Car(){VIN="E6",Make="Ford",Model="55i",StickerPrice=57000,Year=2011},
            };
            //LINQ query
            /*  var bmws = from mycar in myCars
                         where mycar.Make == "BMW"
                         && mycar.Year==2013
                         select mycar;

                foreach(var car in bmws)
              {
                  Console.WriteLine("{0},{1}", car.Model, car.Make);


              }
            */
            var orderCars = from car in myCars
                            orderby car.Year descending
                            select car;
            foreach (var car in orderCars)
            {
                Console.WriteLine("{0} {1} {2} {3}", car.VIN, car.Year, car.Model, car.Make);
            }
            var firstBMW = myCars.OrderByDescending(p => p.Year).First(p => p.Make == "BMW");
            Console.WriteLine(firstBMW.Year);
            //LINQ method
            /*    var bmws = myCars.Where(p => p.Make == "BMW");
                    foreach(var car in bmws)
                {
                    Console.WriteLine("{0} {1}", car.Make, car.Model);
                }
            }*/
            Console.WriteLine(myCars.Sum(p => p.StickerPrice));
            myCars.ForEach(p => p.StickerPrice -= 3000);
            myCars.ForEach(p => Console.WriteLine("{0} {1:C}", p.Year, p.StickerPrice));
            Console.ReadLine();
        }
        
       
    }
    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }
}
