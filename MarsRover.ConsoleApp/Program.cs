using MarsRover.Core.Entities;
using MarsRover.Core.Tools;
using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverTool marsRoverTool = new MarsRoverTool(); //Mars İşlemleri Classının Üretilmesi.
            var marsParameter = Console.ReadLine(); //Mars Yüzey Alanı Bilgisinin Girişi.
            Mars mars = marsRoverTool.NewMars(marsParameter); //Mars Oluşturma İşlemi.

            #region Mars Rover and Travel
            for (int i = 0; i < 2; i++)
            {
                var roboticRoverParameter = Console.ReadLine(); //Gezici Konum ve Yön Bilgisinin Girişi.
                RoboticRover newRoboticRover = marsRoverTool.NewRoboticRover(roboticRoverParameter); //Mars Yüzeyindeki Gezicinin İlk Oluşum İşlemi.

                var movementUnitsParameter = Console.ReadLine(); //Gezici Hareket Bilgisinin Girişi.
                newRoboticRover = marsRoverTool.TravelRoboticRover(newRoboticRover, movementUnitsParameter); //Gelen Harekete Parametrelerine Göre Gezicinin Son Halinin İşlemi.
                mars.RRovers.Add(newRoboticRover); //Marsın İçinde Çoklu Gezici Olması Durumu İçin Mars Gezicilerine Ekleme İşlemi.
            }
            #endregion

            Console.WriteLine("\nOutput:");
            foreach (var item in mars.RRovers)
            {
                Console.WriteLine(string.Format("{0} {1} {2}", item.X, item.Y, item.Direction));
            }

            Console.ReadLine();
        }
    }
}
