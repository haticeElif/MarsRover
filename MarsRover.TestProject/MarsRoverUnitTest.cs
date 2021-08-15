using MarsRover.Core.Entities;
using MarsRover.Core.Tools;
using System;
using Xunit;

namespace MarsRover.TestProject
{
    public class MarsRoverUnitTest
    {
        //[Fact]
        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void MarsRoverTest(string marsParameter, string roboticRoverParameter, string movementUnitsParameter, string expected)
        {
            MarsRoverTool marsRoverTool = new MarsRoverTool(); //Mars Ýþlemleri Classýnýn Üretilmesi.

            #region MarsRoverTravel
            Mars mars = marsRoverTool.NewMars(marsParameter); //Mars Oluþturma Ýþlemi.
            RoboticRover newRoboticRover = marsRoverTool.NewRoboticRover(roboticRoverParameter); //Mars Yüzeyindeki Gezicinin Ýlk Oluþum Ýþlemi.
            
            newRoboticRover = marsRoverTool.TravelRoboticRover(newRoboticRover, movementUnitsParameter); //Gelen Harekete Parametrelerine Göre Gezicinin Son Halinin Ýþlemi.
            mars.RRovers.Add(newRoboticRover); //Marsýn Ýçinde Çoklu Gezici Olmasý Durumu Ýçin Mars Gezicilerine Ekleme Ýþlemi.
            #endregion

            //Mars Yüzeyindeki Gezicilerin Son Konum Bilgileri.
            foreach (var item in mars.RRovers)
            {
                Assert.Equal(expected, string.Format("{0} {1} {2}", item.X, item.Y, item.Direction));
            }
        }
    }
}
